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
        private bool tieneFavorito = false;


        private Habitante habitanteFav { get; set; }
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
            habitanteFav = propietarioHab;
            objetos = new List<Objeto>();
            metroscuadrados = metroscuadradosHab;
            personas = new List<Persona>(); //definir bien para que cuando se crea inicialmente la casa ya esté la persona.


            //Si le pasan al propietario entonces se agrega a las personas que estan en dicha habitación
            if (habitanteFav != null)
            {
                tieneFavorito = true;
                personas.Add(habitanteFav);
                habitanteFav.HabitacionFav = this;
            }
        }

        public List<Objeto> Objetos
        {
            get { return objetos; }
            set { objetos = value; }
        }

        public Habitante HabitanteFav
        {
            get { return habitanteFav; }
            set { habitanteFav = value; }
        }

        public double MetrosCuadrados
        {
            get { return metroscuadrados; }
            set { metroscuadrados = value; }
        }
        public int PosicionFila
        {
            get { return posicionFila; }
            set { posicionFila = value; }


        }
        public List<Persona> Personas
        {
            get { return personas; }
            set { personas = value; }


        }

        public int NumeroHabitacion
        {
            get { return numeroHabitacion; }
            set { numeroHabitacion = value; }
        }


        public string NombreHab
        {
            get { return nombreHab; }
            set { nombreHab = value; }
        }

        //Haciendo la representacion de las habitaciones
        public override string ToString()
        {
            String representacion = "[";

            for (int i = 0; i < metroscuadrados / 5; i++)
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
        public double CalcularEspacioObjetos()
        {
            double EspacioObjetos = 0;
            foreach (Objeto objeto in objetos)
            {
                EspacioObjetos += objeto.Tamano;
            }
            return EspacioObjetos;
        }
        public bool HayPersonas()
        {

            //Conditional operator
            // variable      //condicion         //? //si se cumple : si no se cumple
            bool respuesta = (personas.Count == 0) ? false : true;



            return respuesta;
        }


        //No va aqui pero por ahora
        public void AmpliarHabitacion(double metros)
        {
            metroscuadrados += metros;
        }
        public void RemoverPersona(Persona persona)
        {
            personas.Remove(persona);
            Console.WriteLine($"{persona.Nombre} salio de {nombreHab}");
        }

        public void AgregarPersona(Persona persona)
        {
            if (tieneFavorito == false && persona is Habitante)
            {

                //el tipo de dato no funcionaba porque entra como tipo persona
                //entonces toca convertirla a tipo Habitante
                Habitante convertirHabitanteFav = persona as Habitante;

                //Si esa persona no tenia habitacion favorita, entonces al moverse a esa sera su habitacion favorita
                if (convertirHabitanteFav.HabitacionFav == null)
                {

                    tieneFavorito = true;
                    habitanteFav = convertirHabitanteFav;
                    habitanteFav.HabitacionFav = this;
                }

                

            }
            personas.Add(persona);
            Console.WriteLine($"{persona.Nombre} entra a {nombreHab}");
        }

        
        public void MostrarObjetosHabitacion()
        {
            Console.WriteLine("Objetos en la habitacion: ");
            foreach (Objeto objetosEnHabitacion in objetos)
            {
                Console.WriteLine(objetosEnHabitacion.Nombre);
            }
        }

        public void AgregarDecoracion(List<Objeto> objetosDecorar)
        {
            foreach(Objeto objeto in objetosDecorar)
            {
                objetos.Add(objeto);
                Console.WriteLine($"Se agregó a {objeto.Nombre} la habitacion");
            }

            
        }
    }
}