
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

        public Remodelador(string nombreRem,Habitacion habActual,bool ocupadoRem,int tiempoOcupado)
        {
            nombre = "¡"+nombreRem+"!";
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

        public void agregarNuevaHab(int numero1, int numero2)
        {

        }


        public void ampliarAreaHab(int numero1, int numero2)
        {

        }

        public void decorarHab(int numero1, int numero2)
        {

        }

        public void arreglarObjetoHab(int numero1, int numero2)
        {

        }

    }

}