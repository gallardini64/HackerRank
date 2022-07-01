using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EjerciciosLogicos
{
    //Dado un tiempo en el formato 12-horas AM/PM formato, convertir en formato militar (24 horas)
    //Nota: 12:00:00AM on a 12 hour clock is 00:00:00 on a 24-hour clock.
    //Ejemplo
    //s = 12:01:00PM
    //return 12:01:00
    //s = 12:01:00AM
    //return 00:01:00
    //Crear un metodo estatico publico Convertir que reciba un string representando una fecha y retorne un string 
    public class TimeConvertion
    {
        public static string Convertir(string fechaAMPM)
        {
            var fecha = DateTime.Parse(fechaAMPM);
            return fecha.ToString("HH:mm:ss");
        }

    }
}
