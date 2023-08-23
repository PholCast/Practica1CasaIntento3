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

        //Diccionario filas tiene como clave la fila y como valor cuantas habitaciones tiene
        private Dictionary<int, int> diccionarioFilas;
        private bool intervencion_inicial_solicitada;


        public Casa(int n)
        {   

            intervencion_inicial_solicitada = false;
            diccionarioFilas = new Dictionary<int, int>();
            for(int t=0; t<n; t++)
            {   
                diccionarioFilas.Add(t, n);
            }

            /* Aquí está la forma de mostrar el diccionario
             
              foreach (var kvp in diccionarioFilas)
            {
                Console.WriteLine($"Fila: {kvp.Key}, Habitaciones: {kvp.Value}");
            }*/



            planoInicialCasa = new List<List<Habitacion>>();

            String[] nombresRandom = 
                {
                    "Ana", "Beto", "Carlos", "David", "Elena", "Fernando",
                    "Gabriela", "Hugo", "Irene", "Juan", "Karen", "Luis",
                    "Maria", "Nacho", "Olga", "Pedro", "Quincy", "Rosa",
                    "Sofia", "Tomas", "Ursula", "Victor", "Wendy", "Xavier",
                    "Yara", "Zoe","aaron", "brian", "carol", "david", "emily", "frank",
                    "gina", "harry", "ian", "julie", "kyle", "lisa",
                    "mike", "nina", "oscar", "paul", "quincy", "rachel",
                    "steve", "tina", "uriel", "victor", "wanda", "xander",
                    "yvonne", "zane"
                };

            String[] nombresHabitacionesRandom = {"Cocina","Sala","Baño","Cuarto1","Cuarto"};

            int cont = 0;
            for (int i = 0; i < n; i++)
            {
                List<Habitacion> filaHabitacion = new List<Habitacion>();
                for (int j = 0; j < n; j++)
                {
                    Random random = new Random();
                    //random para ver si crea  una persona o no
                    int opcionCrearpersona = random.Next(2);
                    
                    Habitante habitanteAux;
                    if(opcionCrearpersona == 0)
                    {
                        habitanteAux = null;
                    }

                    else
                    {
                        habitanteAux = new Habitante(nombresRandom[cont]);
                    }
                    


                    //Donde dice j+1 es porque representa el numero de la casa. Pero tener en cuenta que para las posiciones de la matriz tocaria restarle 1
                    Habitacion nuevaHabitacion = new Habitacion(nombresHabitacionesRandom[random.Next(nombresHabitacionesRandom.Length)],20,i,j+1,habitanteAux);

                    if (habitanteAux != null)
                    {
                        habitanteAux.HabitacionActual = nuevaHabitacion;
                    }
                    
                    filaHabitacion.Add(nuevaHabitacion); // Puedes inicializar con otros valores si lo deseas
                    cont++;            
                }
                planoInicialCasa.Add(filaHabitacion);
            }
            //planoCasa = planoInicialCasa;
            planoCasa = planoInicialCasa.Select(fila => fila.ToList()).ToList();

        }

        public bool Intervencion_inicial_solicitada
        {
            get { return intervencion_inicial_solicitada; }
            set { intervencion_inicial_solicitada = value; }
        }
        public Persona BuscarPersona(string nombrePersona)
        {
            foreach(List<Habitacion> fila  in planoCasa)
            {
                foreach(Habitacion habitacion in fila)
                {   //int cont = 0;
                    foreach (Persona persona in habitacion.Personas)
                    {
                        if (persona.Nombre[0].ToString() == nombrePersona && nombrePersona[0].ToString() != "¡")
                        {
                            Console.WriteLine("Has seleccionado a" + persona.Nombre);

                            return persona;
                        }
                        else if (nombrePersona[0] == '¡' && persona.Nombre[0].ToString() + persona.Nombre[1].ToString() == nombrePersona)
                            {

                            Console.WriteLine("Has seleccionado al trabajador: " + persona.Nombre);
                            return persona;
                        

                        }
                       // cont++; // Para que retorne en que posicion de la lista de personas de la habitacion está

                       
                    }
                }
            }
            return null;
        }




        public List<List<Habitacion>> PlanoCasa
        {
            get {return  planoCasa;}
            set { planoCasa = value;}
        }
        public void MostrarPlanos()
        {   int cont = 0;
            foreach (List<Habitacion> fila in planoCasa)
            
            {
                Console.Write($"{cont} [");
                foreach (Habitacion elemento in fila)
                {
                    Console.Write($"{elemento}");
                }
                Console.Write("]");
                Console.WriteLine();
                cont++;
            }
            Console.WriteLine();
            Console.ReadKey();
        }


        public void RemoverNuevaHab(int fila, Habitacion habitacionARemover)
        {
            diccionarioFilas[fila] -= 1;
            planoCasa[fila].Remove(habitacionARemover);
        }

        public void AgregarNuevaHab(int fila, Habitacion habCrear)
        {
            diccionarioFilas[fila] += 1;

            planoCasa[fila].Add(habCrear);

            //Console.WriteLine("");
        }
        
        //Mientras tantos
        public void AmpliarHabitacionCasa(int fila,int numeroHabitacion,double aumento)
        {
            planoCasa[fila][numeroHabitacion - 1].AmpliarHabitacion(aumento);
            MostrarPlanos();
        }
        //Para calcular en donde empieza y termina una habitacion: [posicion inicio, posicion final]
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


        public Dictionary<int,int> DiccionarioFilas
        {
            get { return diccionarioFilas; }
            set { diccionarioFilas = value;}
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
                //Console.WriteLine("no hay habitacion a la izquierda");
            }

            //Derecha
            try
            {
                habitacionesAdyacentes.Add(PlanoCasa[fila][numHabMatriz + 1]);

            }
            catch (ArgumentOutOfRangeException)
            {
                //Console.WriteLine("no hay habitacion a la derecha");
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
                //Console.WriteLine("No hay habitacion de arriba");
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

               //Console.WriteLine("Se capturó una excepción de índice fuera de rango abajo: " + ex.Message);
                
            }

            return habitacionesAdyacentes;
        }



    }

}

