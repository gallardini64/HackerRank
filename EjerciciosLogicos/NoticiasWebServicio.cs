using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosLogicos
{
    //Una empresa de noticias ofrece un servicio suscripción el cual este compuesto por 3 niveles de membresía 
    //Gratis
    //Básico
    //Premium
    //las empresas interesadas con sus respectivos planes son:
    //Facebook -- premium 
    //Google -- basico
    //Amazon -- gratis
    //Completa el codigo necesario para que las empresas puedan recibir noticias 
    //el metodo iniciar rutina va a ser el primero en ejecutarse
    //el metodo del suscriptor para recibir las noticias se encuentra desactivado, solo sebe activarse en las implementaciones
    //
    public class ProblemaWeb
    {
        //Completar
        public void IniciarRutina(List<Suscriptor> suscriptors, List<Suscripcion> suscripcions, NoticiasWebServicio servicio)
        {
            foreach (var item in suscriptors)
            {
                AsignarSuscripcion(suscripcions, item);
                servicio.Suscribirse(item);
            }
            servicio.EntregarNoticias(suscriptors);
        }

        private static void AsignarSuscripcion(List<Suscripcion> suscripcions, Suscriptor item)
        {
            if (item.GetType() == typeof(Facebook)) item.Suscripcion = suscripcions.Where(x => x.Plan == Plan.Premium).FirstOrDefault();
            if (item.GetType() == typeof(Google)) item.Suscripcion = suscripcions.Where(x => x.Plan == Plan.Basico).FirstOrDefault();
            if (item.GetType() == typeof(Amazon)) item.Suscripcion = suscripcions.Where(x => x.Plan == Plan.Gratis).FirstOrDefault();
        }

    }

    //Completar
    public class Facebook : Suscriptor
    {
        public override void ObtenerNoticias(Suscripcion suscripcion, IEnumerable<Noticia> noticias)
        {
            Noticias = noticias.ToList();
        }
    }
    //Completar
    public class Google : Suscriptor
    {
        public override void ObtenerNoticias(Suscripcion suscripcion, IEnumerable<Noticia> noticias)
        {
            Noticias = noticias.ToList();
        }
    }
    //Completar
    public class Amazon : Suscriptor
    {
        public override void ObtenerNoticias(Suscripcion suscripcion, IEnumerable<Noticia> noticias)
        {
            Noticias = noticias.ToList();
        }
    }

    public delegate void EnviarNoticias(Suscripcion suscripcion, IEnumerable<Noticia> noticias);
    public class NoticiasWebServicio
    {
        public event EnviarNoticias EnviarASuscriptores;
        public List<Noticia> Noticias { get; set; }

        //Completar
        public void EntregarNoticias(IEnumerable<Suscriptor> suscriptors)
        {
            suscriptors.ToList().ForEach(x => OnEnviarNoticias(x.Suscripcion, Noticias));
        }
        //Completar
        public void Suscribirse(Suscriptor suscriptor)
        {
            EnviarASuscriptores += suscriptor.ObtenerNoticias;
        }
        //Completar
        protected virtual void OnEnviarNoticias(Suscripcion suscripcion, IEnumerable<Noticia> noticias)
        {
            EnviarASuscriptores?.Invoke(suscripcion,noticias);
        }
    }
    //No modificar
    public abstract class Suscriptor
    {
        public Suscripcion Suscripcion { get; set; }
        public List<Noticia> Noticias { get; set; }
       
        public virtual void ObtenerNoticias(Suscripcion suscripcion, IEnumerable<Noticia> noticias)
        {
            throw new NotImplementedException();
        }
    }

    


    public class Suscripcion
    {
        public Plan Plan { get; set; }
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
