using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GlavnaForma
{
    class Square
    {
        //public event EventHandler Dismantle;
        //public event EventHandler Explode;

        public static readonly int sizeOfSquare = 25;
        public int x { get; set; }
        public int y { get; set; }
        public bool hasMine { get; set; }
        public bool opened { get; set; }
        public bool dismantled { get; set; }
        public string buttonText { get; set; }
        public Game game { get; set; }
        public Button button { get; set; }

        public Square() { }

        public Square(Game gamey, int Ex, int Why)
        {
            game = gamey;
            hasMine = false;
            opened = false;
            dismantled = false;
            x = Ex;
            y = Why;
            
            button = new Button();
            button.Text = "";
            
           
            
            //button.MouseDown += new MouseEventHandler(button_MouseDown);
        }

        public void colorUpdate() {
            //if(button.Text != "")
                switch (button.Text)
            {
                case "1":
                    this.button.ForeColor = Color.LightBlue;
                    break;
                case "2":
                    this.button.ForeColor = Color.LightGreen;
                    break;
                case "3":
                    this.button.ForeColor = Color.Red;
                    break;
                case "4":
                    this.button.ForeColor = Color.DarkViolet;
                    break;
                case "5":
                    this.button.ForeColor = Color.Crimson;
                    break;
                case "6":
                    this.button.ForeColor = Color.Cyan;
                    break;
                case "7":
                    this.button.ForeColor = Color.Gold;
                    break;
                case "8":
                    this.button.ForeColor = Color.Orange;
                    break;
            }
        }






    }
}
