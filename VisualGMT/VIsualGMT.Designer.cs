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
            this.splitter_first = new System.Windows.Forms.Splitter();
            this.GMT_FATabStripCollectionSet = new GMT_GUI_component.GMT_FATabStripCollection();
            this.ssDocument = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDinmation = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCursorPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTextMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssbScale = new System.Windows.Forms.ToolStripDropDownButton();
            this.tspbTime = new System.Windows.Forms.ToolStripProgressBar();
            this.gmT_FATabStripCollection1 = new GMT_GUI_component.GMT_FATabStripCollection();
            this.pGMTHighlightingTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GMT_FATabStripCollectionSet)).BeginInit();
            this.ssDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gmT_FATabStripCollection1)).BeginInit();
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
            this.pGMTHighlightingTools.Controls.Add(this.splitter_first);
            this.pGMTHighlightingTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.pGMTHighlightingTools.Location = new System.Drawing.Point(0, 24);
            this.pGMTHighlightingTools.Name = "pGMTHighlightingTools";
            this.pGMTHighlightingTools.Size = new System.Drawing.Size(935, 30);
            this.pGMTHighlightingTools.TabIndex = 2;
            // 
            // splitter_first
            // 
            this.splitter_first.BackColor = System.Drawing.Color.Silver;
            this.splitter_first.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter_first.Location = new System.Drawing.Point(0, 0);
            this.splitter_first.Name = "splitter_first";
            this.splitter_first.Size = new System.Drawing.Size(935, 1);
            this.splitter_first.TabIndex = 0;
            this.splitter_first.TabStop = false;
            // 
            // GMT_FATabStripCollectionSet
            // 
            this.GMT_FATabStripCollectionSet.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.GMT_FATabStripCollectionSet.Location = new System.Drawing.Point(0, 0);
            this.GMT_FATabStripCollectionSet.Name = "GMT_FATabStripCollectionSet";
            this.GMT_FATabStripCollectionSet.Size = new System.Drawing.Size(350, 200);
            this.GMT_FATabStripCollectionSet.TabIndex = 0;
            // 
            // ssDocument
            // 
            this.ssDocument.BackColor = System.Drawing.Color.DodgerBlue;
            this.ssDocument.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslDinmation,
            this.tsslCursorPosition,
            this.tsslTextMode,
            this.tssbScale,
            this.tspbTime});
            this.ssDocument.Location = new System.Drawing.Point(0, 248);
            this.ssDocument.Name = "ssDocument";
            this.ssDocument.Size = new System.Drawing.Size(935, 24);
            this.ssDocument.TabIndex = 3;
            this.ssDocument.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(615, 19);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "tsslStatus";
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
            // tsslTextMode
            // 
            this.tsslTextMode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsslTextMode.Name = "tsslTextMode";
            this.tsslTextMode.Size = new System.Drawing.Size(29, 19);
            this.tsslTextMode.Text = "INS";
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
            // tspbTime
            // 
            this.tspbTime.Name = "tspbTime";
            this.tspbTime.Size = new System.Drawing.Size(100, 18);
            this.tspbTime.Visible = false;
            // 
            // gmT_FATabStripCollection1
            // 
            this.gmT_FATabStripCollection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmT_FATabStripCollection1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gmT_FATabStripCollection1.Location = new System.Drawing.Point(0, 54);
            this.gmT_FATabStripCollection1.Name = "gmT_FATabStripCollection1";
            this.gmT_FATabStripCollection1.Size = new System.Drawing.Size(935, 194);
            this.gmT_FATabStripCollection1.TabIndex = 4;
            this.gmT_FATabStripCollection1.Text = "gmT_FATabStripCollection1";
            // 
            // VisualGMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 272);
            this.Controls.Add(this.gmT_FATabStripCollection1);
            this.Controls.Add(this.ssDocument);
            this.Controls.Add(this.pGMTHighlightingTools);
            this.Controls.Add(this.msGeneralMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msGeneralMenu;
            this.Name = "VisualGMT";
            this.Text = "VisualGMT";
            this.Load += new System.EventHandler(this.VisualGMT_Load);
            this.pGMTHighlightingTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GMT_FATabStripCollectionSet)).EndInit();
            this.ssDocument.ResumeLayout(false);
            this.ssDocument.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gmT_FATabStripCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msGeneralMenu;
        private System.Windows.Forms.Panel pGMTHighlightingTools;
        private GMT_GUI_component.GMT_FATabStripCollection GMT_FATabStripCollectionSet;
        private System.Windows.Forms.StatusStrip ssDocument;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslDinmation;
        private System.Windows.Forms.ToolStripStatusLabel tsslCursorPosition;
        private System.Windows.Forms.ToolStripStatusLabel tsslTextMode;
        private System.Windows.Forms.ToolStripDropDownButton tssbScale;
        private System.Windows.Forms.ToolStripProgressBar tspbTime;
        private System.Windows.Forms.Splitter splitter_first;
        private GMT_GUI_component.GMT_FATabStripCollection gmT_FATabStripCollection1;
    }
}

