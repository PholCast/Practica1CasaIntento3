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

            Casa casa1 = new Casa(4);

            casa1.MostrarPlanos();

            
            Habitacion habitacion1 = new Habitacion("Cuarto",4,0,4, new Habitante("Phol"));

            Habitacion habitacion2 = new Habitacion("Cuarto2", 2, 0, 5, new Habitante("G"));

            

            casa1.AgregarNuevaHab(1, habitacion1);
            casa1.AgregarNuevaHab(1, habitacion2);

            casa1.MostrarPlanos();

            casa1.AmpliarHabitacionCasa(1, 1,6);
            casa1.AmpliarHabitacionCasa(2, 1, 3);

            casa1.MostrarPlanos();

            //Probando adyacentes
            List <Habitacion> adyacentesHab = Adyacentes(casa1, casa1.PlanoCasa[0][0]);

            foreach(Habitacion element in adyacentesHab)
            {
                Console.WriteLine(element);
            }
        }

        public static List<Habitacion> Adyacentes(Casa casaEjemplo,Habitacion habitacionEjemplo)
        {
            List<Habitacion> habitacionesAdyacentes = new List<Habitacion>();
           
                //Evaluando cuando esta en la esquina superior izquierda     
                if(habitacionEjemplo.PosicionFila == 0 && habitacionEjemplo.NumeroHabitacion-1 ==0)
            {
                habitacionesAdyacentes.Add(casaEjemplo.PlanoCasa[0][1]);


                //count anterior representa como donde empieza la habitacion
                double count_anterior = 0;

                for (int i = 0; i < casaEjemplo.PlanoCasa[1].Count; i++)
                {
                    double count = 0;
                    int aux_j = 0;
                    for (int j = 0; j <= i; j++)
                    {   
                        Console.WriteLine("count parte1 es: " + count);
                        count += casaEjemplo.PlanoCasa[1][j].MetrosCuadrados;
                        Console.WriteLine("count parte2 es: " + count);



                       aux_j= j;
                    }
                      if (count_anterior>= 0 && count< habitacionEjemplo.MetrosCuadrados)
                        {
                            habitacionesAdyacentes.Add(casaEjemplo.PlanoCasa[1][aux_j]);
                        }
                    count_anterior = count;
                }
                return habitacionesAdyacentes;
                
                
                }

            else { return null; }
            }
        }
    }