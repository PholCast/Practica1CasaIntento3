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
            { "Silla", new List<double> {1000, 0.10 } },
            { "Mesa", new List<double> {2000, 0.14 } },
            { "Cuadro", new List<double> {5000, 0.10 } },
            { "TV", new List<double> {15000, 0.20 } },
            { "Cama", new List<double> {8000, 0.20 } },
            { "Jarron", new List<double> {2000, 0.22 } },
        };

        public static double precioActualizado = 0;

        public static int num_trabajadores = 24;

        public static int TrabajadoresDisponibles = 24;// { get; set; }

        public static String[] remodeladorRandom =
                    {
            "Arnulfo", "Bernardo", "Cecilia", "Daniel", "Elias", "Federico",
            "Gonzalo", "Henrique", "Irma", "Juancho", "Kira", "Luna",
            "Magola", "Nela", "Oscar", "Pepito", "Quin", "Roberta",
            "Sopia", "Tulio", "Uriel", "Valeria", "William", "Ximena",
            "Yeison", "Zian"
             };

        public static List<Remodelador> remodeladoresEmpresa = CrearRemodeladores();

        public static List<Remodelador> CrearRemodeladores()
        {
            List<Remodelador> remodeladores = new List<Remodelador>();
            for (int i = 0; i < num_trabajadores; i++)
            {
                Remodelador aux_remodelador = new Remodelador(remodeladorRandom[i]);

                remodeladores.Add(aux_remodelador);
            }
            return remodeladores;
        }

        // PARTE DANIELA
        public static void MostrarCatalogo()
        {
            int contador = 1;
            Console.WriteLine("Catálogo de objetos: ");
            foreach (var item in catalogo)
            {
                Console.WriteLine(contador + ". " + item.Key);
                contador++;
            }
        }

        public static void MostrarMenu(Casa casa, Habitacion habDecorar)
        {
            bool continuar = true;
            double espacioUsado = 0 + habDecorar.CalcularEspacioObjetos();
            if (habDecorar.HabitanteFav.HabitacionActual == habDecorar)
            {
                List<Objeto> objetos = new List<Objeto>();

                while (continuar)
                {
                    MostrarCatalogo();
                    int opcion;

                    do
                    {
                        try
                        {
                            Console.WriteLine("Seleccione un número del 1 al 6 para elegir un objeto (0 para pasar a comprar): ");
                            opcion = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: La entrada no es un número válido. Intente de nuevo.");
                            opcion = -1; // Establece una opción inválida para continuar el ciclo
                        }

                    } while (opcion < 0 || opcion > 6);

                    Objeto objetoACrear;

                    switch (opcion)
                    {
                        case 0:
                            {
                                continuar = false;
                                // Remodelador.AgregarObjetos(casa, habDecorar, objetos);    Angel arregla esto

                                break;
                            }
                        case 1:
                            {
                                if ((espacioUsado + catalogo["Silla"][1]) < habDecorar.MetrosCuadrados)
                                {
                                    objetoACrear = new Objeto("Silla", catalogo["Silla"][0], catalogo["Silla"][1]);
                                }
                                else
                                {
                                    Console.WriteLine("No hay espacio suficiente para agregar la silla");
                                }

                                break;
                            }
                        case 2:
                            {
                                if ((espacioUsado + catalogo["Mesa"][1]) < habDecorar.MetrosCuadrados)
                                {
                                    objetoACrear = new Objeto("Mesa", catalogo["Mesa"][0], catalogo["Mesa"][1]);
                                }
                                else
                                {
                                    Console.WriteLine("No hay espacio suficiente para agregar la Mesa");
                                }

                                break;
                            }
                        case 3:
                            {
                                if ((espacioUsado + catalogo["Cuadro"][1]) < habDecorar.MetrosCuadrados)
                                {
                                    objetoACrear = new Objeto("Cuadro", catalogo["Cuadro"][0], catalogo["Cuadro"][1]);
                                }
                                else
                                {
                                    Console.WriteLine("No hay espacio suficiente para agregar el cuadro");
                                }

                                break;
                            }
                        case 4:
                            {
                                if ((espacioUsado + catalogo["TV"][1]) < habDecorar.MetrosCuadrados)
                                {
                                    objetoACrear = new Objeto("TV", catalogo["TV"][0], catalogo["TV"][1]);
                                }
                                else
                                {
                                    Console.WriteLine("No hay espacio suficiente para agregar la TV");
                                }

                                break;
                            }
                        case 5:
                            {
                                if ((espacioUsado + catalogo["Cama"][1]) < habDecorar.MetrosCuadrados)
                                {
                                    objetoACrear = new Objeto("Cama", catalogo["Cama"][0], catalogo["Cama"][1]);
                                }
                                else
                                {
                                    Console.WriteLine("No hay espacio suficiente para agregar la Cama");
                                }

                                break;
                            }
                        case 6:
                            {
                                if ((espacioUsado + catalogo["Jarron"][1]) < habDecorar.MetrosCuadrados)
                                {
                                    objetoACrear = new Objeto("Jarron", catalogo["Jarron"][0], catalogo["Jarron"][1]);
                                }
                                else
                                {
                                    Console.WriteLine("No hay espacio suficiente para agregar el Jarron");
                                }

                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Opcion Invalida");
                                break;
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine("El habitante favorito no se encuentra en la habitacion :( ");
                string guardar;
                Console.WriteLine("Desea decorar otra habitacion [s/n]: ");
                guardar = Console.ReadLine();
                if (guardar.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    Habitante.SolicitarDecorarHabitacion(casa);
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

        /*public static double Tiempo_DecorarHabitacion(int cantidadItems)
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
        }*/

        public static void AgregarNuevaHabitacion(Casa casa, String nombreNuevaHab, int fila, double metros)
        {
            Habitacion nueva_habitacion = new Habitacion(nombreNuevaHab, metros, fila, casa.DiccionarioFilas[fila] + 1);
            //Verificar si se puede crear por lo de personas en habitaciones adyacentes




            //double metrosCuadrados = nueva_habitacion.MetrosCuadrados; //Codigo sucio. Ya existia metros en los parametros. Wtf angel
            int trabajadoresParaTarea = Trabajadores_AñadirNuevaHabitacion(metros);
            double tiempo = Tiempo_AñadirNuevaHabitacion(metros);

            if (trabajadoresParaTarea > TrabajadoresDisponibles)
            {
                Console.WriteLine("No hay los trabajadores suficientes, espera a que terminen de chambear");
            }

            else
            {
                casa.AgregarNuevaHab(fila, nueva_habitacion);
                TrabajadoresDisponibles -= trabajadoresParaTarea;

                //Verificar si se puede crear por lo de personas en habitaciones adyacentes
                //Volver esto una funcion
                List<Habitacion> adyacentesHabitacionNueva = casa.CalcularAdyacentes(nueva_habitacion.PosicionFila, nueva_habitacion.NumeroHabitacion);

                foreach (Habitacion habitacionAdyacente in adyacentesHabitacionNueva)
                {
                    if (habitacionAdyacente.HayPersonas() == false)
                    {

                    }
                    else
                    {
                        casa.RemoverNuevaHab(fila, nueva_habitacion);
                        TrabajadoresDisponibles += trabajadoresParaTarea;
                        Console.WriteLine("Error, para agregar la nueva habitacion no debe haber personas en las habitaciones adyacentes ");
                        return;

                    }
                }

                //si pasa de aca es porque si se puede crear la habitacion
                Console.WriteLine("Habitacion creada con Exito");
                TrabajadoresDisponibles += trabajadoresParaTarea;

                double precioNuevaHabitacion = trabajadoresParaTarea * tiempo * 40000;

                //Cada vez que se cree una habitacion se le suma al precio
                precioActualizado += precioNuevaHabitacion;

                Console.WriteLine($"El precio final se ha actualizado a: {precioActualizado}");
                casa.MostrarPlanos();

            }

        }

        public static void AmpliarHabitacion(Casa casa, int fila, int numeroHabitacion, double aumento)
        {
            double metrosCuadrados = casa.PlanoCasa[fila][numeroHabitacion - 1].MetrosCuadrados;
            int trabajadores = Trabajadores_AmpliarHabitacion(metrosCuadrados);
            double tiempo = Tiempo_AmpliarHabitacion(metrosCuadrados);

            if (trabajadores <= TrabajadoresDisponibles)
            {
                casa.AmpliarHabitacionCasa(fila, numeroHabitacion, aumento);
                TrabajadoresDisponibles -= trabajadores;
                //Asincrona para esperar mientras lo hacen la tarea.
            }
            else
            {
                Console.WriteLine("No hay suficientes recursos disponibles para ampliar la habitación."); //WTF que hizo angel?
            }

            Console.WriteLine($"La habitacion {fila}{numeroHabitacion} ha sido ampliada {aumento} metros");
            //pasado el tiempo acaban la tarea
            TrabajadoresDisponibles += trabajadores;

            double precioHabitacionAmpliada = trabajadores * tiempo * 40000;

            precioActualizado += precioHabitacionAmpliada;
            Console.WriteLine($"El precio final se ha actualizado a: {precioActualizado}");
            
        }


        public static void RealizarIntervencionSolicitada(Casa casa, List<string> trabajosSolicitados, List<List<string>> datos)
        {
            Console.WriteLine($"¿Desea realizar los cambios solicitados? (Si/No)");
            string respuesta = Console.ReadLine();

            if (respuesta.Equals("Si", StringComparison.OrdinalIgnoreCase))
            {
                //Cambiamos el atributo para que no se pueda repetir la opcion de intervencion inicial
                casa.Intervencion_inicial_solicitada = true;
                int i = 0;
                foreach (string trabajo in trabajosSolicitados)
                {
                    if (trabajo.Equals("Agregar habitacion", StringComparison.OrdinalIgnoreCase))
                    {
                        Habitante.SolicitarHabitacionNueva(casa, datos[i][0], Convert.ToInt32(datos[i][1]), Convert.ToDouble(datos[i][2]));
                        i++;
                    }
                    else if (trabajo.Equals("Ampliacion de habitacion", StringComparison.OrdinalIgnoreCase))
                    {
                        Habitante.SolicitarAmpliacionHabitacion(casa, Convert.ToInt32(datos[i][0]), Convert.ToInt32(datos[i][1]), Convert.ToDouble(datos[i][2]));
                        i++;
                    }
                }
                Console.WriteLine("Los cambios solicitados han sido realizados.");
            }
            else
            {
                Console.WriteLine("Los cambios solicitados han sido cancelados.");
            }
        }

        public static double CalcularCostoInicial(List<string> trabajos)
        {
            double costoTotal = 0;

            Dictionary<string, double> costosPorTrabajo = new Dictionary<string, double>
            {
                { "Agregar habitacion", 200000},
                { "Ampliacion de habitacion", 150000 },
                { "Decoracion de habitacion", 80000 },
                { "Arreglo en habitacion", 120000 }
            };

            foreach (string trabajo in trabajos)
            {
                if (costosPorTrabajo.ContainsKey(trabajo))
                {
                    costoTotal += costosPorTrabajo[trabajo];
                }
            }

            return costoTotal;
        }
        public static double CalcularTiempoTotalInicial(List<string> trabajos, List<List<string>> datos)
        {
            double tiempoTotal = 0;
            int i = 0;

            Dictionary<string, double> tiemposPorTrabajo = new Dictionary<string, double>
            {
                { "Agregar habitacion", Tiempo_AñadirNuevaHabitacion(Convert.ToInt32(datos[i][2]))},
                { "Ampliacion de habitacion", Tiempo_AmpliarHabitacion(Convert.ToInt32(datos[i][2]))},
                { "Decoracion de habitacion", 0.5 },
                { "Arreglo en habitacion", 1 }//una hora por item a arreglar
            };
            foreach (string trabajo in trabajos)
            {
                if (tiemposPorTrabajo.ContainsKey(trabajo))
                {
                    tiempoTotal += tiemposPorTrabajo[trabajo];
                    i++;
                }
            }
            return tiempoTotal;
        }
    }
}
