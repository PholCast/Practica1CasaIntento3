using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Habitacion
    {
        private String nombreHab;

        private Habitante propietarioHabitacion { get; set; }
        private List<Objeto> objetos { get; set; }
        private int metroscuadrados { get; set; }
        private List<Persona> personas { get; set; }

        public Habitacion(String nombreHabitacion, int metroscuadradosHab,Habitante propietarioHab =null)

        {
            nombreHab = nombreHabitacion;
            propietarioHabitacion = propietarioHab;
            objetos = new List<Objeto>();
            metroscuadrados = metroscuadradosHab;
            personas = new List<Persona>(); //definir bien para que cuando se crea inicialmente la casa ya esté la persona.


            //Si le pasan al propietario entonces se agrega a las personas que estan en dicha habitación
            if (propietarioHabitacion != null)
            {
                personas.Add(propietarioHabitacion);
            }
        }


        //Haciendo la representacion de las habitaciones
        public override string ToString()
        {
            String representacion = "[";

            for (int i = 0; i < metroscuadrados; i++)
            {
                

                representacion += "'' ";
            }

            for (int j = 0; j < personas.Count; j++)
            {
                representacion += personas[j].Nombre[0];
            }
            representacion += "]";
            return representacion;
        }
    }
}      