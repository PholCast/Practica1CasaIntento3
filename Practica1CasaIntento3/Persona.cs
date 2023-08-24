using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Persona
    {
        protected String nombre;
        protected Habitacion habitacionActual;

        public void mover(Habitacion hab, Casa casa)
        {
            if(hab == habitacionActual)
            {
                Console.WriteLine("Error, Ya estás en esa habitacion");
                return;
            }


            List<Habitacion> habAdyacentes = casa.CalcularAdyacentes(habitacionActual.PosicionFila, habitacionActual.NumeroHabitacion);

            if (habAdyacentes.Contains(hab)){

                habitacionActual.RemoverPersona(this);

                habitacionActual = hab;

                habitacionActual.AgregarPersona(this);
            }
            else
            {
                Console.WriteLine($"No puedes moverte a la habitacion en la fila {hab.PosicionFila} y numero de habitacion {hab.NumeroHabitacion} porque no es adyacente");
            }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }
        public Habitacion HabitacionActual
        {
            get { return habitacionActual; }
            set { habitacionActual = value; }

        }
    }
}