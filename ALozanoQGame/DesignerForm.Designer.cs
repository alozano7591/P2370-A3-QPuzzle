/* Alfredo Lozano
 * 5397591
 * alozano7591@conestogac.on.ca
 * Assignment 3: QGame:
 * This project contains a program that allows users to create puzzle game maps 
 * and save their content.
 */

namespace ALozanoQGame
{


    partial class DesignerForm
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
            this.pnlDesignTools = new System.Windows.Forms.Panel();
            this.btnRedDoor = new System.Windows.Forms.Button();
            this.btnRedBox = new System.Windows.Forms.Button();
            this.btnGreenDoor = new System.Windows.Forms.Button();
            this.btnGreenBox = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.lblTools = new System.Windows.Forms.Label();
            this.saveFileDialogDesign = new System.Windows.Forms.SaveFileDialog();
            this.menuStripDesign = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGenerateOptions = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tbColumns = new System.Windows.Forms.TextBox();
            this.tbRows = new System.Windows.Forms.TextBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.imageListTools = new System.Windows.Forms.ImageList(this.components);
            this.pnlDesignTools.SuspendLayout();
            this.menuStripDesign.SuspendLayout();
            this.pnlGenerateOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDesignTools
            // 
            this.pnlDesignTools.AutoSize = true;
            this.pnlDesignTools.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDesignTools.Controls.Add(this.btnRedDoor);
            this.pnlDesignTools.Controls.Add(this.btnRedBox);
            this.pnlDesignTools.Controls.Add(this.btnGreenDoor);
            this.pnlDesignTools.Controls.Add(this.btnGreenBox);
            this.pnlDesignTools.Controls.Add(this.btnWall);
            this.pnlDesignTools.Controls.Add(this.btnNone);
            this.pnlDesignTools.Controls.Add(this.lblTools);
            this.pnlDesignTools.Location = new System.Drawing.Point(0, 78);
            this.pnlDesignTools.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDesignTools.Name = "pnlDesignTools";
            this.pnlDesignTools.Size = new System.Drawing.Size(141, 399);
            this.pnlDesignTools.TabIndex = 0;
            // 
            // btnRedDoor
            // 
            this.btnRedDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedDoor.Location = new System.Drawing.Point(12, 144);
            this.btnRedDoor.Margin = new System.Windows.Forms.Padding(2);
            this.btnRedDoor.Name = "btnRedDoor";
            this.btnRedDoor.Size = new System.Drawing.Size(123, 50);
            this.btnRedDoor.TabIndex = 6;
            this.btnRedDoor.Text = "Red Door";
            this.btnRedDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedDoor.UseVisualStyleBackColor = true;
            this.btnRedDoor.Click += new System.EventHandler(this.btnBlockTool_Click);
            // 
            // btnRedBox
            // 
            this.btnRedBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRedBox.Location = new System.Drawing.Point(12, 252);
            this.btnRedBox.Margin = new System.Windows.Forms.Padding(2);
            this.btnRedBox.Name = "btnRedBox";
            this.btnRedBox.Size = new System.Drawing.Size(123, 50);
            this.btnRedBox.TabIndex = 5;
            this.btnRedBox.Text = "Red Box";
            this.btnRedBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRedBox.UseVisualStyleBackColor = true;
            this.btnRedBox.Click += new System.EventHandler(this.btnBlockTool_Click);
            // 
            // btnGreenDoor
            // 
            this.btnGreenDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGreenDoor.Location = new System.Drawing.Point(12, 198);
            this.btnGreenDoor.Margin = new System.Windows.Forms.Padding(2);
            this.btnGreenDoor.Name = "btnGreenDoor";
            this.btnGreenDoor.Size = new System.Drawing.Size(123, 50);
            this.btnGreenDoor.TabIndex = 4;
            this.btnGreenDoor.Text = "Green Door";
            this.btnGreenDoor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenDoor.UseVisualStyleBackColor = true;
            this.btnGreenDoor.Click += new System.EventHandler(this.btnBlockTool_Click);
            // 
            // btnGreenBox
            // 
            this.btnGreenBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGreenBox.Location = new System.Drawing.Point(12, 306);
            this.btnGreenBox.Margin = new System.Windows.Forms.Padding(2);
            this.btnGreenBox.Name = "btnGreenBox";
            this.btnGreenBox.Size = new System.Drawing.Size(123, 50);
            this.btnGreenBox.TabIndex = 3;
            this.btnGreenBox.Text = "Green Box";
            this.btnGreenBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGreenBox.UseVisualStyleBackColor = true;
            this.btnGreenBox.Click += new System.EventHandler(this.btnBlockTool_Click);
            // 
            // btnWall
            // 
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.Location = new System.Drawing.Point(12, 90);
            this.btnWall.Margin = new System.Windows.Forms.Padding(2);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(123, 50);
            this.btnWall.TabIndex = 2;
            this.btnWall.Text = "            Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.btnBlockTool_Click);
            // 
            // btnNone
            // 
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.Location = new System.Drawing.Point(11, 36);
            this.btnNone.Margin = new System.Windows.Forms.Padding(2);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(123, 50);
            this.btnNone.TabIndex = 1;
            this.btnNone.Text = "None";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnBlockTool_Click);
            // 
            // lblTools
            // 
            this.lblTools.AutoSize = true;
            this.lblTools.Location = new System.Drawing.Point(42, 12);
            this.lblTools.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTools.Name = "lblTools";
            this.lblTools.Size = new System.Drawing.Size(33, 13);
            this.lblTools.TabIndex = 0;
            this.lblTools.Text = "Tools";
            // 
            // menuStripDesign
            // 
            this.menuStripDesign.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripDesign.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripDesign.Location = new System.Drawing.Point(0, 0);
            this.menuStripDesign.Name = "menuStripDesign";
            this.menuStripDesign.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStripDesign.Size = new System.Drawing.Size(708, 24);
            this.menuStripDesign.TabIndex = 1;
            this.menuStripDesign.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // pnlGenerateOptions
            // 
            this.pnlGenerateOptions.AutoSize = true;
            this.pnlGenerateOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGenerateOptions.Controls.Add(this.btnGenerate);
            this.pnlGenerateOptions.Controls.Add(this.tbColumns);
            this.pnlGenerateOptions.Controls.Add(this.tbRows);
            this.pnlGenerateOptions.Controls.Add(this.lblColumns);
            this.pnlGenerateOptions.Controls.Add(this.lblRows);
            this.pnlGenerateOptions.Location = new System.Drawing.Point(0, 25);
            this.pnlGenerateOptions.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGenerateOptions.Name = "pnlGenerateOptions";
            this.pnlGenerateOptions.Size = new System.Drawing.Size(708, 54);
            this.pnlGenerateOptions.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(322, 6);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(87, 40);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tbColumns
            // 
            this.tbColumns.Location = new System.Drawing.Point(188, 17);
            this.tbColumns.Margin = new System.Windows.Forms.Padding(2);
            this.tbColumns.Name = "tbColumns";
            this.tbColumns.Size = new System.Drawing.Size(76, 20);
            this.tbColumns.TabIndex = 3;
            // 
            // tbRows
            // 
            this.tbRows.Location = new System.Drawing.Point(45, 17);
            this.tbRows.Margin = new System.Windows.Forms.Padding(2);
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(76, 20);
            this.tbRows.TabIndex = 2;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(139, 20);
            this.lblColumns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 13);
            this.lblColumns.TabIndex = 1;
            this.lblColumns.Text = "Columns";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(10, 20);
            this.lblRows.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(34, 13);
            this.lblRows.TabIndex = 0;
            this.lblRows.Text = "Rows";
            // 
            // imageListTools
            // 
            this.imageListTools.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListTools.ImageSize = new System.Drawing.Size(50, 50);
            this.imageListTools.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 488);
            this.Controls.Add(this.pnlGenerateOptions);
            this.Controls.Add(this.pnlDesignTools);
            this.Controls.Add(this.menuStripDesign);
            this.MainMenuStrip = this.menuStripDesign;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DesignerForm";
            this.Text = "Designer Form";
            this.Load += new System.EventHandler(this.DesignerForm_Load);
            this.pnlDesignTools.ResumeLayout(false);
            this.pnlDesignTools.PerformLayout();
            this.menuStripDesign.ResumeLayout(false);
            this.menuStripDesign.PerformLayout();
            this.pnlGenerateOptions.ResumeLayout(false);
            this.pnlGenerateOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDesignTools;
        private System.Windows.Forms.SaveFileDialog saveFileDialogDesign;
        private System.Windows.Forms.MenuStrip menuStripDesign;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGenerateOptions;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox tbColumns;
        private System.Windows.Forms.TextBox tbRows;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblTools;
        private System.Windows.Forms.Button btnRedDoor;
        private System.Windows.Forms.Button btnRedBox;
        private System.Windows.Forms.Button btnGreenDoor;
        private System.Windows.Forms.Button btnGreenBox;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.ImageList imageListTools;
    }
}