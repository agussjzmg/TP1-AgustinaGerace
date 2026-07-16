using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp
{
    public class configuracion
    {
        private int filas;
        private int columnas;
        private int velocidad;


        public configuracion()
        {
            filas = 20;
            columnas = 20;
            velocidad = 350;
        }


        public int Filas
        {
            get
            {
                return filas;
            }
        }


        public int Columnas
        {
            get
            {
                return columnas;
            }
        }


        public int Velocidad
        {
            get
            {
                return velocidad;
            }
        }
    }
}