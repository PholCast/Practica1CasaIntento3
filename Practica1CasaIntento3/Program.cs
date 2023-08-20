using System;
using System.Collections.Generic;


namespace Practica1CasaIntento3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener la fecha y hora actual
            DateTime tomorrow_ahorita = DateTime.Now;

            // Crear un nuevo objeto DateTime con una hora específica
           /* DateTime ANGEL = new DateTime(tomorrow_ahorita.Year,
            tomorrow_ahorita.Month,
            tomorrow_ahorita.Day, 7, 30, 0);

            Console.WriteLine("Fecha y hora actual: " + tomorrow_ahorita);
            Console.WriteLine("Hora específica: " + ANGEL);*/

            Casa casa1 = new Casa(3);

            casa1.MostrarPlanos();

            
            Habitacion habitacion1 = new Habitacion("Cuarto",4,0,4, new Habitante("Phol"));

            Habitacion habitacion2 = new Habitacion("Cuarto2", 2, 0, 5, new Habitante("G"));

            

            casa1.AgregarNuevaHab(1, habitacion1);
            casa1.AgregarNuevaHab(1, habitacion2);

            casa1.MostrarPlanos();

            casa1.AmpliarHabitacionCasa(2, 2);

            casa1.MostrarPlanos();
        }

        public static List<Habitacion> Adyacentes(Casa casaEjemplo,Habitacion habitacionEjemplo)
        {
            List<Habitacion> habitacionesAdyacentes = new List<Habitacion>();
           
                
                if(habitacionEjemplo.PosicionFila == 0 && habitacionEjemplo.NumeroHabitacion-1 ==0)
            {
                habitacionesAdyacentes.Add(casaEjemplo.PlanoCasa[0][1]);
                habitacionesAdyacentes.Add(casaEjemplo.PlanoCasa[1][0]);

                for(int i = 1; i < casaEjemplo.PlanoCasa[1].Count; i++)
                {
                    double count = 0;
                    for(int j = 1; j <= i; j++)
                    {
                        count += casaEjemplo.PlanoCasa[1][j].MetrosCuadrados;
                        Console.WriteLine("count es: " + count);
                    }
                }
                    
                }
            }
        }
    }
}