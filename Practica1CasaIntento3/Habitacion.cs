using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Habitacion
    {
        private String nombreHab;

        private Habitante propietarioHabitacion { get; set; }
        private List<Objeto> objetos { get; set; }
        private double metroscuadrados;
        private List<Persona> personas { get; set; }

        private int posicionFila;
        private int numeroHabitacion;

        public Habitacion(String nombreHabitacion, double metroscuadradosHab, int posicionFilaHab, int numeroHab, Habitante propietarioHab = null)

        {
            posicionFila = posicionFilaHab; //Esto representa la fila
            numeroHabitacion = numeroHab;   // Esto la columna o numero de la casa contando de izquierda a derecha

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

        public double MetrosCuadrados
        {
            get { return metroscuadrados; }
            set { metroscuadrados = value;}
        }
        public int PosicionFila
        {
            get { return posicionFila; }
            set { posicionFila = value;}

          
        }

        public int NumeroHabitacion
        {
            get { return numeroHabitacion; }
            set { numeroHabitacion = value; }
        }


        //Haciendo la representacion de las habitaciones
        public override string ToString()
        {
            String representacion = "[";

            for (int i = 0; i < metroscuadrados/5; i++)
            {

                if (i == metroscuadrados - 5)
                {
                    representacion += "*";
                }
                else
                {
                    representacion += "*  ";
                }

            }
            //Aqui muestra a las personas
            for (int j = 0; j < personas.Count; j++)
            {
                representacion += personas[j].Nombre[0];
            }
            representacion += "]";
            return representacion;
        }

        public bool HayPersonas()
        {

            //Conditional operator
            // variable      //condicion         //? //si se cumple : si no se cumple
            bool respuesta = (personas.Count ==0) ? false : true;



            return respuesta;
        }


        //No va aqui pero por ahora
        public void AmpliarHabitacion(double metros)
        {
            metroscuadrados += metros;
        }
    }
}      