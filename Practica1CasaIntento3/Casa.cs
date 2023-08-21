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
        //Para calcular en donde empieza y termina una habitacion
        public double[] CalcularPosicionHabitacion(int posicionDeFila, int numeroDeHabitacion)
        {
            //representa la verdadera posicion en la matriz
            int NumHabitacionEnMatriz = numeroDeHabitacion - 1;


            //Se va a sumar hasta que saber en que numero empieza la habitacion que se analiza
            double posicionInicial = 0;
            for(int j=0; j<NumHabitacionEnMatriz; j++)
            {
                posicionInicial += planoCasa[posicionDeFila][j].MetrosCuadrados;
            }

            double posicionFinal = posicionInicial + planoCasa[posicionDeFila][NumHabitacionEnMatriz].MetrosCuadrados;

            double[] posiciones = { posicionInicial, posicionFinal };

            return posiciones;
        }

        public List<Habitacion> CalcularAdyacentes(int fila, int numHab)
        {
            //Esta variable guarda la posicion inicial y la final de la habitacion que queremos analizar
            double[] posicionesHabitacion = CalcularPosicionHabitacion(fila, numHab);
            
            int numHabMatriz = numHab - 1;
            List<Habitacion> habitacionesAdyacentes = new List<Habitacion>();


            //Izquierda
            try
            {
                habitacionesAdyacentes.Add(PlanoCasa[fila][numHabMatriz - 1]);
            }
            catch (ArgumentOutOfRangeException) 
            {
                Console.WriteLine("no hay habitacion a la izquierda");
            }

            //Derecha
            try
            {
                habitacionesAdyacentes.Add(PlanoCasa[fila][numHabMatriz + 1]);

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("no hay habitacion a la derecha");
            }

            //Fila de arriba
            try
            {


                for (int i = 0; i < PlanoCasa[fila - 1].Count; i++)
                {
                    //Este auxiliar analiza cada habitacion de la fila de arriba
                    //para compararla con la habitacion de la cual queremos ver adyacencia
                    double[] aux_posiciones = CalcularPosicionHabitacion(fila - 1, i+1);

                    if ((aux_posiciones[0] > posicionesHabitacion[0] && aux_posiciones[0] < posicionesHabitacion[1]) ||
                        
                        (aux_posiciones[1] < posicionesHabitacion[1] && aux_posiciones[1] > posicionesHabitacion[0]) ||

                        (posicionesHabitacion[0] > aux_posiciones[0] && posicionesHabitacion[0] < aux_posiciones[1]) || 

                        (posicionesHabitacion[1] < aux_posiciones[1] && posicionesHabitacion[1] > aux_posiciones[0]) ||

                        (aux_posiciones[0] == posicionesHabitacion[0] && aux_posiciones[1]== posicionesHabitacion[1]))
                    {
                        habitacionesAdyacentes.Add(PlanoCasa[fila - 1][i]);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("No hay habitacion de arriba");
            }
            //Fila de abajo
            try
                {
                for (int t = 0; t < PlanoCasa[fila + 1].Count; t++)
                {
                    
                    //Este auxiliar analiza cada habitacion de la fila de abajo
                    //para compararla con la habitacion de la cual queremos ver adyacencia
                    double[] aux_posiciones = CalcularPosicionHabitacion(fila + 1, t+1);
                    

                    if ((aux_posiciones[0] > posicionesHabitacion[0] && aux_posiciones[0] < posicionesHabitacion[1]) ||

                        (aux_posiciones[1] < posicionesHabitacion[1] && aux_posiciones[1] > posicionesHabitacion[0]) ||

                        (posicionesHabitacion[0] > aux_posiciones[0] && posicionesHabitacion[0] < aux_posiciones[1]) ||

                        (posicionesHabitacion[1] < aux_posiciones[1] && posicionesHabitacion[1] > aux_posiciones[0]) ||

                        (aux_posiciones[0] == posicionesHabitacion[0] && aux_posiciones[1] == posicionesHabitacion[1]))
                    {
                        habitacionesAdyacentes.Add(PlanoCasa[fila + 1][t]);
                    }
                }
            }
            
            catch (ArgumentOutOfRangeException ex)
            {

               Console.WriteLine("Se capturó una excepción de índice fuera de rango abajo: " + ex.Message);
                
            }

            return habitacionesAdyacentes;
        }



    }

}

