
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1CasaIntento3
{
    public class Habitante : Persona
    {

        public Habitante(string nombreHabitante, Habitacion habitacionAct=null) {
        
        nombre = nombreHabitante;
        habitacionActual=habitacionAct;


        }



    }
}