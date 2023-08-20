using System;
using System.Collections.Generic;


namespace Practica1CasaIntento3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener la fecha y hora actual
            DateTime tomorrow_ahorita = DateTime.Now;

            // Crear un nuevo objeto DateTime con una hora específica
           /* DateTime ANGEL = new DateTime(tomorrow_ahorita.Year,
            tomorrow_ahorita.Month,
            tomorrow_ahorita.Day, 7, 30, 0);

            Console.WriteLine("Fecha y hora actual: " + tomorrow_ahorita);
            Console.WriteLine("Hora específica: " + ANGEL);*/

            Casa casa1 = new Casa(3);

            casa1.MostrarPlanos();

            //Habitacion habitacion1 = new Habitacion("Cuarto",4, new Habitante("Phol"));

            //Console.WriteLine(habitacion1);


        }
    }
}