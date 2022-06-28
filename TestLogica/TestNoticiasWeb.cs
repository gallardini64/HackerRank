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
        public Task TestSuscripciones()
        {
            var problema = new Problema();
            problema.IniciarRutina(
            new List<Suscriptor>()
            {
                new Facebook()
            },
            new List<Suscripcion>()
            {
                new Suscripcion(){Plan = Plan.Premium, TiempoEspera = 0},
                new Suscripcion(){Plan = Plan.Basico, TiempoEspera = 10},
                new Suscripcion(){Plan = Plan.Gratis, TiempoEspera = 30},
            });
            return Task.FromResult(0);
        }
    }
}
