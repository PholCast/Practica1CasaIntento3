using System;
using System.Collections.Generic;


namespace Practica1CasaIntento3
{
    class Program
    {
        static void Main(string[] args)
        {

            Casa casa1 = new Casa(4);
           

            casa1.MostrarPlanos();
            while (true)
            {


                int opcionMain;
                do
                {   
                    Console.WriteLine("BIENVENIDO AL SOFTWARE CLEAN CODE\n" +
                        "\n1.Solicitar intervencion inicial" +
                        "\n2.Agregar una nueva habitacion" +
                        "\n3.Ampliar una habitacion" +
                        "\n4.Decorar Habitacion" +
                        "\n5.Arreglar item de una habitacion" +
                        "\n6.Mover un habitante" +
                        "\n7.Salir\nELIGE UNA OPCION:");

                    opcionMain = Convert.ToInt32(Console.ReadLine());

                    switch (opcionMain)
                    {
                        case 1:
                            if(casa1.Intervencion_inicial_solicitada == true)
                            {
                                Console.WriteLine("Error, la solicitud intervencion inicial de la casa ya fue realizada");
                            }
                            else{
                                
                                //


                            }
                            break;
                        case 2:
                            //
                              break;
                        case 3:
                            Habitante.SolicitarAmpliacionHabitacion(casa1);
                            break;
                        case 4:
                            //
                            break;
                        case 5:
                            //
                            break;
                        case 6:

                            Console.WriteLine("Elige el nombre de la persona que quieres mover que ves en el plano");
                            string letra = Console.ReadLine();

                            int[] valores_posicion = casa1.BuscarPersona(letra);


                            if (valores_posicion ==null)
                            {
                                Console.WriteLine("No hay ninguna persona llamada"+letra);
                            }
                            else
                            {

                                Console.Write("Elige el numero de la fila a la que quieres mover la persona: ");
                                int fila = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nElige el numero de la habitacion a la que quieres mover la persona");
                                int numHabitacion = Convert.ToInt32(Console.ReadLine());

                                //ayuda
                                casa1.PlanoCasa[valores_posicion[0]][valores_posicion[1] - 1].Personas[valores_posicion[2]].mover(casa1.PlanoCasa[fila][numHabitacion-1],casa1);

                                casa1.MostrarPlanos();
                            }
                            

                            

                            break;
                        case 7:
                            Console.WriteLine("Gracias por usar nuestro Software :D");
                            break;
                        default:
                            Console.WriteLine("Error, ingresa una opcion valida entre 1 y 7");
                            break;

                    }


                } while (opcionMain != 7);

                if(opcionMain == 7)
                {
                    break;
                }
            }


           // EmpresaRemodelaje.MostrarMenu();

            //Casa casa1 = new Casa(4);

            casa1.MostrarPlanos();

            
            Habitacion habitacion1 = new Habitacion("Cuarto",5,0,4, new Habitante("Phol"));

            Habitacion habitacion2 = new Habitacion("Cuarto2", 5, 0, 5, new Habitante("G"));

           
            casa1.AgregarNuevaHab(1, habitacion1);
            casa1.AgregarNuevaHab(1, habitacion2);

            casa1.MostrarPlanos();

            casa1.AmpliarHabitacionCasa(1, 1,80);
            

            casa1.AmpliarHabitacionCasa(2, 1, 15);

            casa1.MostrarPlanos();

          


            

            

            //Probando adyacentes

            List<Habitacion> adyacentesHab = casa1.CalcularAdyacentes(2,2);

            foreach(Habitacion element in adyacentesHab)
            {
                Console.WriteLine(element +" "+ element.MetrosCuadrados);
            }


            casa1.PlanoCasa[2][1].Personas[0].mover(casa1.PlanoCasa[0][3], casa1);
            casa1.MostrarPlanos();
        }

        
            
            }
        }
    