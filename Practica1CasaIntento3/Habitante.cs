using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Habitante : Persona
    {
        private Habitacion habitacionFav;
        public Habitante(string nombreHabitante, Habitacion habitacionAct = null, Habitacion habitacionfav = null)
        {
            habitacionFav = habitacionfav;
            nombre = nombreHabitante;
            habitacionActual = habitacionAct;
        }



        public Habitacion HabitacionFav
        {
            get { return habitacionFav; }
            set
            {
                //Console.WriteLine($"{nombre} Tu habitacion Favorita es: {value.NombreHab}");
                habitacionFav = value;
            }
        }


        //nueva habitacion y ampliar habitacion son estaticos para no tener que hacer que lo pida alguien en especifico
        public static void SolicitarHabitacionNueva(Casa casa, string nombre_nueva_habitacion = null, int fila = -1, double metros = -1)
        {

            if (nombre_nueva_habitacion == null && fila == -1 && metros == -1)
            {
                Console.Write("Ingrese el nombre de la habitacion nueva: ");
                nombre_nueva_habitacion = Console.ReadLine();

                Console.Write("Ingrese el número de fila en la casa que quiere agregar la habitacion: ");
                fila = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese el tamaño de la habitacion (por favor un multiplo de 5) :(  :");
                metros = Convert.ToDouble(Console.ReadLine());
            }

            if (fila >= 0 && fila < casa.PlanoCasa.Count)
            {
                Console.WriteLine($"solicitando una nueva habitación en la fila {fila}.");
                EmpresaRemodelaje.AgregarNuevaHabitacion(casa, nombre_nueva_habitacion, fila, metros);
            }
            else
            {
                Console.WriteLine("Número de fila no válido.");
            }
        }

        public static void SolicitarAmpliacionHabitacion(Casa casa, int fila = -1, int numeroHabitacion = -1, double aumento = -1)
        {
            casa.MostrarPlanos();


            if (fila == -1 && numeroHabitacion == -1 && aumento == -1)
            {
                Console.Write("Ingrese el numero de fila en donde esta la habitacion para ampliar: ");
                fila = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese el numero de habitacion para ampliar: ");
                numeroHabitacion = Convert.ToInt32(Console.ReadLine());

                Console.Write("Cuanto aumento quiere en la habitacion (por favor un multiplo de 5) :(  : ");
                aumento = Convert.ToDouble(Console.ReadLine());
            }

            if (fila >= 0 && fila < casa.PlanoCasa.Count)
            {
                if (numeroHabitacion > 0 && numeroHabitacion - 1 < casa.PlanoCasa[fila].Count)
                {
                    Habitacion habitacionAmpliar = casa.PlanoCasa[fila][numeroHabitacion - 1];
                    if (habitacionAmpliar.HayPersonas() == true)
                    {
                        Console.WriteLine("Error, para ampliar la habitacion deben salir las personas de la habitacion y tampoco pueden estar en habitaciones adyacentes");
                        return;
                    }
                    List<Habitacion> adyacentesHabitacionAmpliar = casa.CalcularAdyacentes(fila, numeroHabitacion);


                    //Volver esto una funcion 
                    foreach (Habitacion habitacionAdyacente in adyacentesHabitacionAmpliar)
                    {
                        if (habitacionAdyacente.HayPersonas() == false)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Error, para ampliar la habitacion no debe haber personas en las habitaciones adyacentes ");
                            return;

                        }
                    }

                    if (aumento > 0)
                    {
                        Console.WriteLine($"está solicitando la ampliación de la habitación en la fila {fila}, número {numeroHabitacion}.");
                        EmpresaRemodelaje.AmpliarHabitacion(casa, fila, numeroHabitacion, aumento);
                    }
                    else
                    {
                        Console.WriteLine("Aumento Invalido");
                    }
                }
                else
                {
                    Console.WriteLine("Numero de habitacion Invalido");
                }
            }
            else
            {
                Console.WriteLine("Numero de fila invalido");
            }
        }

        public static void SolicitarDecorarHabitacion(Casa casa, int fila = -1, int numeroHabitacion = -1)
        {

            casa.MostrarPlanos();

            if (fila == -1 && numeroHabitacion == -1)
            {
                Console.Write("Ingrese el numero de fila donde esta la habitacion a decorar: ");
                fila = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese el numero de habitacion que desea decorar: ");
                numeroHabitacion = Convert.ToInt32(Console.ReadLine());
            }

            if (fila >= 0 && fila < casa.PlanoCasa.Count)
            {
                if (numeroHabitacion > 0 && numeroHabitacion - 1 < casa.PlanoCasa[fila].Count)
                {
                    EmpresaRemodelaje.MostrarMenu(casa, casa.PlanoCasa[fila][numeroHabitacion - 1]);
                }
                else
                {
                    Console.WriteLine("Numero de habitacion invalido");
                }
            }
            else
            {
                Console.WriteLine("Numero de fila invalido");
            }
        }

        public static void SolicitarIntervencionInicial(Casa casa)
        {
            List<string> trabajos = IngresarServicios();

            List<List<string>> datos = new List<List<string>>
            {
                new List<string> { "Gimnasio", "3", "20"},
                new List<string> { "Sala", "0", "5"},
                new List<string> { "2", "2", "10"},
                new List<string> { "cuarto", "2", "15"},
                new List<string> { "Cocina", "0", "10"},
                new List<string> { "0", "1", "5"},
                new List<string> { "2", "3", "10"},
                new List<string> { "1", "1", "15"}
            };

            double costoTotalInicial = EmpresaRemodelaje.CalcularCostoInicial(trabajos);
            double tiempoTotalInicial = EmpresaRemodelaje.CalcularTiempoTotalInicial(trabajos,datos);

            int trabajadoresRequeridos = (int)Math.Ceiling(tiempoTotalInicial);
            double costoTrabajadores = trabajadoresRequeridos * 40000;

            Console.WriteLine($"Intervención inicial solicitada:");
            Console.WriteLine("Trabajos solicitados:");
            foreach (string trabajo in trabajos)
            {
                Console.WriteLine($"- {trabajo}");
            }
            Console.WriteLine($"Costo total inicial: ${costoTotalInicial + costoTrabajadores}");
            Console.WriteLine($"Tiempo requerido: {tiempoTotalInicial} horas");
            Console.WriteLine($"Número de trabajadores requeridos: {trabajadoresRequeridos}");

            EmpresaRemodelaje.RealizarIntervencionSolicitada(casa,trabajos,datos);
        }

        public static void SolicitarArreglarObjetos(Objeto objetosParaArreglar, Casa casa, int fila = -1, int numeroHabitacion=-1)
        {
            casa.MostrarPlanos();


            if (fila == -1 && numeroHabitacion == -1)
            {
                Console.Write("Ingrese el numero de fila donde desea arreglar el objeto: ");
                fila = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ingrese el numero de habitacion donde desea arreglar el objeto: ");
                numeroHabitacion = Convert.ToInt32(Console.ReadLine());

            }

            if (fila >= 0 && fila < casa.PlanoCasa.Count)
            {
                if (numeroHabitacion > 0 && numeroHabitacion < casa.PlanoCasa[fila].Count)
                {
                    //EmpresaRemodelaje.MostrarMenu(casa, casa.PlanoCasa[fila][numeroHabitacion - 1]);

                    //Crear un metodo de la empresa llamado:
                    //EmpresaRemodelaje.ArreglarObjetos(casa,casa.PlanoCasa[fila][numeroHabitacion - 1],objetosParaArreglar);
                }
                else
                {
                    Console.WriteLine("Numero de habitacion invalido");
                }
            }
            else
            {
                Console.WriteLine("Numero de fila invalido");
            }

            //habitacion.MostrarObjetosHabitacion();
        }

        public static List<string> IngresarServicios()
        {
            List<string> trabajos = new List<string>()
            {
                "Agregar habitacion", "Agregar habitacion", "Ampliacion de habitacion",
                "Agregar habitacion", "Agregar habitacion","Ampliacion de habitacion",
                "Ampliacion de habitacion","Ampliacion de habitacion"
            };

            //Console.WriteLine("Ingrese los servicios solicitados (ingrese 'fin' para finalizar):");
            /* while (true)
             {
                 string trabajo = Console.ReadLine();
                 if (trabajo.ToLower() == "fin")
                 {
                     break;
                 }
                 trabajos.Add(trabajo);
             }*/

            return trabajos;
        }
    }

}
