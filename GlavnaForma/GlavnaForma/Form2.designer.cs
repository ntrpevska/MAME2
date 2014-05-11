namespace GlavnaForma
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbBombs = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.NormalTimer = new System.Windows.Forms.Timer(this.components);
            this.FasterTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.aboutTheGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseBtn = new System.Windows.Forms.ToolStripButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTime
            // 
            this.tbTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTime.Location = new System.Drawing.Point(66, 444);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(70, 48);
            this.tbTime.TabIndex = 0;
            this.tbTime.Text = "000";
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBombs
            // 
            this.tbBombs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBombs.Location = new System.Drawing.Point(310, 444);
            this.tbBombs.Name = "tbBombs";
            this.tbBombs.ReadOnly = true;
            this.tbBombs.Size = new System.Drawing.Size(70, 48);
            this.tbBombs.TabIndex = 3;
            this.tbBombs.Text = "000";
            this.tbBombs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtons.Location = new System.Drawing.Point(23, 32);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(400, 400);
            this.pnlButtons.TabIndex = 5;
            // 
            // NormalTimer
            // 
            this.NormalTimer.Interval = 1000;
            this.NormalTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FasterTimer
            // 
            this.FasterTimer.Interval = 1;
            this.FasterTimer.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.pauseBtn});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(446, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(75, 22);
            this.toolStripDropDownButton1.Text = "Game";
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.newGameToolStripMenuItem1.Text = "New Game";
            this.newGameToolStripMenuItem1.Click += new System.EventHandler(this.newGameToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTheGameToolStripMenuItem,
            this.howToPlayToolStripMenuItem1});
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(50, 22);
            this.toolStripDropDownButton2.Text = "Help";
            // 
            // aboutTheGameToolStripMenuItem
            // 
            this.aboutTheGameToolStripMenuItem.Name = "aboutTheGameToolStripMenuItem";
            this.aboutTheGameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutTheGameToolStripMenuItem.Text = "About the Game";
            this.aboutTheGameToolStripMenuItem.Click += new System.EventHandler(this.aboutTheGameToolStripMenuItem_Click);
            // 
            // howToPlayToolStripMenuItem1
            // 
            this.howToPlayToolStripMenuItem1.Name = "howToPlayToolStripMenuItem1";
            this.howToPlayToolStripMenuItem1.Size = new System.Drawing.Size(179, 22);
            this.howToPlayToolStripMenuItem1.Text = "How to Play?";
            this.howToPlayToolStripMenuItem1.Click += new System.EventHandler(this.howToPlayToolStripMenuItem1_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
            this.pauseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(68, 22);
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Image = global::GlavnaForma.Properties.Resources.bigsmile2;
            this.btnStart.Location = new System.Drawing.Point(193, 444);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(61, 48);
            this.btnStart.TabIndex = 6;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GlavnaForma.Properties.Resources.Minesweeper_Icon;
            this.pictureBox2.Location = new System.Drawing.Point(386, 444);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GlavnaForma.Properties.Resources.clock;
            this.pictureBox1.Location = new System.Drawing.Point(12, 444);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(446, 504);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.tbBombs);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbBombs;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Timer NormalTimer;
        private System.Windows.Forms.Timer FasterTimer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem aboutTheGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton pauseBtn;
        private System.Windows.Forms.Button btnStart;
    }
}

