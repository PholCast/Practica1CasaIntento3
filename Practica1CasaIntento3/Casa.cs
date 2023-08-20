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
        private List<List<Habitacion>> planoCasa { get; set; }
        private Dictionary<int, int> diccionarioFilas;
       


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

            String[] nombresRandom = { 
                "Phol", "Daniela", "Angel", "Norberto", "Ermes", 
                "Roger", "Magola","Esteban","Urnilgo","muaro",
                "Alice", "Bob", "Charlie", "David", "Emily",
            "Fiona", "George", "Hannah", "Isaac", "Julia" };

            String[] nombresHabitacionesRandom = {"Cocina","Sala","Baño","Cuarto9"};

            int cont = 0;
            for (int i = 0; i < n; i++)
            {
                List<Habitacion> filaHabitacion = new List<Habitacion>();
                for (int j = 0; j < n; j++)
                {
                    Random random = new Random();
                    Habitante habitanteAux = new Habitante(nombresRandom[cont] );

                    //Donde dice j+1 es porque representa el numero de la casa. Pero tener en cuenta que para las posiciones de la matriz tocaria restarle 1
                    Habitacion nuevaHabitacion = new Habitacion(nombresHabitacionesRandom[random.Next(nombresHabitacionesRandom.Length)],20,i,j+1,habitanteAux);

                    habitanteAux.HabitacionActual= nuevaHabitacion;
                    
                    filaHabitacion.Add(nuevaHabitacion); // Puedes inicializar con otros valores si lo deseas
                    cont++;            
                }
                planoInicialCasa.Add(filaHabitacion);
            }
            //planoCasa = planoInicialCasa;
            planoCasa = planoInicialCasa.Select(fila => fila.ToList()).ToList();

        }

        public List<List<Habitacion>> PlanoCasa
        {
            get {return  planoCasa;}
            set { planoCasa = value;}
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
            Console.WriteLine();
            Console.ReadKey();
        }

        public void AgregarNuevaHab(int fila, Habitacion habCrear)
        {
            diccionarioFilas[fila] += 1;

            planoCasa[fila-1].Add(habCrear);

            //Console.WriteLine("");
        }
        
        //Mientras tantos
        public void AmpliarHabitacionCasa(int fila,int numeroHabitacion,double aumento)
        {
            planoCasa[fila-1][numeroHabitacion - 1].AmpliarHabitacion(aumento);
        }


    }

}

