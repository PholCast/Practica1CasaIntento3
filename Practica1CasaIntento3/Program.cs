using System;
using System.Collections.Generic;


namespace Practica1CasaIntento3
{
    class Program
    {
        static void Main(string[] args)
        {
           // EmpresaRemodelaje.MostrarMenu();

            Casa casa1 = new Casa(4);

            casa1.MostrarPlanos();

            
            Habitacion habitacion1 = new Habitacion("Cuarto",5,0,4, new Habitante("Phol"));

            Habitacion habitacion2 = new Habitacion("Cuarto2", 5, 0, 5, new Habitante("G"));

            

            casa1.AgregarNuevaHab(1, habitacion1);
            casa1.AgregarNuevaHab(1, habitacion2);

            casa1.MostrarPlanos();

            casa1.AmpliarHabitacionCasa(1, 1,80);
            

            casa1.AmpliarHabitacionCasa(2, 1, 15);

            casa1.MostrarPlanos();

            Console.WriteLine("Metros cuadrados de  p: " + casa1.PlanoCasa[0][0].MetrosCuadrados);


            double[] array_ejemplo = casa1.CalcularPosicionHabitacion(0, 2);

            foreach(double num in array_ejemplo)
            {
                Console.WriteLine($"Ejemplo posiciones:{ num}");
            }

            //Probando adyacentes

            List<Habitacion> adyacentesHab = casa1.CalcularAdyacentes(2,2);

            foreach(Habitacion element in adyacentesHab)
            {
                Console.WriteLine(element +" "+ element.MetrosCuadrados);
            }
        }

        
            
            }
        }
    