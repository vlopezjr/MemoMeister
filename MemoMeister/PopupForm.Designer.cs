namespace MemoMeister
{
    partial class PopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(59, 5);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(283, 20);
            this.txtType.TabIndex = 0;
            this.txtType.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(22, 8);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(181, 113);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(80, 27);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "&Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(9, 31);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(44, 13);
            this.lblRemark.TabIndex = 4;
            this.lblRemark.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(59, 31);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(283, 76);
            this.txtRemark.TabIndex = 3;
            this.txtRemark.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(262, 113);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 27);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(100, 123);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Count";
            // 
            // PopupForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 146);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PopupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblCount;
    }
}