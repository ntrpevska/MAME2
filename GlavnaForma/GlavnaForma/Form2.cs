using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlavnaForma
{
    public partial class Form2 : Form
    {
        private Game gam;
        public int time { get; set; }
        int temp = 0;
        bool paused = false;

        public Form2()
        {
            InitializeComponent();
            ClearFields();
            StartGame();
            
            btnStart.Focus();
        }


        //
        //START GAME
        //
        public void StartGame()
        {
            ClearFields();
            FasterTimer.Start();
            pnlButtons.Controls.Clear();
            gam = new Game(16, 16, pnlButtons, NormalTimer);

            ResetTimer();

            //if (gam.isGameOver)
            //{
            //    //gam.Explode += new EventHandler(gam_Explode);
            //}
        }
        //
        //END OF START GAME
        //


        //START OF EVENTS
        void gam_Explode(object sender, EventArgs e)
        {
            FasterTimer.Stop();
            NormalTimer.Stop();
            //pnlButtons.Controls.Clear();
            string st = string.Format("It appears you have failed.\nMines left: {0}\n\nNew Game?", Game.mines - gam.dismantledMines);
            DialogResult r = MessageBox.Show(st, "Game over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop);
            if (r == DialogResult.Yes)
            {
                pnlButtons.Controls.Clear();
                StartGame();
            }
            else
            {
                Close();
            }
        }
        
        void gam_Win(object sender, EventArgs e)
        {
            FasterTimer.Stop();
            NormalTimer.Stop();
            //pnlButtons.Controls.Clear();
            string st = string.Format("It appears you have won. How nice.\n\nTime: {0} seconds\nMines left: {1}\n\nNew Game?", time, Game.mines - gam.dismantledMines);
            DialogResult r = MessageBox.Show(st, "Game over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                pnlButtons.Controls.Clear();
                StartGame();
            }
            else
            {
                Close();
            }
        }
        //END OF EVENTS


        public void ClearFields()
        {
            tbBombs.Clear();
            tbTime.Clear();
        }

        public void ResetTimer()
        {
            NormalTimer.Stop();
            NormalTimer.Start();
            time = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                btnStart.Enabled = true;
                StartGame();
            }
        }


        //TIMERS
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            tbTime.Text = time.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tbBombs.Text = (Game.mines - gam.dismantledMines).ToString();

            if (gam.isGameBADLYover)
            {
                gam_Explode(sender, e);
                //timer2.Stop();
                //timer1.Stop();
                ////pnlButtons.Controls.Clear();
                //string st = string.Format("It appears you have failed.\nMines left: {0}\n\nNew Game?", Game.mines - gam.dismantledMines);
                //DialogResult r = MessageBox.Show(st, "Game over",
                //        MessageBoxButtons.YesNo,
                //        MessageBoxIcon.Stop);
                //if (r == DialogResult.Yes)
                //{
                //    pnlButtons.Controls.Clear();
                //    StartGame();
                //}
                //else
                //{
                //    Close();
                //}
            }

            if (gam.isGameOver)
            {
                gam_Win(sender, e);
                //timer2.Stop();
                //timer1.Stop();
                ////pnlButtons.Controls.Clear();
                //string st = string.Format("It appears you have won. How nice.\n\nTime: {0} seconds\nMines left: {1}\n\nNew Game?", time, Game.mines - gam.dismantledMines);
                //DialogResult r = MessageBox.Show(st, "Game over",
                //        MessageBoxButtons.YesNo,
                //        MessageBoxIcon.Information);
                //if (r == DialogResult.Yes)
                //{
                //    pnlButtons.Controls.Clear();
                //    StartGame();
                //}
                //else
                //{
                //    Close();
                //}
            }
        }
        //END OF TIMERS


        //TOOLSTRIPITEMS
        private void aboutTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credits c = new Credits();
            //temp++;
            if (!paused)
            {
                pauseBtn_Click(sender, e);
                //NormalTimer.Stop();
                c.ShowDialog();
                //if (c.DialogResult == DialogResult.Cancel) NormalTimer.Start();
            }
            else { c.ShowDialog(); }
        }

        private void howToPlayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Instructions i = new Instructions();
            //temp++;
            if (!paused)
            {
                pauseBtn_Click(sender, e);
                //NormalTimer.Stop();
                i.ShowDialog();
                //if (i.DialogResult == DialogResult.Cancel) NormalTimer.Start();
            }
            else { i.ShowDialog(); }
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you want to close the game?", "Warning!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes) { Close(); }
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            temp++;
            paused = true;
            NormalTimer.Stop();
            pnlButtons.Enabled = false;
            pauseBtn.Text = "Unpause";
            btnStart.Enabled = false;
            newGameToolStripMenuItem1.Enabled = false;
            if (temp % 2 == 0)
            {
                NormalTimer.Start();
                pnlButtons.Enabled = true;
                pauseBtn.Text = "Pause";
                paused = false;
                btnStart.Enabled = true;
                newGameToolStripMenuItem1.Enabled = true;
            }
        }

        

        //END OF TOOLSTRIPITEMS

    }
}
