using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Objeto
    {
        private string nombre;
        private bool estado;
        private double precio;
        private double tamano;
        // Constructor de la clase que inicializa el estado aleatoriamente
        public Objeto(string nombreProducto, double precioObjeto,double tamanoObjeto)
        {
            nombre = nombreProducto;
            precio = precioObjeto;
            tamano = tamanoObjeto;

            // Generar un número aleatorio (0 o 1) para establecer el estado
            Random random = new Random();
            int option = random.Next(0, 2); // Genera 0 o 1, y establece el estado en consecuencia

            switch (option)
            {
                case 0:
                    estado = false; //Si es false está dañado
                    break;
                case 1:
                    estado = true; //Si es true está en buen estado
                    break;

            }

        }


        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }

        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }

        }
        public double Tamano
        {
            get { return tamano; }
            set { tamano = value; }

        }
    }
}