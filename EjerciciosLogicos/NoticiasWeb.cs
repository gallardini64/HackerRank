using System;
using System.Collections.Generic;
using System.Threading;

namespace EjerciciosLogicos
{
    //Una empresa de noticias ofrece un servicio suscripción el cual este compuesto por 3 niveles de membresía 
    //Gratis
    //Básico
    //Premium
    //Los tiempos de carga para ver las noticias varían según el plan de suscripción 30, 10 y 1 segundo respectivamente
    //las empresas interesadas son:
    //Facebook -- premium 
    //Google -- basico
    //Amazon -- gratis
    //Completa el codigo necesario para que las empresas puedan recibir noticias 
    //Para calcular el tiempo utiliza la funcion Thread.Sleep(tiempo int en milisegundos)  

    public class NoticiasWeb
    {
        public List<Noticia> Noticias { get; set; }
        public List<Noticia> EntregarNoticias()
        {
            return Noticias;
        }
    }
    public abstract class Suscriptor
    {
        public List<Noticia> Noticias { get; set; }
        public Func<List<Noticia>> DelegateRecibirNoticias;
        public Plan Plan { get; private set; }
        public virtual void RecibirNoticias(Plan plan)
        {
            Thread.Sleep(0);
        }
    }
    

    public class Noticia
    {
        public string Contenido { get; set; }
    }

    public class Facebook 
    {
        
    }
    public class Google
    {

    }
    public class Amazon
    {

    }

    public enum Plan
    {
        Premium,
        Basico,
        Gratis
    }

}
