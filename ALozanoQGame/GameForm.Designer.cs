namespace ALozanoQGame
{
    partial class GameForm
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
            this.menuStripGame = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.pbPostionRef = new System.Windows.Forms.PictureBox();
            this.pnlTiles = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMovesNumber = new System.Windows.Forms.TextBox();
            this.tbRemainingBoxes = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.menuStripGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPostionRef)).BeginInit();
            this.pnlTiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripGame
            // 
            this.menuStripGame.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripGame.Location = new System.Drawing.Point(0, 0);
            this.menuStripGame.Name = "menuStripGame";
            this.menuStripGame.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStripGame.Size = new System.Drawing.Size(955, 28);
            this.menuStripGame.TabIndex = 0;
            this.menuStripGame.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // pbPostionRef
            // 
            this.pbPostionRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPostionRef.Location = new System.Drawing.Point(40, 37);
            this.pbPostionRef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPostionRef.Name = "pbPostionRef";
            this.pbPostionRef.Size = new System.Drawing.Size(101, 96);
            this.pbPostionRef.TabIndex = 2;
            this.pbPostionRef.TabStop = false;
            this.pbPostionRef.Visible = false;
            // 
            // pnlTiles
            // 
            this.pnlTiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTiles.Controls.Add(this.pbPostionRef);
            this.pnlTiles.Location = new System.Drawing.Point(16, 48);
            this.pnlTiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(663, 474);
            this.pnlTiles.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(731, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Moves";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of Remaining Boxes";
            // 
            // tbMovesNumber
            // 
            this.tbMovesNumber.Enabled = false;
            this.tbMovesNumber.Location = new System.Drawing.Point(735, 71);
            this.tbMovesNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMovesNumber.Name = "tbMovesNumber";
            this.tbMovesNumber.Size = new System.Drawing.Size(132, 22);
            this.tbMovesNumber.TabIndex = 7;
            // 
            // tbRemainingBoxes
            // 
            this.tbRemainingBoxes.Enabled = false;
            this.tbRemainingBoxes.Location = new System.Drawing.Point(735, 146);
            this.tbRemainingBoxes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRemainingBoxes.Name = "tbRemainingBoxes";
            this.tbRemainingBoxes.Size = new System.Drawing.Size(132, 22);
            this.tbRemainingBoxes.TabIndex = 8;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(784, 330);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(73, 58);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(784, 395);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(73, 58);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(865, 395);
            this.btnRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(73, 58);
            this.btnRight.TabIndex = 11;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(703, 395);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(73, 58);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 538);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.tbRemainingBoxes);
            this.Controls.Add(this.tbMovesNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlTiles);
            this.Controls.Add(this.menuStripGame);
            this.MainMenuStrip = this.menuStripGame;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.menuStripGame.ResumeLayout(false);
            this.menuStripGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPostionRef)).EndInit();
            this.pnlTiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripGame;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.PictureBox pbPostionRef;
        private System.Windows.Forms.Panel pnlTiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMovesNumber;
        private System.Windows.Forms.TextBox tbRemainingBoxes;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
    }
}