namespace VisualGMT
{
    partial class Preferences
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPathToLinuxTerminal = new System.Windows.Forms.TextBox();
            this.btnOpenPathToLinuxTerminal = new System.Windows.Forms.Button();
            this.btnOpenPathToGMTMainDirectory = new System.Windows.Forms.Button();
            this.tbPathToGMTMainDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOpenPathToPSViewer = new System.Windows.Forms.Button();
            this.tbPathToPSViewer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenPathToWorkingDirectory = new System.Windows.Forms.Button();
            this.tbPathToWorkingDirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linux Terminal full path and exe file name with extension";
            // 
            // tbPathToLinuxTerminal
            // 
            this.tbPathToLinuxTerminal.Location = new System.Drawing.Point(15, 25);
            this.tbPathToLinuxTerminal.Name = "tbPathToLinuxTerminal";
            this.tbPathToLinuxTerminal.Size = new System.Drawing.Size(510, 20);
            this.tbPathToLinuxTerminal.TabIndex = 1;
            // 
            // btnOpenPathToLinuxTerminal
            // 
            this.btnOpenPathToLinuxTerminal.Location = new System.Drawing.Point(541, 23);
            this.btnOpenPathToLinuxTerminal.Name = "btnOpenPathToLinuxTerminal";
            this.btnOpenPathToLinuxTerminal.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPathToLinuxTerminal.TabIndex = 2;
            this.btnOpenPathToLinuxTerminal.Text = "Set Path";
            this.btnOpenPathToLinuxTerminal.UseVisualStyleBackColor = true;
            this.btnOpenPathToLinuxTerminal.Click += new System.EventHandler(this.btnOpenPathToLinuxTerminal_Click);
            // 
            // btnOpenPathToGMTMainDirectory
            // 
            this.btnOpenPathToGMTMainDirectory.Location = new System.Drawing.Point(541, 70);
            this.btnOpenPathToGMTMainDirectory.Name = "btnOpenPathToGMTMainDirectory";
            this.btnOpenPathToGMTMainDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPathToGMTMainDirectory.TabIndex = 5;
            this.btnOpenPathToGMTMainDirectory.Text = "Set Path";
            this.btnOpenPathToGMTMainDirectory.UseVisualStyleBackColor = true;
            this.btnOpenPathToGMTMainDirectory.Click += new System.EventHandler(this.btnOpenPathToGMTMainDirectory_Click);
            // 
            // tbPathToGMTMainDirectory
            // 
            this.tbPathToGMTMainDirectory.Location = new System.Drawing.Point(15, 72);
            this.tbPathToGMTMainDirectory.Name = "tbPathToGMTMainDirectory";
            this.tbPathToGMTMainDirectory.Size = new System.Drawing.Size(510, 20);
            this.tbPathToGMTMainDirectory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "GMT Main Directory";
            // 
            // btnOpenPathToPSViewer
            // 
            this.btnOpenPathToPSViewer.Location = new System.Drawing.Point(541, 118);
            this.btnOpenPathToPSViewer.Name = "btnOpenPathToPSViewer";
            this.btnOpenPathToPSViewer.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPathToPSViewer.TabIndex = 8;
            this.btnOpenPathToPSViewer.Text = "Set Path";
            this.btnOpenPathToPSViewer.UseVisualStyleBackColor = true;
            this.btnOpenPathToPSViewer.Click += new System.EventHandler(this.btnOpenPathToPSViewer_Click);
            // 
            // tbPathToPSViewer
            // 
            this.tbPathToPSViewer.Location = new System.Drawing.Point(15, 120);
            this.tbPathToPSViewer.Name = "tbPathToPSViewer";
            this.tbPathToPSViewer.Size = new System.Drawing.Size(510, 20);
            this.tbPathToPSViewer.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "PS Viewer full path and exe file name with extension";
            // 
            // btnOpenPathToWorkingDirectory
            // 
            this.btnOpenPathToWorkingDirectory.Location = new System.Drawing.Point(541, 166);
            this.btnOpenPathToWorkingDirectory.Name = "btnOpenPathToWorkingDirectory";
            this.btnOpenPathToWorkingDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPathToWorkingDirectory.TabIndex = 11;
            this.btnOpenPathToWorkingDirectory.Text = "Set Path";
            this.btnOpenPathToWorkingDirectory.UseVisualStyleBackColor = true;
            this.btnOpenPathToWorkingDirectory.Click += new System.EventHandler(this.btnOpenPathToWorkingDirectory_Click);
            // 
            // tbPathToWorkingDirectory
            // 
            this.tbPathToWorkingDirectory.Location = new System.Drawing.Point(15, 168);
            this.tbPathToWorkingDirectory.Name = "tbPathToWorkingDirectory";
            this.tbPathToWorkingDirectory.Size = new System.Drawing.Size(510, 20);
            this.tbPathToWorkingDirectory.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Working Directory";
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.Location = new System.Drawing.Point(480, 205);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(136, 23);
            this.btnSaveAndExit.TabIndex = 13;
            this.btnSaveAndExit.Text = "Save and Exit";
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            this.btnSaveAndExit.Click += new System.EventHandler(this.btnSaveAndExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(329, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(136, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ofdFile
            // 
            this.ofdFile.Filter = "Execution file(*.exe)|*.exe";
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveAndExit);
            this.Controls.Add(this.btnOpenPathToWorkingDirectory);
            this.Controls.Add(this.tbPathToWorkingDirectory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenPathToPSViewer);
            this.Controls.Add(this.tbPathToPSViewer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOpenPathToGMTMainDirectory);
            this.Controls.Add(this.tbPathToGMTMainDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenPathToLinuxTerminal);
            this.Controls.Add(this.tbPathToLinuxTerminal);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPathToLinuxTerminal;
        private System.Windows.Forms.Button btnOpenPathToLinuxTerminal;
        private System.Windows.Forms.Button btnOpenPathToGMTMainDirectory;
        private System.Windows.Forms.TextBox tbPathToGMTMainDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOpenPathToPSViewer;
        private System.Windows.Forms.TextBox tbPathToPSViewer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOpenPathToWorkingDirectory;
        private System.Windows.Forms.TextBox tbPathToWorkingDirectory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveAndExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.OpenFileDialog ofdFile;
    }
}