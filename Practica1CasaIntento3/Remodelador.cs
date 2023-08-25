
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Remodelador : Persona
    {
        protected bool ocupado;
        protected int tiempoOcupado;

        public Remodelador(string nombreRem, Habitacion habActual = null, bool ocupadoRem = false, int tiempoOcupado = 0)
        {
            nombre = "¡" + nombreRem + "!";
        }

        public bool Ocupado
        {
            get { return ocupado; }
            set { ocupado = value; }

        }

        public int TiempoOcupado
        {
            get { return tiempoOcupado; }
            set { tiempoOcupado = value; }

        }


        public bool RevisarObjeto(Objeto objetoRevisar)
        {
            ocupado = true;

            if(objetoRevisar.Estado == true) {

                ocupado = false;
                Console.WriteLine($"{nombre} dice: el objeto {objetoRevisar.Nombre} esta en buen estado");
                return true;
            
            }
            else {
                Console.WriteLine($"{nombre} revisa: el objeto {objetoRevisar.Nombre} esta malo");
                return false;
            }
            
        }
        public void AgregarObjetos(Casa casa, Habitacion habDecorar, List<Objeto> listaObjetos)
        {

        }

        public void agregarNuevaHab(int numero1, int numero2)
        {

        }


        public void ampliarAreaHab(int numero1, int numero2)
        {

        }

        public void decorarHab(int numero1, int numero2)
        {

        }

        public void arreglarObjetoHab(Objeto objetoArreglar)
        {
            if (objetoArreglar.Estado == false)
            {
                objetoArreglar.Estado = true;
                Console.WriteLine($"El empleado {nombre} ha arreglado el objeto {objetoArreglar.Nombre}");
                ocupado = false;
            }
            else
            {
                Console.WriteLine($"El objeto {objetoArreglar.Nombre} no tiene daños");
            }
        }

    }

}