using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlavnaForma
{
    class Zadaca
    {
        public int level;
        public int result;
        public string s;
        public string o;
        public int tajmerce;
        public int kojred;

        public Zadaca(int l,int k)
        {
            level = l;
            kojred = k;
            if (l == 1)
                lvl1();
            else if (l == 2)
                lvl2();
            else if (l == 3)
                lvl3();
        }

        private void lvl1()
        {
            tajmerce = 10000;
            Random r = new Random();
            int a = (int)(r.Next()) % 20;
            int b = (int)(r.Next()) % 20;
            bool op = (a > b && ((int)(r.Next()) % 2) == 0);
            if (op)
            {
                if ((a + b + 3) % 5 == 0)
                {
                    s = string.Format("{0}\n{1}", a + b, b);
                    o = "-";
                    result = a;
                }
                else
                {
                    s = string.Format("{0}\n{1}", a, b);
                    o = "-";
                    result = a - b;
                }
            }
            else
            {
                s = string.Format("{0}\n{1}", a, b);
                o = "+";
                result = a + b;
            }
        }
        private void lvl2()
        {
            tajmerce = 8000;
            Random r = new Random();
            int a = (int)(r.Next()) % 10 + 1;
            int b = (int)(r.Next()) % 11;
            bool op = (a != 0 && b != 0 && ((int)(r.Next()) % 2) == 0);
            if (op)
            {
                s = string.Format("{0}\n{1}", a * b, a);
                o = ":";
                result = b;
            }
            else
            {
                s = string.Format("{0}\n{1}", a, b);
                o = "x";
                result = a * b;
            }
        }
        private void lvl3()
        {
            tajmerce = 8000;
            Random r = new Random();
            int a = (int)(r.Next()) % 20 + 10;
            int b = (int)(r.Next()) % 20 + 10;
            if (a * b < 200)
            {
                bool op = (((int)(r.Next()) % 2) == 0);
                if (op)
                {
                    s = string.Format("{0}\n{1}", a * b, a);
                    o = ":";
                    result = b;
                }
                else
                {
                    s = string.Format("{0}\n{1}", a, b);
                    o = "x";
                    result = a * b;
                }
            }
            else {
                bool op = (((int)(r.Next()) % 2) == 0);
                if (op)
                {
                    s = string.Format("{0}\n{1}", a + b, a);
                    o = "-";
                    result = b;
                }
                else
                {
                    s = string.Format("{0}\n{1}", a, b);
                    o = "+";
                    result = a + b;
                }
            }
        }
    }
}
