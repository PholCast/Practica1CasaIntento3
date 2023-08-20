using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class EmpresaRemodelaje
    {
        private int TrabajadoresDisponibles { get; set; }
        private double TiempoDisponible { get; set; }

        public EmpresaRemodelaje(int trabajadoresIniciales, double tiempoInicial)
        {
            TrabajadoresDisponibles = trabajadoresIniciales;
            TiempoDisponible = tiempoInicial;
        }
        public double Tiempo_AñadirNuevaHabitacion(double metrosCuadrados)
        {
            return 1.5 * metrosCuadrados;
        }

        public int Trabajadores_AñadirNuevaHabitacion(double metrosCuadrados)
        {
            return (int)Math.Ceiling(metrosCuadrados / 10) * 2;
        }

        public double Tiempo_AmpliarHabitacion(double metrosCuadrados)
        {
            return 1.0 * metrosCuadrados;
        }

        public int Trabajadores_AmpliarHabitacion(double metrosCuadrados)
        {
            return (int)Math.Ceiling(metrosCuadrados / 10);
        }

        public double Tiempo_DecorarHabitacion(int cantidadItems)
        {
            return 0.5 * cantidadItems;
        }

        public int Trabajadores_DecorarHabitacion()
        {
            return 1;
        }

        public double Tiempo_ArreglarHabitacion(int cantidadItems)
        {
            return 1.0 * cantidadItems;
        }

        public int Trabajadores_ArreglarHabitacion(int cantidadItems)
        {
            return cantidadItems;
        }

        public void AgregarNuevaHabitacion(Casa casa, int fila, Habitacion habitacion)
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
                Console.WriteLine("No hay suficientes recursos disponibles para agregar una nueva habitación.");
            }
        }

        public void AmpliarHabitacion(Casa casa, int fila, int numeroHabitacion,double aumento)
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
                Console.WriteLine("No hay suficientes recursos disponibles para ampliar la habitación.");
            }
        }

    }
}
