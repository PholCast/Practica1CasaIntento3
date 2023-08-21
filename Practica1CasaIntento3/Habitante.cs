
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
        public Habitante(string nombreHabitante,Habitacion habitacionAct=null, string habitacionfav=null) {

        habitacionFav = habitacionfav;
        nombre = nombreHabitante;
        habitacionActual=habitacionAct;


        }

        public void SolicitarHabitacionNueva(Casa casa, int fila, Habitacion habitacionNueva)
        {
            Console.WriteLine($"{nombre} está solicitando una nueva habitación en la fila {fila}.");
            EmpresaRemodelaje.AgregarNuevaHabitacion(casa, fila, habitacionNueva);// Tal vez
        }

        public void SolicitarAmpliacionHabitacion(Casa casa, int fila, int numeroHabitacion,double aumento)
        {
            Console.WriteLine($"{nombre} está solicitando la ampliación de la habitación en la fila {fila}, número {numeroHabitacion}.");
            EmpresaRemodelaje.AmpliarHabitacion(casa, fila, numeroHabitacion,aumento); //Tal vez
        }

        private double CalcularCostoInicial(List<string> trabajos)
        {
            double costoTotal = 0;

            Dictionary<string, double> costosPorTrabajo = new Dictionary<string, double>
        {
            { "Agregar habitacion", 200000},
            { "Ampliación de habitación", 150000 },
            { "Decoración de habitación", 80000 },
            { "Arreglo en habitación", 120000 }
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

        private double CalcularTiempoTotalInicial(List<string> trabajos)
        {
            double tiempoTotal = 0;

            Dictionary<string, double> tiemposPorTrabajo = new Dictionary<string, double>
        {
            { "Agregar habitacion", 3.0},
            { "Ampliación de habitación", 2.0 },
            { "Decoración de habitación", 1.0 },
            { "Arreglo en habitación", 1.5 }
        };

            foreach (string trabajo in trabajos)
            {
                if (tiemposPorTrabajo.ContainsKey(trabajo))
                {
                    tiempoTotal += tiemposPorTrabajo[trabajo];
                }
            }

            return tiempoTotal;
        }

        public void SolicitarIntervencionInicial(Casa casa, List<string> trabajos)
        {
            double costoTotalInicial = CalcularCostoInicial(trabajos);
            double tiempoTotalInicial = CalcularTiempoTotalInicial(trabajos);

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

           // EmpresaRemodelaje.RealizarIntervencionSolicitada(casa, this, trabajos);//Tal vez
        }
    }



}
