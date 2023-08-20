using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public abstract class Persona
    {
        protected String nombre;
        protected Habitacion habitacionActual;

        public void mover(Habitacion hab)
        {
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