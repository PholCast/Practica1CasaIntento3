using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Practica1CasaIntento3
{
    public class Casa
    {
        private List<List<Habitacion>> planoInicialCasa;
        private List<List<Habitacion>> planoCasa;
        private Dictionary<int, int> diccionarioFilas;
        //private List<Habitacion> habitaciones;


        public Casa(int n)
        {
            diccionarioFilas = new Dictionary<int, int>();
            for(int t=1; t<=n; t++)
            {   
                diccionarioFilas.Add(t, n);
            }

            /* Aquí está la forma de mostrar el diccionario
             
              foreach (var kvp in diccionarioFilas)
            {
                Console.WriteLine($"Fila: {kvp.Key}, Habitaciones: {kvp.Value}");
            }*/



            planoInicialCasa = new List<List<Habitacion>>();

            String[] nombresRandom = { "Phol", "Daniela", "Angel", "Norberto", "Ermes", "Roger", "Magola","Esteban","Urnilgo","muaro" };

            String[] nombresHabitacionesRandom = {"Cocina","Sala","Baño","Cuarto1","Cuarto2","Cuarto3","Cuarto4","Cuarto5","Cuarto9"};

            int cont = 0;
            for (int i = 0; i < n; i++)
            {
                List<Habitacion> filaHabitacion = new List<Habitacion>();
                for (int j = 0; j < n; j++)
                {
                    Habitante habitanteAux = new Habitante(nombresRandom[cont]);
                    
                    Habitacion nuevaHabitacion = new Habitacion(nombresHabitacionesRandom[cont],2,habitanteAux);

                    habitanteAux.HabitacionActual= nuevaHabitacion;
                    
                    filaHabitacion.Add(nuevaHabitacion); // Puedes inicializar con otros valores si lo deseas
                    cont++;            
                }
                planoInicialCasa.Add(filaHabitacion);
            }
            planoCasa = planoInicialCasa;

        }
        public void MostrarPlanos()
        {
            foreach (List<Habitacion> fila in planoCasa)
            
            {
                Console.Write("[");
                foreach (Habitacion elemento in fila)
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

