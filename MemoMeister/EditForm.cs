using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace MemoMeister
{
    public partial class EditForm : Form
    {
        private RemarkContext context;
        private Remark selectedRemark;
        private bool loading;

        public EditForm()
        {
            InitializeComponent();
        }


        public void View(RemarkContext _context)
        {
            context = _context;
            ShowDialog();
        }







        //FORM LOAD
        private void EditForm_Load(object sender, EventArgs e)
        {
            Text = context.OwnerName + " [" + context.OwnerId + "] " + context.EntityName; //+ " Remarks [" + context.Server + "]"

            dgvRemarks.Columns["MemoText"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRemarks.Columns["MemoText"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dgvRemarks.DataSource = context.Remarks;
            selectedRemark = context.Remarks.FirstOrDefault();

            UpdateControls();
        }

        private void UpdateControls()
        {
            bool canDelete;
            bool canUpdate;

            if (selectedRemark == null) return;

            canDelete = selectedRemark.CanDelete;
            canUpdate = selectedRemark.CanUpdate;

            // you can update your own remarks, except for collection history
            if ((selectedRemark.TypeId != "Cust.AR.Coll") && (selectedRemark.CanCreate) && (selectedRemark.UserId == Environment.UserName))
            {
                selectedRemark.RemarkType.CanDelete = 1;
                selectedRemark.RemarkType.CanUpdate = 1;
            }

            //text state
            txtMemoText.Text = selectedRemark.MemoText;
            txtMemoText.Enabled = selectedRemark.CanUpdate;

            //combobox setup
            if (selectedRemark.CanDelete)
            {
                cboRemarkType.Enabled = true;

                foreach (DictionaryEntry type in context.RemarkTypes)
                {
                    var remarkType = (RemarkType)type.Value;

                    if (remarkType.CanCreate == 1)
                        cboRemarkType.Items.Add(remarkType.Caption);
                }

                if (!selectedRemark.CanCreate)
                    cboRemarkType.Items.Insert(0, selectedRemark.Caption);

                cboRemarkType.Text = selectedRemark.Caption;
            }
            else
            {
                cboRemarkType.Items.Add(selectedRemark.Caption);
                cboRemarkType.Enabled = false;
                cboRemarkType.SelectedIndex = 0;
            }

            //buttons
            btnSave.Enabled = false;
            btnDelete.Enabled = selectedRemark.CanDelete;

            //captions
            if (selectedRemark.CanUpdate)
                grpRemarkEdit.Text = "Edit Remark";
            else
                grpRemarkEdit.Text = "View Remark";

            selectedRemark.RemarkType.CanDelete = canDelete ? (short)1:(short)0;
            selectedRemark.RemarkType.CanUpdate = canUpdate ? (short)1 : (short)0;
        }







        //NEW
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (txtMemoText.Text.Length > 0)
                btnSave.PerformClick();

            var chooseTypeForm = new ChooseTypeForm();
            var remarkTypeSelected = chooseTypeForm.ChooseType(context);

            if (remarkTypeSelected == null)
                return;

            selectedRemark = new Remark();
            selectedRemark.RemarkType = remarkTypeSelected;

            loading = true;

            txtMemoText.Text = "";
            txtMemoText.Enabled = true;
            txtMemoText.Focus();

            foreach (DictionaryEntry type in context.RemarkTypes)
            {
                var remarkType = (RemarkType)type.Value;
                if (remarkType.CanCreate == 1)
                {
                    cboRemarkType.Items.Add(remarkType.Caption);
                }
            }

            cboRemarkType.Text = remarkTypeSelected.Caption;

            cboRemarkType.Enabled = true;
            loading = false;

            btnDelete.Enabled = false;
            btnSave.Enabled = true;

            grpRemarkEdit.Text = "Edit Remark";
        }








        //SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemoText.Text))
            {
                MessageBox.Show("Empty remarks not permitted. Use delete to erase a remark");
                return;
            }

            Cursor = Cursors.WaitCursor;

            bool updating = false;
            if (selectedRemark.MemoText != txtMemoText.Text.TrimEnd())
            {
                selectedRemark.MemoText = txtMemoText.Text.TrimEnd();
                updating = true;
            }

            if (selectedRemark.Caption != cboRemarkType.Text)
            {
                selectedRemark.RemarkType = GetRemarkByCaption(cboRemarkType.Text);
                updating = true;
            }

            if (updating)
            {
                selectedRemark.UserId = Environment.UserName;
                selectedRemark.DateStamp = DateTime.Now;
                selectedRemark.IsDirty = true;
            }

            var index = context.Remarks.FindIndex(c => c == selectedRemark);
            if(index == -1)
            {
                context.Remarks.Add(selectedRemark);
            }

            btnSave.Enabled = false;

            dgvRemarks.DataSource = null;
            dgvRemarks.DataSource = context.Remarks;
            dgvRemarks.Focus();

            Cursor = Cursors.Default;
        }

        private RemarkType GetRemarkByCaption(string caption)
        {
            foreach (DictionaryEntry entry in context.RemarkTypes)
            {
                var remarkType = (RemarkType)entry.Value;
                if (remarkType.Caption == caption)
                    return remarkType;
            }

            return null;
        }







        //DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRemark == null) return;

            if (txtMemoText.Text.Length > 0)
                btnSave.PerformClick();

            Cursor = Cursors.WaitCursor;

            context.RemoveRemark(selectedRemark.MemoKey);

            dgvRemarks.DataSource = null;
            dgvRemarks.DataSource = context.Remarks;

            Cursor = Cursors.Default;
        }








        //SELECTION CHANGED
        private void dgvRemarks_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            if (dgvRemarks.SelectedRows.Count == 0) return;

            if(txtMemoText.Text.Length > 0)
                btnSave.PerformClick();

            selectedRemark = (Remark)dgvRemarks.SelectedRows[0].DataBoundItem;

            loading = true;
            UpdateControls();
            loading = false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (context == null) return;

            if (txtMemoText.Text.Length > 0)
                btnSave.PerformClick(); //store current remark

            context.Save();

            context = null;
        }

        private void txtMemoText_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            btnSave.Enabled = true;
        }







        //TYPE CHANGED
        private void cboRemarkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            //how does this know if the memo text changed?
            if (cboRemarkType.Text == selectedRemark.Caption)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }





        private void dgvRemarks_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

    }
}
