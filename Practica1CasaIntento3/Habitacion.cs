using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Habitacion
    {
        public int Metroscuadrados { get; private set; }
        public List<Persona> Personas { get; private set; }

        public Habitacion(int metroscuadrados)
        {
            Metroscuadrados = metroscuadrados;
            Personas = new List<Persona>();
        }
    }
}