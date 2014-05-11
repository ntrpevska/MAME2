using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GlavnaForma
{
    class Game
    {
        //public event EventHandler DismantledMinesChanged;
        //public event EventHandler Explode;

        public Square[,] squares { get; set; } //2D ARRAY OF SQUARES

        public static readonly int mines = 40;  //TOTAL NUMBER OF MINES
        public bool isGameOver { get; set; }    //IS THE GAME OVER
        public int falselyDisMines { get; set; }    //FALSELY DISMANTLED MINES
        public int dismantledMines { get; set; }    //DISMANTLED MINES (CORRECTLY)
        public int height { get; set; } //NUMBER OF SQUARES VERTICALLY
        public int width { get; set; }  //NUMBER OF SQUARES HORIZONTALLY
        public int time { get; set; }   //TIME

        public int posX { get; set; }   //X COORDINATE OF THE CLICKED BUTTON
        public int posY { get; set; }   //Y COORDINATE OF THE CLICKED BUTTON

        public Panel panel { get; set; }    //PANEL ON WHICH THE BUTTONS ARE ADDED
        public Timer timer { get; set; }    //TIMER WHICH TICKS

        public int openedButtons { get; set; }
        public bool isGameBADLYover { get; set; }
//................................................................................................

        public Game() { } //EMPTY CONSTRUCTOR JIC

        //CONSTRUCTOR W/T ARGUMENTS
        public Game(int w, int h, Panel pnl, Timer tim)
        {
            panel = new Panel();
            //timer = new Timer();
            timer = tim;
            panel = pnl;
            //mines = 40;
            height = h;
            width = w;
            isGameOver = false;
            isGameBADLYover = false;
            openedButtons = 0;
            time = 0;
            dismantledMines = 0;
            falselyDisMines = 0;

            squares = new Square[width , height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    squares[i, j] = new Square();
                }
            }

            //ADDING BUTTONS
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    squares[i, j].button = new Button();
                    Button b = squares[i, j].button;
                    panel.Controls.Add(b);
                    b.Location = new System.Drawing.Point(i * 25, j * 25);
                    b.Size = new Size(25,25);
                    b.Font = new Font(b.Font, FontStyle.Bold);
                    b.BackColor = Color.Teal;
                    b.FlatStyle = FlatStyle.Popup;
                    b.MouseDown += new MouseEventHandler(b_MouseDown);
                }
            }
            //end of ADDING BUTTONS

            //ADDING MINES
            int t = 0;
            Random r = new Random();

            while (t < mines)
            {
                int x = r.Next(width);
                int y = r.Next(height);

                Square s = squares[x, y];

                if (!s.hasMine)
                {
                    s.hasMine = true;
                    t++;
                }
            }
            //end of ADDING MINES

        }
        //end of CONSTRUCTOR

