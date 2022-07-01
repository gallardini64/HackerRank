using EjerciciosLogicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLogica
{
    [TestClass]
    public class TestTimeConvertion
    {
        [TestMethod]
        [DataRow("12:01:00PM","12:01:00")]
        [DataRow("12:01:00AM","00:01:00")]
        public void TestConvertion(string date, string expected)
        {
            var result = TimeConvertion.Convertir(date);
            Assert.AreEqual(expected, result);
        }
    }
}
