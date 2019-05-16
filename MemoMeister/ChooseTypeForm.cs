using System;
using System.Collections;
using System.Windows.Forms;

namespace MemoMeister
{
    public partial class ChooseTypeForm : Form
    {
        public ChooseTypeForm()
        {
            InitializeComponent();
        }

        bool cancelled;
        int selectedIndex;

        public RemarkType ChooseType(RemarkContext context)
        {
            lbRemarkType.Items.Clear();

            foreach (DictionaryEntry type in context.RemarkTypes)
            {
                var remarkType = (RemarkType)type.Value;
                if (remarkType.CanCreate == 1)
                    lbRemarkType.Items.Add(remarkType.Caption);
            }



            if (lbRemarkType.Items.Count < 1)
            {
                return null;
            }
            else if (lbRemarkType.Items.Count == 1)
            {
                return (RemarkType)context.RemarkTypes[0];
            }
            else
            {
                lbRemarkType.SelectedIndex = 0;

                ShowDialog();
                if (cancelled)
                {
                    return null;
                }
                else
                {
                    return (RemarkType)context.RemarkTypes[lbRemarkType.SelectedIndex];
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            selectedIndex = lbRemarkType.SelectedIndex;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            Close();
        }

        private void lbRemarkType_DoubleClick(object sender, EventArgs e)
        {
            selectedIndex = lbRemarkType.SelectedIndex;
            Close();
        }
    }
}
