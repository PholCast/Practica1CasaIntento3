using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Habitante : Persona
    {
        private String habitacionFav;
        public Habitante(string nombreHabitante, Habitacion habitacionAct = null, string habitacionfav = null)
        {
            habitacionFav = habitacionfav;
            nombre = nombreHabitante;
            habitacionActual = habitacionAct;
        }
        //nueva habitacion y ampliar habitacion son estaticos para no tener que hacer que lo pida alguien en especifico
        public static void SolicitarHabitacionNueva(Casa casa)
        {
            Console.Write("Ingrese el nombre de la habitacion nueva: ");
            String nombre_nueva_habitacion = Console.ReadLine();

            Console.Write("Ingrese el número de fila en la casa que quiere agregar la habitacion: ");
            int fila = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el tamaño de la habitacion (por favor un multiplo de 5) :(  :");
            double metros = Convert.ToDouble(Console.ReadLine());

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

        public static void SolicitarAmpliacionHabitacion(Casa casa)
        {
            casa.MostrarPlanos();

            Console.Write("Ingrese el numero de fila en donde esta la habitacion para ampliar: ");
            int fila = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el numero de habitacion para ampliar: ");
            int numeroHabitacion = Convert.ToInt32(Console.ReadLine());

            Console.Write("Cuanto aumento quiere en la habitacion (por favor un multiplo de 5) :(  : ");
            double aumento = Convert.ToDouble(Console.ReadLine());

            if (fila >= 0 && fila < casa.PlanoCasa.Count)
            {
                if (numeroHabitacion > 0 && numeroHabitacion-1 < casa.PlanoCasa[fila].Count)
                {
                    Habitacion habitacionAmpliar = casa.PlanoCasa[fila][numeroHabitacion-1];

                    List<Habitacion> adyacentesHabitacionAmpliar = casa.CalcularAdyacentes(fila, numeroHabitacion);
                    

                    //Volver esto una funcion 
                    foreach (Habitacion habitacionAdyacente in adyacentesHabitacionAmpliar)
                    {
                        if (habitacionAdyacente.HayPersonas()==false)
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
        
        public void SolicitarIntervencionInicial(Casa casa)
        {
            List<string> trabajos = IngresarServicios();

            double costoTotalInicial = EmpresaRemodelaje.CalcularCostoInicial(trabajos);
            double tiempoTotalInicial = EmpresaRemodelaje.CalcularTiempoTotalInicial(trabajos);

            int trabajadoresRequeridos = (int)Math.Ceiling(tiempoTotalInicial);
            double costoTrabajadores = trabajadoresRequeridos * 40000;

            Console.WriteLine($"Intervención inicial solicitada por {nombre}:");
            Console.WriteLine("Trabajos solicitados:");
            foreach (string trabajo in trabajos)
            {
                Console.WriteLine($"- {trabajo}");
            }
            Console.WriteLine($"Costo total inicial: ${costoTotalInicial + costoTrabajadores}");
            Console.WriteLine($"Tiempo requerido: {tiempoTotalInicial} horas");
            Console.WriteLine($"Número de trabajadores requeridos: {trabajadoresRequeridos}");

            EmpresaRemodelaje.RealizarIntervencionSolicitada(casa, this, trabajos);
        }

        public static List<string> IngresarServicios()
        {
            List<string> trabajos = new List<string>();

            Console.WriteLine("Ingrese los servicios solicitados (ingrese 'fin' para finalizar):");
            while (true)
            {
                string trabajo = Console.ReadLine();
                if (trabajo.ToLower() == "fin")
                {
                    break;
                }
                trabajos.Add(trabajo);
            }

            return trabajos;
        }
    }

}
