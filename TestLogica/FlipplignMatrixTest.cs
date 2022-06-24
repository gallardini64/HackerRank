using EjerciciosLogicos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestLogica
{
    [TestClass]
    public class FlipplignMatrixTest
    {
        public FlippingMatrix FlippingMatrix { get; set; } = new FlippingMatrix();
        [TestMethod]
        [DataRow(0)]
        public void FlipRowTest(int indexToFlip)
        {
            var matrix = new List<List<int>>() { 
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4}
            };
            FlippingMatrix.FlipRow(ref matrix, index: indexToFlip);
            Assert.IsTrue(FlippingMatrix.AreTheSame(matrix[indexToFlip],new List<int>() { 4,3,2,1 }));
        }

        [TestMethod]
        [DataRow(0)]
        public void FlipColumnTest(int indexToFlip)
        {
            var matrix = new List<List<int>>() {
                            new List<int>(){1,1,1,1},
                            new List<int>(){2,2,2,2},
                            new List<int>(){3,3,3,3},
                            new List<int>(){4,4,4,4}};
            FlippingMatrix.FlipColumn(ref matrix, index: indexToFlip);
            Assert.IsTrue(FlippingMatrix.AreTheSame(FlippingMatrix.GetColumn(matrix,indexToFlip), new List<int>() { 4, 3, 2, 1 }));
        }

        [TestMethod]
        public void GetQuadrantTest()
        {
            var expected = new List<List<int>>()
            {
                new List<int>(){1,2},
                new List<int>(){1,2}
            };
            var matrix = new List<List<int>>() {
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4}
            };
            var result = FlippingMatrix.GetQuadrant(matrix);
            Assert.IsTrue(FlippingMatrix.AreTheSame(result,expected));
        }

        [TestMethod]
        public void TestTranspose()
        {
            var matrix = new List<List<int>>() {
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4},
                            new List<int>(){1,2,3,4}
            };
            var expected = new List<List<int>>() {
                            new List<int>(){1,1,1,1},
                            new List<int>(){2,2,2,2},
                            new List<int>(){3,3,3,3},
                            new List<int>(){4,4,4,4}
            };
            FlippingMatrix.TransposeMatrix(ref matrix);
            Assert.IsTrue(FlippingMatrix.AreTheSame(matrix,expected));
        }

        [TestMethod]
        public void GetMaxQuadrant()
        {
            var matrix = new List<List<int>>() {
                            new List<int>(){112,42,83,119},
                            new List<int>(){56,125,56,49},
                            new List<int>(){15,78,101,43},
                            new List<int>(){62,98,114,108},
            };
            int result = FlippingMatrix.GetMaxQuadrant(matrix);
            Assert.AreEqual(414, result);
        }

        [TestMethod]
        public void CompareWithSquares()
        {
            var matrix = new List<List<int>>() {
                            new List<int>(){112,42,83,119},
                            new List<int>(){56,125,56,49},
                            new List<int>(){15,78,101,43},
                            new List<int>(){62,98,114,108},
            };
            var Expected = new List<List<int>>() {
                            new List<int>(){119,83,42,112},
                            new List<int>(){56,125,56,49},
                            new List<int>(){15,78,101,43},
                            new List<int>(){62,98,114,108},
            };
            FlippingMatrix.CompareAndChange(ref matrix, row: 0, column: 0);
            Assert.IsTrue(FlippingMatrix.AreTheSame(matrix,Expected));
        }


    }
}
