using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoMeister
{
    public partial class PopupForm : Form
    {
        private RemarkContext context;
        private List<Remark> popupRemarks;
        private int index;
        private int popupCount;

        public PopupForm()
        {
            InitializeComponent();
        }


        public void View(RemarkContext _context)
        {
            context = _context;
            popupRemarks = context.Remarks.Where(c => c.RemarkType.ShowPopup).ToList();
            popupCount = popupRemarks.Count();

            if (popupCount == 0) return;

            Text = context.OwnerName + " [" + context.OwnerId + "] " + context.EntityName;
            index = 0;

            UpdateControls();
            ShowDialog();
            Close();
        }

        private void UpdateControls()
        {
            btnPrevious.Enabled = index > 0;
            btnPrevious.Visible = popupCount > 1;

            if (index == popupCount)
                btnNext.Text = "&Finish";
            else
                btnNext.Text = "&Next";

            var remarkToDisplay = popupRemarks[index];

            txtRemark.Text = remarkToDisplay.MemoText;
            txtType.Text = remarkToDisplay.Caption + " (" + remarkToDisplay.UserId + " on " + remarkToDisplay.DateStamp.ToString("MM/dd/yyyy") + ")";
            lblCount.Text = "Remark " + (index + 1) + " of " + popupCount;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index = index + 1;
            if (index == popupCount)
                Close();
            else
                UpdateControls();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            index = index - 1;
            UpdateControls();
        }
    }
}