//................................................................................................

        //EVENT: mousedown
        void b_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = panel.PointToClient(Cursor.Position);
            posX = point.X / 25;
            posY = point.Y / 25;

            

            if (!squares[posX, posY].opened && e.Button == MouseButtons.Right)
            {
                //squares[posX, posY].dismantled = true;
                if (squares[posX, posY].dismantled)
                {
                    dismantledMines--;
                    if (squares[posX, posY].dismantled && !squares[posX, posY].hasMine) { falselyDisMines++; }
                    squares[posX, posY].dismantled = false;
                    squares[posX, posY].button.BackColor = Color.Teal;
                }
                else
                {
                    squares[posX, posY].dismantled = true;
                    dismantledMines++;
                    squares[posX, posY].button.BackColor = Color.DarkSeaGreen;
                }

                if (openedButtons > 216)
                {
                    if (dismantledMines == mines)
                    isGameOver = true;
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                //timer.Stop();
                //timer.Start();
                
                if (!squares[posX, posY].dismantled)
                {
                    OpenSquare(posX,posY);
                    squares[posX, posY].button.Enabled = false;
                    squares[posX, posY].button.BackColor = Color.White;

                    if (squares[posX, posY].hasMine)
                    {
                        squares[posX, posY].button.BackColor = Color.Crimson;
                        squares[posX, posY].button.Text = "#";
                        isGameBADLYover = true;

                        //panel.Controls.Clear();
                    }
                    else
                    {

                    }
                }
            }

        }
        //end of EVENT: mousedown

        //OPEN SQUARE WITH THE NUMBERS AND STUFF AROUND IT
        public void OpenSquare(int posX, int posY)
        {
            openedButtons++;
            Point point = panel.PointToClient(Cursor.Position);
            posX = point.X / 25;
            posY = point.Y / 25;

            if (!squares[posX, posY].opened && !squares[posX, posY].dismantled)
            {
                squares[posX, posY].opened = true;

                int c = 0;

                //if(posX>0 && posX<width && posY >0 && posY<height)
                //if (squares[posX, posY].hasMine) c++;

                if (posX >= 0 && posX < width && posY+1 >= 0 && posY+1 < height)
                if (squares[posX, posY + 1].hasMine) c++;

                if (posX >= 0 && posX < width && posY-1 >= 0 && posY-1 < height)
                if (squares[posX, posY - 1].hasMine) c++;

                if (posX+1 >= 0 && posX+1 < width && posY >= 0 && posY < height)
                if (squares[posX + 1, posY].hasMine) c++;
                
                if (posX+1 >= 0 && posX+1 < width && posY+1 >= 0 && posY+1 < height)
                if (squares[posX + 1, posY + 1].hasMine) c++;

                if (posX+1 >= 0 && posX+1 < width && posY-1 >= 0 && posY-1 < height)
                if (squares[posX + 1, posY - 1].hasMine) c++;

                if (posX-1 >= 0 && posX-1 < width && posY >= 0 && posY < height)
                if (squares[posX - 1, posY].hasMine) c++;

                if (posX-1 >= 0 && posX-1 < width && posY+1 >= 0 && posY+1 < height)
                if (squares[posX - 1, posY + 1].hasMine) c++;

                if (posX-1 >= 0 && posX-1 < width && posY-1 >=0 && posY-1 < height)
                if (squares[posX - 1, posY - 1].hasMine) c++;

                if (c == 0)
                {
                    OpenAround(posX, posY);
                    
                }

                if (c > 0)
                {
                    squares[posX, posY].button.Text = c.ToString();

                    squares[posX, posY].colorUpdate();
                }
                else
                {
                    squares[posX, posY].button.Enabled = true;
                }
            }
        }
        //END OF OPENSQUARE


        //START OF OPENAROUND
        public void OpenAround(int posX, int posY)
        {
            //squares[posX, posY].opened = true;
            openedButtons++;

            if (!(posX >= 0 && posX < width && posY >= 0 && posY < height))
               return;

            if (squares[posX , posY].hasMine)
                return;

            int c = 0;


            if (posX >= 0 && posX < width && posY + 1 >= 0 && posY + 1 < height)
                if (squares[posX, posY + 1].hasMine) c++;

            if (posX >= 0 && posX < width && posY - 1 >= 0 && posY - 1 < height)
                if (squares[posX, posY - 1].hasMine) c++;

            if (posX + 1 >= 0 && posX + 1 < width && posY >= 0 && posY < height)
                if (squares[posX + 1, posY].hasMine) c++;

            if (posX + 1 >= 0 && posX + 1 < width && posY + 1 >= 0 && posY + 1 < height)
                if (squares[posX + 1, posY + 1].hasMine) c++;

            if (posX + 1 >= 0 && posX + 1 < width && posY - 1 >= 0 && posY - 1 < height)
                if (squares[posX + 1, posY - 1].hasMine) c++;

            if (posX - 1 >= 0 && posX - 1 < width && posY >= 0 && posY < height)
                if (squares[posX - 1, posY].hasMine) c++;

            if (posX - 1 >= 0 && posX - 1 < width && posY + 1 >= 0 && posY + 1 < height)
                if (squares[posX - 1, posY + 1].hasMine) c++;

            if (posX - 1 >= 0 && posX - 1 < width && posY - 1 >= 0 && posY - 1 < height)
                if (squares[posX - 1, posY - 1].hasMine) c++;

            if (c != 0)
            {
                squares[posX, posY].button.Text = c.ToString();

            }
            squares[posX, posY].colorUpdate();
            squares[posX, posY].opened = true;

            if (c == 0)
            {

                /*   SHEMA:
                _________________
               |                 |
               |  0  |  1  |  2  |       
               |_________________|
               |                 |
               |  7  |  X  |  3  |   
               |_________________|
               |                 |
               |  6  |  5  |  4  |              
               |_________________|
                
                 */
                if (!(posX >= 0 && posX < width && posY >= 0 && posY < height))
                    return;

            if (posX >= 0 && posX < width && posY + 1 >= 0 && posY + 1 < height)
                if (!squares[posX, posY + 1].hasMine && squares[posX , posY+1].opened == false)
                {
                    OpenAround(posX, posY + 1);
                }

            if (posX >= 0 && posX < width && posY - 1 >= 0 && posY - 1 < height)
                if (!squares[posX, posY - 1].hasMine && squares[posX , posY-1].opened == false)
                {
                    OpenAround(posX, posY - 1);
                }

            if (posX + 1 >= 0 && posX + 1 < width && posY >= 0 && posY < height)
                if (!squares[posX + 1, posY].hasMine && squares[posX + 1, posY].opened == false)
                {
                    OpenAround(posX+1, posY);
                }

            if (posX + 1 >= 0 && posX + 1 < width && posY + 1 >= 0 && posY + 1 < height)
                if (!squares[posX + 1, posY + 1].hasMine && squares[posX + 1, posY+1].opened == false)
                {
                    OpenAround(posX+1, posY + 1);
                }

            if (posX + 1 >= 0 && posX + 1 < width && posY - 1 >= 0 && posY - 1 < height)
                if (!squares[posX + 1, posY - 1].hasMine && squares[posX + 1, posY-1].opened == false)
                {
                    OpenAround(posX+1, posY - 1);
                }

            if (posX - 1 >= 0 && posX - 1 < width && posY >= 0 && posY < height)
                if (!squares[posX - 1, posY].hasMine && squares[posX - 1, posY].opened == false)
                {
                    OpenAround(posX-1, posY);
                }

            if (posX - 1 >= 0 && posX - 1 < width && posY + 1 >= 0 && posY + 1 < height)
                if (!squares[posX - 1, posY + 1].hasMine && squares[posX - 1, posY + 1].opened == false)
                {
                    OpenAround(posX-1, posY + 1);
                }

            if (posX - 1 >= 0 && posX - 1 < width && posY - 1 >= 0 && posY - 1 < height)
                if (!squares[posX - 1, posY - 1].hasMine && squares[posX - 1, posY - 1].opened == false)
                {
                    OpenAround(posX-1, posY - 1);
                }

            //OpenAround(posX - 1, posY);
            //OpenAround(posX - 1, posY + 1);
            //OpenAround(posX - 1, posY - 1);
            //OpenAround(posX + 1, posY);
            //OpenAround(posX + 1, posY - 1);
            //OpenAround(posX + 1, posY + 1);
            //OpenAround(posX, posY - 1);
            //OpenAround(posX, posY + 1);
            }

            squares[posX, posY].button.BackColor = Color.White;
            squares[posX, posY].button.Enabled = false;
        }
        //END OF OPENAROUND



    }//END OF CLASS
}//END OF NAMESPACE



