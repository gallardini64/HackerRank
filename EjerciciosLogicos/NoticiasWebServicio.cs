using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EjerciciosLogicos
{
    //Una empresa de noticias ofrece un servicio suscripción el cual este compuesto por 3 niveles de membresía 
    //Gratis
    //Básico
    //Premium
    //Los tiempos de carga para ver las noticias varían según el plan de suscripción
    //las empresas interesadas son:
    //Facebook -- premium 
    //Google -- basico
    //Amazon -- gratis
    //Completa el codigo necesario para que las empresas puedan recibir noticias 
    //Para calcular el tiempo utiliza la funcion Thread.Sleep(tiempo int en milisegundos)  

    public class Problema
    {
        //Completar
        public void IniciarRutina(List<Suscriptor> suscriptors, List<Suscripcion> suscripcions)
        {
            var servicio = new NoticiasWebServicio();
            foreach (var item in suscriptors)
            {
                if (item.GetType() == typeof(Facebook)) item.Suscripcion = suscripcions.Where(x => x.Plan == Plan.Premium).FirstOrDefault();
                servicio.Suscribirse(item);
            }
            servicio.EntregarNoticias();
        }

        
    }

    //Completar
    public class Facebook : Suscriptor
    {
        public override List<Noticia> ObtenerNoticias(Suscripcion suscripcion)
        {
            return Noticias;
        }
    }
    //Completar
    public class Google
    {

    }
    //Completar
    public class Amazon
    {

    }

    public delegate List<Noticia> EnviarNoticias(Suscripcion suscripcion);
    public class NoticiasWebServicio
    {
        public event EnviarNoticias EnviarASuscriptores;
        public List<Suscriptor> Suscriptors { get; set; } = new List<Suscriptor>();
        public List<Noticia> Noticias { get; set; }

        //Completar
        public void EntregarNoticias()
        {
            Suscriptors.ForEach(x => OnEnviarNoticias(x.Suscripcion));
        }
        //Completar
        public void Suscribirse(Suscriptor suscriptor)
        {
            Suscriptors.Add(suscriptor);
            EnviarASuscriptores += suscriptor.ObtenerNoticias;
        }
        //Completar
        protected virtual void OnEnviarNoticias(Suscripcion suscripcion)
        {
            EnviarASuscriptores?.Invoke(suscripcion);
        }
    }
    public abstract class Suscriptor
    {
        public Suscripcion Suscripcion { get; set; }
        public List<Noticia> Noticias { get; set; }

        public virtual List<Noticia> ObtenerNoticias(Suscripcion suscripcion)
        {
            Thread.Sleep(0);
            return Noticias;
        }
    }

    public interface IPublicador
    {

    }


    public class Suscripcion
    {
        public Plan Plan { get; set; }
        public int TiempoEspera { get; set; }
    }
    public enum Plan
    {
        Premium,
        Basico,
        Gratis
    }
    public class Noticia
    {
        public string Contenido { get; set; }
    }

}
