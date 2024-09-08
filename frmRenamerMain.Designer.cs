namespace Renamer
{
    partial class frmRenamerMain
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
            lblMain = new Label();
            txtMainFolder = new TextBox();
            btnChooseDir1 = new Button();
            label1 = new Label();
            lstSubDirs = new ListBox();
            lstFiles = new ListBox();
            label2 = new Label();
            txtNewName = new TextBox();
            SuspendLayout();
            // 
            // lblMain
            // 
            lblMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMain.Font = new Font("Segoe UI", 14F);
            lblMain.Location = new Point(12, 22);
            lblMain.Name = "lblMain";
            lblMain.Size = new Size(624, 35);
            lblMain.TabIndex = 0;
            lblMain.Text = "I Rename Files";
            lblMain.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMainFolder
            // 
            txtMainFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMainFolder.Location = new Point(2, 123);
            txtMainFolder.Name = "txtMainFolder";
            txtMainFolder.Size = new Size(597, 23);
            txtMainFolder.TabIndex = 1;
            // 
            // btnChooseDir1
            // 
            btnChooseDir1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChooseDir1.Location = new Point(603, 122);
            btnChooseDir1.Name = "btnChooseDir1";
            btnChooseDir1.Size = new Size(25, 23);
            btnChooseDir1.TabIndex = 2;
            btnChooseDir1.Text = "...";
            btnChooseDir1.UseVisualStyleBackColor = true;
            btnChooseDir1.Click += btnChooseDir1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 101);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 3;
            label1.Text = "Top level directory";
            // 
            // lstSubDirs
            // 
            lstSubDirs.FormattingEnabled = true;
            lstSubDirs.ItemHeight = 15;
            lstSubDirs.Location = new Point(2, 152);
            lstSubDirs.Name = "lstSubDirs";
            lstSubDirs.Size = new Size(626, 94);
            lstSubDirs.TabIndex = 4;
            lstSubDirs.SelectedIndexChanged += lstSubDirs_SelectedIndexChanged;
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 15;
            lstFiles.Location = new Point(2, 294);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(626, 124);
            lstFiles.TabIndex = 5;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 276);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 6;
            label2.Text = "Files";
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(3, 442);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(625, 23);
            txtNewName.TabIndex = 7;
            // 
            // frmRenamerMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 501);
            Controls.Add(txtNewName);
            Controls.Add(label2);
            Controls.Add(lstFiles);
            Controls.Add(lstSubDirs);
            Controls.Add(label1);
            Controls.Add(btnChooseDir1);
            Controls.Add(txtMainFolder);
            Controls.Add(lblMain);
            Name = "frmRenamerMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Renamer - I Rename Things";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMain;
        private TextBox txtMainFolder;
        private Button btnChooseDir1;
        private Label label1;
        private ListBox lstSubDirs;
        private ListBox lstFiles;
        private Label label2;
        private TextBox txtNewName;
    }
}