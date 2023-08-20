using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Casa
    {
        private List<List<String>> planoInicialCasa;
        private List<List<String>> planoCasa;
        //private List<Habitacion> habitaciones;


        public Casa(int n)
        {

            planoInicialCasa = new List<List<String>>();

            for (int i = 0; i < n; i++)
            {
                List<String> fila = new List<String>();
                for (int j = 0; j < n; j++)
                {
                    fila.Add("[]"); // Puedes inicializar con otros valores si lo deseas
                }
                planoInicialCasa.Add(fila);
            }
            planoCasa = planoInicialCasa;

        }
        public void MostrarPlanos()
        {
            foreach (List<String> fila in planoCasa)
            //pol, maldito internet
            {
                Console.Write("[");
                foreach (String elemento in fila)
                {
                    Console.Write($"{elemento}");
                }
                Console.Write("]");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

}

