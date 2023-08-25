using System;
using System.Collections.Generic;


namespace Practica1CasaIntento3
{
    class Program
    {
        //static volatile bool terminarActualizacionHora = false;
        static async Task Main(string[] args)
        {


            //Task horaTask = ActualizarHoraAsync();

            Casa casa1 = new Casa(4);

            casa1.MostrarPlanos();


            while (true)
            {


                int opcionMain;
                do
                {
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("BIENVENIDO AL SOFTWARE CLEAN CODE\n" +
                        "\n1.Solicitar intervencion inicial" +
                        "\n2.Agregar una nueva habitacion" +
                        "\n3.Ampliar una habitacion" +
                        "\n4.Decorar Habitacion" +
                        "\n5.Arreglar item de una habitacion" +
                        "\n6.Mover un habitante" +
                        "\n7.Salir\nELIGE UNA OPCION:");

                    Console.WriteLine("----------------------------------------------------");
                    try
                    {
                        opcionMain = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException) {
                        opcionMain = -1;
                    }


                    switch (opcionMain)
                    {
                        case 1:
                            if (casa1.Intervencion_inicial_solicitada == true)
                            {
                                Console.WriteLine("Error, la solicitud intervencion inicial de la casa ya fue realizada");
                            }
                            else
                            {

                                Habitante.SolicitarIntervencionInicial(casa1);


                            }
                            break;
                        case 2:
                            Habitante.SolicitarHabitacionNueva(casa1);
                            break;
                        case 3:
                            Habitante.SolicitarAmpliacionHabitacion(casa1);
                            break;
                        case 4:
                            Habitante.SolicitarDecorarHabitacion(casa1);
                            break;
                        case 5:
                            Habitante.SolicitarArreglarObjetos(casa1); 
                            break;
                        case 6:

                            Console.WriteLine("Elige el nombre de la persona que quieres mover que ves en el plano");
                            string letra = Console.ReadLine();

                            //int[] valores_posicion = casa1.BuscarPersona(letra);
                            Persona persona_a_mover = casa1.BuscarPersona(letra);

                            if (persona_a_mover == null)
                            {
                                Console.WriteLine("No hay ninguna persona llamada" + letra);
                            }
                            else
                            {

                                Console.Write("Elige el numero de la fila a la que quieres mover la persona: ");
                                int fila_mover = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nElige el numero de la habitacion a la que quieres mover la persona");
                                int numHabitacion_mover = Convert.ToInt32(Console.ReadLine());

                                // HACER LA EXCEPCION PARA FUERA DEL RANGO
                                persona_a_mover.mover(casa1.PlanoCasa[fila_mover][numHabitacion_mover - 1], casa1);
                                casa1.MostrarPlanos();
                            }




                            break;
                        case 7:
                            Console.WriteLine($"El precio final es de {EmpresaRemodelaje.precioActualizado}");
                            Console.WriteLine("Gracias por usar nuestro Software :D");
                            break;
                        default:

                            Console.WriteLine("Error, ingresa una opcion valida entre 1 y 7");
                            break;

                    }


                } while (opcionMain != 7);

                if (opcionMain == 7)
                {
                    break;
                }
            }

            // Indicar que se debe terminar la tarea de actualización de hora
            //terminarActualizacionHora = true;

            // Esperar a que la tarea de actualización de hora termine
            //await horaTask;

            /* EmpresaRemodelaje.MostrarMenu();

            //Casa casa1 = new Casa(4);

            casa1.MostrarPlanos();


            Habitacion habitacion1 = new Habitacion("GIMNASIO", 5, 0, 4);

            //Habitacion habitacion2 = new Habitacion("Cuarto2", 5, 0, 5, new Habitante("G"));
            habitacion1.AgregarPersona(new Habitante("CAMILO"));

            Console.WriteLine($"Habitante favorito de {habitacion1.NombreHab} es {habitacion1.HabitanteFav.Nombre}");

            casa1.AgregarNuevaHab(1, habitacion1);
            //casa1.AgregarNuevaHab(1, habitacion2);

            casa1.MostrarPlanos();

            casa1.AmpliarHabitacionCasa(1, 1, 80);


            casa1.AmpliarHabitacionCasa(2, 1, 15);

            casa1.MostrarPlanos();








            //Probando adyacentes

            List<Habitacion> adyacentesHab = casa1.CalcularAdyacentes(2, 2);

            foreach (Habitacion element in adyacentesHab)
            {
                Console.WriteLine(element + " " + element.MetrosCuadrados);
            }


            //casa1.PlanoCasa[2][1].Personas[0].mover(casa1.PlanoCasa[0][3], casa1);
            casa1.MostrarPlanos();*/
        }
        /*static async Task ActualizarHoraAsync()
        {

            Console.WriteLine("Hora actual: " + DateTime.Now);

            // Aumentar la hora en 30 minutos
            DateTime nuevaHora = DateTime.Now;

            while (!terminarActualizacionHora)
            {
                // Aumentar la hora en 30 minutos
                nuevaHora = nuevaHora.AddMinutes(30);

                // Esperar 10 segundos antes de la próxima actualización
                await Task.Delay(1000); // Esperar 10 segundos

                //Console.WriteLine("Actualizando hora del sistema a: " + nuevaHora);
            }
        }*/

    }


}

