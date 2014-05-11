using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlavnaForma
{
    public partial class Form3 : Form
    {
        //promenliva za start na drugite tajmeri
        private Int64 tajmerStarter;

        //score
        private int score;

        //score appender
        private int scoreAppender;

        //resenie
        private String resenie;

        List<Zadaca> live;

        private int lifs;

        private bool [] pagjaat;  //za 1/8 - 8/8

        private bool started; //za da znam dali e stratnato za keypress

        Graphics graphics;
        Brush brush;
        Brush brush2;
        Pen pensil;
        Bitmap doubleBuffer;



        public Form3()
        {
            InitializeComponent();
            tajmerStarter = 0;    //inicial zero
            scoreAppender = 10;   //pocetok 10 poeni
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            score = 0;
            resenie = "";
            this.Size = new Size(630, 500);
            this.MinimumSize = new Size(450, 250);
            this.KeyPreview = true;
            live = new List<Zadaca>();
            lifs = 3;
            lif.Text = string.Format("LIVES: {0}", lifs);
            lif.ForeColor = Color.DarkGreen;
            pagjaat = new bool[5];
            
            //tajmer za start i odzemanje vreme
            timer1.Interval = 100; 
            
            //tajmer za paganjata        
            timer2.Interval = 100;
           
            //labela1 za your score:
            label1.Text = "Your score: 0";

            button15.Focus();

            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();
            brush = new SolidBrush(Color.SkyBlue);
            brush2 = new SolidBrush(Color.White);
            pensil = new Pen(Color.White);

            started = false;
        }

        

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
            panel1.Invalidate();
            panel2.Invalidate();

            //namesti desno panela1
            panel1.Location = new System.Drawing.Point(5 * (int)(this.Width / 7.5), 0);
            panel1.Size = new System.Drawing.Size(this.Width - (5 * (int)(this.Width / 7.5)) - 10, this.Height);

            //namesti panela dole desno
            panel2.Location = new System.Drawing.Point(0, this.Height-70);
            panel2.Size = new System.Drawing.Size(panel1.Width, 32);

            //button1
            button1.Height = panel2.Height - 5;
            button1.Width = button1.Height;

            //button2
            button2.Width = button1.Width;
            button2.Height = button1.Height;

            //lif - labela za zivoti levo
            lif.Location = new System.Drawing.Point(5, 6);

            //btn_start
            btn_start.Location = new System.Drawing.Point((int)this.Width / 4, (int)(this.Height/3) - 5);

            button2.Location = new System.Drawing.Point(panel2.Width - button2.Width - 10, 4);
            button1.Location = new System.Drawing.Point(panel2.Width - 2*button2.Width - 15, 4);

            //golemina na font na label1
            if (this.Width < 550)
                this.label1.Font = new System.Drawing.Font("Castellar", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            else
                this.label1.Font = new System.Drawing.Font("Castellar", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            label1.Size = new System.Drawing.Size((int)(panel1.Width - 35), 34);
            int w = label1.Width;
            int w2 = panel1.Width - w;
            int ras = (int)(w2 / 2)-3;
            label1.Location = new System.Drawing.Point(ras, (int)(this.Height / 19));
           
            
            //groupbox
            w = groupBox1.Width;
            w2 = panel1.Width - w;
            ras = (int)(w2 / 3);

            if (w2 > 5)
            {
                groupBox1.Show();
                groupBox1.Location = new System.Drawing.Point(ras, (int)(this.Height / 5));
                textBox2.Hide();
                button16.Hide();
            }
            else
            {
                groupBox1.Hide();
                textBox2.Show();
                this.textBox2.Size = new System.Drawing.Size(panel1.Width - 18, 20);
                textBox2.Location = new System.Drawing.Point(5, (int)(this.Height / 5));
                textBox1.TabIndex = 0;
                button16.Show();
                button16.Focus();
                button16.Location = new System.Drawing.Point(panel1.Width - 12 - button16.Width, (int)(this.Height / 5)+25);
            }

            panel3.Location = new System.Drawing.Point(0,8*(int)(this.Height/10));
            panel3.Size = new System.Drawing.Size((5 * (int)(this.Width / 7.5)) , this.Height);

            button15.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Form1_SizeChanged(this, new EventArgs());

            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.button2, "Help and Rules");
            toolTip1.SetToolTip(this.button1, "Pause/Play");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tajmerStarter++;

            if(this.tajmerStarter == 30)
                lbl_ups.Text="";

            if (this.tajmerStarter == 10)
            {
                int a = -1;
                while(a==-1){
                    Random r = new Random();
                    int k = r.Next()%5;
                    if (pagjaat[k] == false)
                    {
                        a = k;
                        pagjaat[k] = true;
                    }
                }
                Zadaca zz = new Zadaca(1,a);
                live.Add(zz);
                label2.Text = zz.o;
                label3.Text = zz.s;
                label2.Location = new System.Drawing.Point((zz.kojred+1) * (int)((this.Width / 8.7)), 20);
                label3.Location = new System.Drawing.Point((zz.kojred + 1) * (int)((this.Width / 8.7)) + 15, 15);
                
                timer2.Start();
            }
            
            else if (this.tajmerStarter == 350){     //35 sec najubavo
                int a = -1;
                while (a == -1)
                {
                    Random r = new Random();
                    int k = r.Next() % 5;
                    if (pagjaat[k] == false)
                    {
                        a = k;
                        pagjaat[k] = true;
                    }
                }
                Zadaca zz = new Zadaca(2,a);
                live.Add(zz);
                label4.Text = zz.o;
                label5.Text = zz.s;                
                label4.Location = new System.Drawing.Point((zz.kojred+1) * (int)((this.Width / 8.7)), 20);
                label5.Location = new System.Drawing.Point((zz.kojred + 1) * (int)((this.Width / 8.7)) + 15, 15);
                //timer3.Start();
             }

            else if (this.tajmerStarter == 600){    //60 sec najubavo
                int a = -1;
                while (a == -1)
                {
                    Random r = new Random();
                    int k = r.Next() % 5;
                    if (pagjaat[k] == false)
                    {
                        a = k;
                        pagjaat[k] = true;
                    }
                }
                Zadaca zz = new Zadaca(3,a);
                live.Add(zz);
                label6.Text = zz.o;
                label7.Text = zz.s;
                label6.Location = new System.Drawing.Point((zz.kojred + 1) * (int)((this.Width / 8.7)), 20);
                label7.Location = new System.Drawing.Point((zz.kojred + 1) * (int)((this.Width / 8.7)) + 15, 15);
                //timer4.Start();
            }

            foreach (Zadaca z in live)
            {
                z.tajmerce -= 100;
                
                if (z.tajmerce == 0)
                {
                    lifs--;
                    lif.Text = string.Format("LIVES: {0}", lifs);
                    if(lifs==2)
                        lif.ForeColor = Color.DarkGoldenrod;
                    else if(lifs==1)
                        lif.ForeColor = Color.DarkRed;
                    
                    tajmerStarter=0;
                    live.Clear();
                    //live = new List<Zadaca>();

                    label2.Text = "";
                    label3.Text = ""; 
                    label4.Text = "";           
                    label5.Text = "";           
                    label6.Text = "";          
                    label7.Text = "";           
                    lbl_ups.Text = "OOPS..";
                    for (int i = 0; i < 5; i++)
                        pagjaat[i] = false;
                    
                    break;
                }
            }
            
            

            if (lifs == 0) {
                lif.ForeColor = Color.Red;
                timer1.Stop();
                timer2.Stop();
                live.Clear();
                tajmerStarter = 0;
                label2.Text = "";           //brisi
                label3.Text = "";           //brisi
                label4.Text = "";           //brisi
                label5.Text = "";           //brisi
                label6.Text = "";           //brisi
                label7.Text = ""; 
                lbl_ups.Text = "";             //istoo...
                started = false;
                btn_start.Show();
                
                Graphics g = Graphics.FromImage(doubleBuffer);
                g.Clear(Color.White);
                graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
                MessageBox.Show(label1.Text, "GAME OVER");
                label1.Text = string.Format("FINISHED");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "5";
                else resenie += "5";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //enter
            this.pomosna();
        }    //enter

        private void button6_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "4";
                else resenie += "4";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "7";
                else resenie += "7";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "8";
                else resenie += "8";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "9";
                else resenie += "9";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "6";
                else resenie += "6";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "1";
                else resenie += "1";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "2";
                else resenie += "2";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "3";
                else resenie += "3";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (resenie == "")
                    resenie = "0";
                else resenie += "0";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //delete
            if (started)
            {
                if (resenie == "")
                    resenie = "";
                else resenie = resenie.Substring(0, resenie.Length - 1);
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //clear
            if (started)
            {
                resenie = "";
                textBox1.Text = resenie;
                textBox2.Text = resenie;
            }
            button15.Focus();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(started)
            switch (e.KeyChar)
            {
                case '0':
                    this.button12_Click(this, new EventArgs());
                    break;
                case '1':
                    this.button9_Click(this, new EventArgs());
                    break;
                case '2':
                    this.button10_Click(this, new EventArgs());
                    break;
                case '3':
                    this.button11_Click(this, new EventArgs());
                    break;
                case '4':
                    this.button6_Click(this, new EventArgs());
                    break;
                case '5':
                    this.button7_Click(this, new EventArgs());
                    break;
                case '6':
                    this.button8_Click(this, new EventArgs());
                    break;
                case '7':
                    this.button3_Click(this, new EventArgs());
                    break;
                case '8':
                    this.button4_Click(this, new EventArgs());
                    break;
                case '9':
                    this.button5_Click(this, new EventArgs());
                    break;
                case (char)Keys.Back:
                    this.button13_Click(this, new EventArgs());
                    break;
                case (char)Keys.Delete:
                    this.button13_Click(this, new EventArgs());
                    break;
                case (char)Keys.Enter:
                    this.button15_Click(this, new EventArgs());
                    break;
                case (char)Keys.Tab:
                    e.KeyChar = 'a';
                    break;
                default:
                    button15.Focus();
                    break;
                /*case (char)Keys.Space:
                    this.button15_Click(this, new EventArgs());
                    break;*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!started)
                MessageBox.Show("In this game, it's important not to let the raindrop fall on the ground. In order to do that, you have to answer the equation the drop holds correctly, thus destroying the drop.\n\nYou get 10 points for the first correct answer, adding 1 to that for each next one and lose 10 points for each incorrect answer.\n\nMade by: Robert Andonovski", "Help and Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }               //help

        private void button1_Click(object sender, EventArgs e)                  //pause/play
        {
            if (button1.Text == "| |" && started)
            {
                timer1.Stop();
                timer2.Stop();
                button1.Text = ">>";
                started = false;
            }
            else if(button1.Text == ">>")
            {
                timer1.Start();
                timer2.Start();
                button1.Text = "| |";
                started = true;
            }
            button15.Focus();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //this.Invalidate();
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.White);
           

            //System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.SkyBlue);
            //System.Drawing.Graphics formGraphics;
            //formGraphics = this.CreateGraphics();
            
            int koj=-1;
            int taj = -1;
            foreach (Zadaca z in live)
            {
                if (z.level == 1){
                    koj = z.kojred;
                    taj = z.tajmerce;
                }
            }
            if (koj != -1)
            {
                koj+=1;//za da nema nula
                
                //label2.Location = new System.Drawing.Point(koj * (int)((this.Width / 8.7)), (int)((10000 - taj)/(double)1000 *  (7* this.Height / 96))+20);
                //label3.Location = new System.Drawing.Point(koj * (int)((this.Width / 8.7 )) + 15,(int)((10000 - taj)/(double)1000 *  (7* this.Height / 96)) + 15);

                label2.Hide();
                label3.Hide();
                
                Font fon = new Font("Castellar", 12F, FontStyle.Bold);
                g.FillEllipse(brush, new Rectangle(koj * (int)((this.Width / 8.7)) - 8, (int)((10000 - taj) / (double)1000 * (7 * this.Height / 96)) + 2, 65, 65));
                g.DrawString(label3.Text.ToString(), fon, brush2, new Point(koj * (int)((this.Width / 8.7)) + 15, (int)((10000 - taj) / (double)1000 * (7 * this.Height / 96)) + 15));
                g.DrawString(label2.Text.ToString(), fon, brush2, new Point(koj * (int)((this.Width / 8.7)), (int)((10000 - taj)/(double)1000 *  (7* this.Height / 96))+20));
                
                //g = this.CreateGraphics();
            }
            //myBrush.Dispose();
            //formGraphics.Dispose();

            //System.Drawing.SolidBrush myBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.SkyBlue);
            //System.Drawing.Graphics formGraphics2 = this.CreateGraphics();
            
            koj = -1;
            taj = -1;
            foreach (Zadaca z in live)
            {
                if (z.level == 2)
                {
                    koj = z.kojred;
                    taj = z.tajmerce;
                }
            }
            if (koj != -1)
            {
                koj += 1;//za da nema nula
                //label4.Location = new System.Drawing.Point(koj * (int)((this.Width / 8.7)), (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 20);
                //label5.Location = new System.Drawing.Point(koj * (int)((this.Width / 8.7)) + 15, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 15);
                
            
                label4.Hide();
                label5.Hide();
                
                Font fon = new Font("Castellar", 12F, FontStyle.Bold);
                g.FillEllipse(brush, new Rectangle(koj * (int)((this.Width / 8.7)) - 8, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 2, 65, 65));  
                g.DrawString(label4.Text.ToString(), fon, brush2, new Point(koj * (int)((this.Width / 8.7)), (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 20));
                g.DrawString(label5.Text.ToString(), fon, brush2, new Point(koj * (int)((this.Width / 8.7)) + 15, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 15));
                
            
            
            }

            //myBrush2.Dispose();
            //formGraphics2.Dispose();

            //System.Drawing.SolidBrush myBrush3 = new System.Drawing.SolidBrush(System.Drawing.Color.SkyBlue);
            //System.Drawing.Graphics formGraphics3 = this.CreateGraphics();

            koj = -1;
            taj = -1;
            foreach (Zadaca z in live)
            {
                if (z.level == 3)
                {
                    koj = z.kojred;
                    taj = z.tajmerce;
                }
            }
            if (koj != -1)
            {
                koj += 1;//za da nema nula
                
                //label6.Location = new System.Drawing.Point(koj * (int)((this.Width / 8.7)), (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 20);
                //label7.Location = new System.Drawing.Point(koj * (int)((this.Width / 8.7)) + 15, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 15);
                //g.FillEllipse(brush, new Rectangle(koj * (int)((this.Width / 8.7)) - 6, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 5, 65, 65));


                label6.Hide();
                label7.Hide();

                Font fon = new Font("Castellar", 12F, FontStyle.Bold);
                g.FillEllipse(brush, new Rectangle(koj * (int)((this.Width / 8.7)) - 6, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 2, 65, 65));
                g.DrawString(label6.Text.ToString(), fon, brush2, new Point(koj * (int)((this.Width / 8.7)), (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 20));
                g.DrawString(label7.Text.ToString(), fon, brush2, new Point(koj * (int)((this.Width / 8.7)) + 15, (int)((8000 - taj) / (double)800 * (7 * this.Height / 96)) + 15));
                
            }

            //myBrush3.Dispose();
            //formGraphics.Dispose();
            try
            {
                graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
            }
            catch { 
                
            }
        }                   //brisi

        

        private void btn_start_Click(object sender, EventArgs e)                // START
        {
            lifs = 3;
            lif.Text = string.Format("LIVES: {0}", lifs);
            lif.ForeColor = Color.DarkGreen;
            tajmerStarter = 0;
            for (int i = 0; i < 5; i++)
                pagjaat[i] = false;
            timer1.Start();
            btn_start.Hide();
            started = true;
            scoreAppender = 10;
            score = 0;
            label1.Text = string.Format("Your score: {0}", score);

            button15.Focus();

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            button15.Focus();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            button15.Focus();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.pomosna();
        }



        private void pomosna() {

            if (resenie.Length == 0) return;
            int r = int.Parse(resenie);
            bool da = false;
            List<Zadaca> brisi = new List<Zadaca>();
            if (live.Count != 0)
                foreach (Zadaca z in live)
                {
                    if (z.result == r)
                    {
                        score += scoreAppender;
                        scoreAppender++;
                        label1.Text = string.Format("Your score: {0}", score);
                        brisi.Add(z);
                        da = true;
                    }

                }
            if (da)
            {
                foreach (Zadaca z in brisi)
                {
                    if (z.level == 1)
                    {
                        int a = -1;
                        while (a == -1)
                        {
                            Random q = new Random();
                            int k = q.Next() % 5;
                            if (pagjaat[k] == false)
                            {
                                a = k;
                                pagjaat[k] = true;
                            }
                        }
                        Zadaca zz = new Zadaca(1, a);
                        live.Add(zz);
                        label2.Text = zz.o;
                        label3.Text = zz.s;
                    }
                    else if (z.level == 2)
                    {
                        int a = -1;
                        while (a == -1)
                        {
                            Random q = new Random();
                            int k = q.Next() % 5;
                            if (pagjaat[k] == false)
                            {
                                a = k;
                                pagjaat[k] = true;
                            }
                        }
                        Zadaca zz = new Zadaca(2, a);
                        live.Add(zz);
                        label4.Text = zz.o;
                        label5.Text = zz.s;
                    }
                    else if (z.level == 3)
                    {
                        int a = -1;
                        while (a == -1)
                        {
                            Random q = new Random();
                            int k = q.Next() % 5;
                            if (pagjaat[k] == false)
                            {
                                a = k;
                                pagjaat[k] = true;
                            }
                        }
                        Zadaca zz = new Zadaca(3, a);
                        live.Add(zz);
                        label6.Text = zz.o;
                        label7.Text = zz.s;
                    }
                    pagjaat[z.kojred] = false;
                    live.Remove(z);
                }
            }
            if (!da)
            {
                score -= scoreAppender;
                if (score < 0) score = 0;
                label1.Text = string.Format("Your score: {0}", score);
                //this.Invalidate();
            }

            button14_Click(this, new EventArgs());
        }

        
     

        
    }
}
