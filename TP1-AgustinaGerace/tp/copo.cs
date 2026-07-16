using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp
{
    public class copo
    {
        private int x;
        private int y;


        public copo()
        {
            x = 0;
            y = 0;
        }


        public copo(int x)
        {
            this.x = x;
            y = 0;
        }


        public copo(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public int X
        {
            get
            {
                return x;
            }
        }


        public int Y
        {
            get
            {
                return y;
            }
        }


        public void Mostrar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
        }


        public void Borrar()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
        public void Bajar()
        {
            Borrar();
            y++;
            Mostrar();
        }


        public bool LlegoAlFinal()
        {
            return y >= 12;
        }
    }
}