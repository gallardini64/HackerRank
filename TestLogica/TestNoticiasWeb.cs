using EjerciciosLogicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestLogica
{
    [TestClass]
    public class TestNoticiasWeb
    {
        [TestMethod]
        public void TestSuscripciones()
        {
            var google = new Google();
            var facebook = new Facebook();
            var amazon = new Amazon();
            var gratis = new Suscripcion() { Plan = Plan.Gratis };
            var basico = new Suscripcion() { Plan = Plan.Basico };
            var premium = new Suscripcion() { Plan = Plan.Premium };
            var servicio = new NoticiasWebServicio();
            servicio.Noticias = new List<Noticia>
            {
                new Noticia(){ Contenido = "Alumno de pav es descubierto haciendo trampas en el parcial y recursa la carrera"},
                new Noticia(){ Contenido = "El primer parcial de pav es aprobandon't por casi toda la comision"},
                new Noticia(){ Contenido = "se filtra audio bochornoso despues del primer parcial"},
            };
            var problema = new ProblemaWeb();
            problema.IniciarRutina(
            new List<Suscriptor>()
            {
                facebook,
                google,
                amazon
            },
            new List<Suscripcion>()
            {
                gratis,
                basico,
                premium
            }
            , servicio
            );
            Assert.IsTrue(facebook.Suscripcion == premium);
            Assert.IsTrue(google.Suscripcion == basico);
            Assert.IsTrue(amazon.Suscripcion == gratis);
            Assert.IsNotNull(facebook.Noticias);
            Assert.IsNotNull(google.Noticias);
            Assert.IsNotNull(amazon.Noticias);
        }
    }
}
