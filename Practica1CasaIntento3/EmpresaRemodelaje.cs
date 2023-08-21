using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public static class EmpresaRemodelaje
    {

        public static Dictionary<string, List<double>> catalogo = new Dictionary<string, List<double>>
        {
            { "1. Silla", new List<double> {1000, 0.10 } },
            { "2. Mesa", new List<double> {2000, 0.14 } },
            { "3. Cuadro", new List<double> {5000, 0.10 } },
            { "4. TV", new List<double> {15000, 0.20 } },
            { "5. Cama", new List<double> {8000, 0.20 } },
            { "6. Jarron", new List<double> {2000, 0.22 } },
        };


        private static int TrabajadoresDisponibles { get; set; }
        private static double TiempoDisponible { get; set; }// que es esto WTF

        /*public EmpresaRemodelaje(int trabajadoresIniciales, double tiempoInicial)
        {
            TrabajadoresDisponibles = trabajadoresIniciales;
            TiempoDisponible = tiempoInicial;
        }*/

        // PARTE DANIELA
        public static void MostrarCatalogo()
        {
            Console.WriteLine("Catálogo de objetos: ");
            foreach (var item in catalogo)
            {
                Console.WriteLine(item.Key);
            }
        }

        public static void MostrarMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                MostrarCatalogo();

                int opcion;
                do
                {
                    try
                    {
                        Console.WriteLine("Seleccione un número del 1 al 6 para elegir un objeto (0 para salir): ");
                        opcion = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: La entrada no es un número válido. Intente de nuevo.");
                        opcion = -1; // Establece una opción inválida para continuar el ciclo
                    }

                } while (opcion < 0 || opcion > 6);

                if (opcion == 0)
                {
                    continuar = false;
                    Console.WriteLine("Gracias por usar el catálogo. ¡Hasta luego!");
                }
                else
                {
                    string objetoElegido = catalogo.Keys.ElementAt(opcion - 1);
                    List<double> precios = catalogo[objetoElegido];
                    Console.WriteLine($"Ha elegido: {objetoElegido}");
                    Console.WriteLine($"Precio: {precios[0]}");
                }
            }
        }


















        // PARTE DE ANGEL
        public static double Tiempo_AñadirNuevaHabitacion(double metrosCuadrados)
        {
            return 1.5 * metrosCuadrados;
        }

        public static int Trabajadores_AñadirNuevaHabitacion(double metrosCuadrados)
        {
            return (int)Math.Ceiling(metrosCuadrados / 10) * 2;
        }

        public static double Tiempo_AmpliarHabitacion(double metrosCuadrados)
        {
            return 1.0 * metrosCuadrados;
        }

        public static int Trabajadores_AmpliarHabitacion(double metrosCuadrados)
        {
            return (int)Math.Ceiling(metrosCuadrados / 10);
        }

        public static double Tiempo_DecorarHabitacion(int cantidadItems)
        {
            return 0.5 * cantidadItems;
        }

        public static int Trabajadores_DecorarHabitacion()
        {
            return 1; //WTF?
        }

        public static double Tiempo_ArreglarHabitacion(int cantidadItems)
        {
            return 1.0 * cantidadItems; //WTF?
        }

        public static int Trabajadores_ArreglarHabitacion(int cantidadItems)
        {
            return cantidadItems; //???
        }

        public static void AgregarNuevaHabitacion(Casa casa, int fila, Habitacion habitacion)
        {
            double metrosCuadrados = habitacion.MetrosCuadrados;
            int trabajadores = Trabajadores_AñadirNuevaHabitacion(metrosCuadrados);
            double tiempo = Tiempo_AñadirNuevaHabitacion(metrosCuadrados);

            if (trabajadores <= TrabajadoresDisponibles && tiempo <= TiempoDisponible)
            {
                casa.AgregarNuevaHab(fila, habitacion);
                TrabajadoresDisponibles -= trabajadores;
                TiempoDisponible -= tiempo;
            }
            else
            {
                Console.WriteLine("No hay suficientes recursos disponibles para agregar una nueva habitación."); //Recursos?
            }
        }

        public static void AmpliarHabitacion(Casa casa, int fila, int numeroHabitacion,double aumento)
        {
            double metrosCuadrados = casa.PlanoCasa[fila - 1][numeroHabitacion - 1].MetrosCuadrados;
            int trabajadores = Trabajadores_AmpliarHabitacion(metrosCuadrados);
            double tiempo = Tiempo_AmpliarHabitacion(metrosCuadrados);

            if (trabajadores <= TrabajadoresDisponibles && tiempo <= TiempoDisponible)
            {
                casa.AmpliarHabitacionCasa(fila, numeroHabitacion, aumento);
                TrabajadoresDisponibles -= trabajadores;
                TiempoDisponible -= tiempo;
            }
            else
            {
                Console.WriteLine("No hay suficientes recursos disponibles para ampliar la habitación."); //WTF que hizo angel?
            }
        }

    }
}
