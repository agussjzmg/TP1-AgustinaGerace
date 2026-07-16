using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp
{
/* El programa debe cumplir con las siguientes condiciones:
Definir una clase Configuracion que almacene parámetros de la simulación, como la cantidad de filas, columnas y la velocidad de caída de los copos.
Definir una clase Copo que modele el comportamiento de un copo de nieve. Cada copo debe tener una posición en la consola y un método para mostrarse y desplazarse hacia abajo.
Usar una lista para administrar todos los copos activos durante la simulación.
Implementar una lógica que controle la caída de los copos de nieve, evitando que se superpongan en la misma posición.
Al completarse una fila con copos en todas las columnas, esta debe eliminarse para permitir que continúe la simulación.
El programa debe ejecutarse en un ciclo continuo, simulando de manera animada la caída de los copos.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            configuracion config = new configuracion();

            Random random = new Random();

            List<copo> copos = new List<copo>();

            bool[,] nieve = new bool[12, 20];

            // crear los copos
            for (int i = 0; i < config.Filas; i++)
            {
                int x = random.Next(0, config.Columnas);
                int y = random.Next(0, 5);

                copo nuevo = new copo(x, y);

                copos.Add(nuevo);

                nuevo.Mostrar();
            }

            DateTime tiempoInicio = DateTime.Now;

            while (true)
            {
                TimeSpan tiempoPasado = DateTime.Now - tiempoInicio;

                if (tiempoPasado.TotalMilliseconds >= config.Velocidad)
                {
                    tiempoInicio = DateTime.Now;

                    for (int i = 0; i < copos.Count; i++)
                    {
                        if (copos[i].Y + 1 < 12 && !nieve[copos[i].Y + 1, copos[i].X])
                        {
                            copos[i].Bajar();
                        }
                        else
                        {
                            int x = copos[i].X;
                            int y = copos[i].Y;

                            if (y >= 0 && y < 12)
                            {
                                nieve[y, x] = true;

                                Console.SetCursorPosition(x, y);
                                Console.Write("*");
                            }

                            int nuevoX = random.Next(0, config.Columnas);

                            while (nieve[0, nuevoX])
                            {
                                nuevoX = random.Next(0, config.Columnas);
                            }

                            copos[i] = new copo(nuevoX, 0);
                            copos[i].Mostrar();
                        }
                    }

                    // solamente la última fila
                    bool completa = true;

                    for (int columna = 0; columna < 20; columna++)
                    {
                        if (nieve[11, columna] == false)
                        {
                            completa = false;
                        }
                    }

                    if (completa)
                    {
                        for (int fila = 11; fila > 0; fila--)
                        {
                            for (int columna = 0; columna < 20; columna++)
                            {
                                nieve[fila, columna] = nieve[fila - 1, columna];

                                Console.SetCursorPosition(columna, fila);

                                if (nieve[fila, columna])
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }

                        for (int columna = 0; columna < 20; columna++)
                        {
                            nieve[0, columna] = false;

                            Console.SetCursorPosition(columna, 0);
                            Console.Write(" ");
                        }
                    }
                }
            }
        }
    }
}
