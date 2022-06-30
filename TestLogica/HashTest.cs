using EjerciciosLogicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLogica
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        [DataRow(3,1,1,3,2,1)]
        [DataRow(99, 63, 25, 73, 1, 98, 73, 56, 84, 86, 57, 16, 83, 8, 25, 81, 56, 9, 53, 98, 67, 99, 12, 83, 89, 80, 91, 39, 86, 76, 85, 74, 39, 25, 90, 59, 10, 94, 32, 44, 3, 89, 30, 27, 79, 46, 96, 27, 32, 18, 21, 92, 69, 81, 40, 40, 34, 68, 78, 24, 87, 42, 69, 23, 41, 78, 22, 6, 90, 99, 89, 50, 30, 20, 1, 43, 3, 70, 95, 33, 46, 44, 9, 69, 48, 33, 60, 65, 16, 82, 67, 61, 32, 21, 79, 75, 75, 13, 87, 70, 33)]
        public void TestHashProblem(int max, params int[] array)
        {
            var list = array.ToList();
            list.Sort();
            var result = OrdenarHash.Ordenar(array, max);
            Assert.IsTrue(AreEquals(result,list.ToArray()));
        }

        private bool AreEquals(int[] result, int[] vs)
        {
            for (int i = 0; i < result.Length; i++)
            {
                if(result[i] != vs[i]) return false;
            }
            return true;
        }
    }
}
