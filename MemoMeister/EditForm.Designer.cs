namespace MemoMeister
{
    partial class EditForm
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
            this.components = new System.ComponentModel.Container();
            this.dgvRemarks = new System.Windows.Forms.DataGridView();
            this.MemoKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpRemarkEdit = new System.Windows.Forms.GroupBox();
            this.cboRemarkType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtMemoText = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remarkBindingSource)).BeginInit();
            this.grpRemarkEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRemarks
            // 
            this.dgvRemarks.AllowUserToAddRows = false;
            this.dgvRemarks.AllowUserToDeleteRows = false;
            this.dgvRemarks.AllowUserToOrderColumns = true;
            this.dgvRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRemarks.AutoGenerateColumns = false;
            this.dgvRemarks.BackgroundColor = System.Drawing.Color.White;
            this.dgvRemarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRemarks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemoKey,
            this.DateStamp,
            this.UserId,
            this.MemoText});
            this.dgvRemarks.DataSource = this.remarkBindingSource;
            this.dgvRemarks.Location = new System.Drawing.Point(0, 0);
            this.dgvRemarks.MultiSelect = false;
            this.dgvRemarks.Name = "dgvRemarks";
            this.dgvRemarks.ReadOnly = true;
            this.dgvRemarks.RowHeadersVisible = false;
            this.dgvRemarks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRemarks.Size = new System.Drawing.Size(615, 273);
            this.dgvRemarks.TabIndex = 0;
            this.dgvRemarks.SelectionChanged += new System.EventHandler(this.dgvRemarks_SelectionChanged);
            this.dgvRemarks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvRemarks_KeyUp);
            // 
            // MemoKey
            // 
            this.MemoKey.DataPropertyName = "MemoKey";
            this.MemoKey.HeaderText = "MemoKey";
            this.MemoKey.Name = "MemoKey";
            this.MemoKey.ReadOnly = true;
            this.MemoKey.Visible = false;
            // 
            // DateStamp
            // 
            this.DateStamp.DataPropertyName = "DateStamp";
            this.DateStamp.HeaderText = "Date";
            this.DateStamp.Name = "DateStamp";
            this.DateStamp.ReadOnly = true;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            // 
            // MemoText
            // 
            this.MemoText.DataPropertyName = "MemoText";
            this.MemoText.HeaderText = "Remark";
            this.MemoText.Name = "MemoText";
            this.MemoText.ReadOnly = true;
            this.MemoText.Width = 400;
            // 
            // remarkBindingSource
            // 
            this.remarkBindingSource.DataSource = typeof(MemoMeister.Remark);
            // 
            // grpRemarkEdit
            // 
            this.grpRemarkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRemarkEdit.Controls.Add(this.cboRemarkType);
            this.grpRemarkEdit.Controls.Add(this.label1);
            this.grpRemarkEdit.Controls.Add(this.btnDelete);
            this.grpRemarkEdit.Controls.Add(this.txtMemoText);
            this.grpRemarkEdit.Controls.Add(this.btnSave);
            this.grpRemarkEdit.Location = new System.Drawing.Point(6, 279);
            this.grpRemarkEdit.Name = "grpRemarkEdit";
            this.grpRemarkEdit.Size = new System.Drawing.Size(524, 129);
            this.grpRemarkEdit.TabIndex = 1;
            this.grpRemarkEdit.TabStop = false;
            this.grpRemarkEdit.Text = "View/Edit Remark";
            // 
            // cboRemarkType
            // 
            this.cboRemarkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRemarkType.FormattingEnabled = true;
            this.cboRemarkType.Location = new System.Drawing.Point(89, 21);
            this.cboRemarkType.Name = "cboRemarkType";
            this.cboRemarkType.Size = new System.Drawing.Size(177, 21);
            this.cboRemarkType.TabIndex = 1;
            this.cboRemarkType.SelectedIndexChanged += new System.EventHandler(this.cboRemarkType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type Change";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(435, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtMemoText
            // 
            this.txtMemoText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMemoText.Location = new System.Drawing.Point(11, 55);
            this.txtMemoText.Multiline = true;
            this.txtMemoText.Name = "txtMemoText";
            this.txtMemoText.Size = new System.Drawing.Size(418, 58);
            this.txtMemoText.TabIndex = 2;
            this.txtMemoText.TextChanged += new System.EventHandler(this.txtMemoText_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(435, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(540, 334);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 27);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(540, 365);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 421);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grpRemarkEdit);
            this.Controls.Add(this.dgvRemarks);
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Text = "EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remarkBindingSource)).EndInit();
            this.grpRemarkEdit.ResumeLayout(false);
            this.grpRemarkEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRemarks;
        private System.Windows.Forms.GroupBox grpRemarkEdit;
        private System.Windows.Forms.ComboBox cboRemarkType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtMemoText;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoText;
        private System.Windows.Forms.BindingSource remarkBindingSource;
    }
}