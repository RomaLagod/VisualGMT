namespace VisualGMT
{
    partial class VisualGMT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualGMT));
            this.msGeneralMenu = new System.Windows.Forms.MenuStrip();
            this.pGMTHighlightingTools = new System.Windows.Forms.Panel();
            this.GMT_FATabStripCollectionSet = new GMT_GUI_component.GMT_FATabStripCollection();
            this.ssDocumentInfo = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDinmation = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCursorPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssbScale = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.GMT_FATabStripCollectionSet)).BeginInit();
            this.GMT_FATabStripCollectionSet.SuspendLayout();
            this.ssDocumentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // msGeneralMenu
            // 
            this.msGeneralMenu.BackColor = System.Drawing.Color.Transparent;
            this.msGeneralMenu.Location = new System.Drawing.Point(0, 0);
            this.msGeneralMenu.Name = "msGeneralMenu";
            this.msGeneralMenu.Size = new System.Drawing.Size(935, 24);
            this.msGeneralMenu.TabIndex = 1;
            this.msGeneralMenu.Text = "menuStrip1";
            // 
            // pGMTHighlightingTools
            // 
            this.pGMTHighlightingTools.BackColor = System.Drawing.Color.White;
            this.pGMTHighlightingTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGMTHighlightingTools.Location = new System.Drawing.Point(0, 24);
            this.pGMTHighlightingTools.Name = "pGMTHighlightingTools";
            this.pGMTHighlightingTools.Size = new System.Drawing.Size(935, 30);
            this.pGMTHighlightingTools.TabIndex = 2;
            // 
            // GMT_FATabStripCollectionSet
            // 
            this.GMT_FATabStripCollectionSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GMT_FATabStripCollectionSet.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.GMT_FATabStripCollectionSet.Location = new System.Drawing.Point(0, 54);
            this.GMT_FATabStripCollectionSet.Name = "GMT_FATabStripCollectionSet";
            this.GMT_FATabStripCollectionSet.Size = new System.Drawing.Size(935, 218);
            this.GMT_FATabStripCollectionSet.TabIndex = 0;
            this.GMT_FATabStripCollectionSet.Text = "gmT_FATabStripCollection1";
            // 
            // ssDocumentInfo
            // 
            this.ssDocumentInfo.BackColor = System.Drawing.Color.DodgerBlue;
            this.ssDocumentInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tsslDinmation,
            this.tsslCursorPosition,
            this.tspbTime,
            this.tssbScale,
            this.toolStripProgressBar1});
            this.ssDocumentInfo.Location = new System.Drawing.Point(1, 193);
            this.ssDocumentInfo.Name = "ssDocumentInfo";
            this.ssDocumentInfo.Size = new System.Drawing.Size(933, 24);
            this.ssDocumentInfo.TabIndex = 0;
            this.ssDocumentInfo.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(480, 19);
            this.tsslStatus.Spring = true;
            this.tsslStatus.Text = "tsslStatus";
            // 
            // tsslDinmation
            // 
            this.tsslDinmation.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslDinmation.Name = "tsslDinmation";
            this.tsslDinmation.Size = new System.Drawing.Size(105, 19);
            this.tsslDinmation.Text = "length : 0  lines : 0";
            // 
            // tsslCursorPosition
            // 
            this.tsslCursorPosition.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslCursorPosition.Name = "tsslCursorPosition";
            this.tsslCursorPosition.Size = new System.Drawing.Size(123, 19);
            this.tsslCursorPosition.Text = "Ln : 0  Col : 0  Sel : 0|0";
            // 
            // tspbTime
            // 
            this.tspbTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tspbTime.Name = "tspbTime";
            this.tspbTime.Size = new System.Drawing.Size(29, 19);
            this.tspbTime.Text = "INS";
            // 
            // tssbScale
            // 
            this.tssbScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssbScale.Image = ((System.Drawing.Image)(resources.GetObject("tssbScale.Image")));
            this.tssbScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbScale.Name = "tssbScale";
            this.tssbScale.Size = new System.Drawing.Size(48, 22);
            this.tssbScale.Text = "100%";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressBar1.Visible = false;
            // 
            // VisualGMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 272);
            this.Controls.Add(this.GMT_FATabStripCollectionSet);
            this.Controls.Add(this.pGMTHighlightingTools);
            this.Controls.Add(this.msGeneralMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msGeneralMenu;
            this.Name = "VisualGMT";
            this.Text = "VisualGMT";
            this.Load += new System.EventHandler(this.VisualGMT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GMT_FATabStripCollectionSet)).EndInit();
            this.GMT_FATabStripCollectionSet.ResumeLayout(false);
            this.GMT_FATabStripCollectionSet.PerformLayout();
            this.ssDocumentInfo.ResumeLayout(false);
            this.ssDocumentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msGeneralMenu;
        private System.Windows.Forms.Panel pGMTHighlightingTools;
        private GMT_GUI_component.GMT_FATabStripCollection GMT_FATabStripCollectionSet;
        private System.Windows.Forms.StatusStrip ssDocumentInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslDinmation;
        private System.Windows.Forms.ToolStripStatusLabel tsslCursorPosition;
        private System.Windows.Forms.ToolStripStatusLabel tspbTime;
        private System.Windows.Forms.ToolStripDropDownButton tssbScale;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

