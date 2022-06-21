using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EjerciciosLogicos
{
    public class FlippingMatrix
    {
        public List<List<int>> Matrix { get; set; }
        public int GetMaxQuadrant(List<List<int>> matrix)
        {
            SortColumns(matrix);
            SortRows(matrix);
            var result = GetQuadrant(matrix);
            return result.Sum(x => x.Sum());
        }

        public void FlipRow(List<List<int>> matrix, int index)
        {
            matrix[index].Reverse();
        }

        public bool AreTheSame(List<int> list1, List<int> list2)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i]) return false;
            }
            return true;
        }

        public void FlipColumn(ref List<List<int>> matrix, int index)
        {
            for (int i = 0; i < matrix.Count / 2; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (j == index)
                    {
                        var aux = matrix[i][j];
                        matrix[i][j] = matrix[matrix.Count - 1 - i][j];
                        matrix[matrix.Count - 1 - i][j] = aux;
                    }
                }
            }
        }

        public static void TransposeMatrix(ref List<List<int>> matrix)
        {
            var listAux = new int[matrix.Count,matrix.Count];
            for (var row = 0; row < matrix.Count;   row++)
            {
                for (var column = 0; column < matrix.Count; column++)
                {
                    listAux[row,column] = matrix[column][row];
                }
            }
            matrix = ToList(listAux);
        }

        private static List<List<int>> ToList(int[,] array)
        {
            var list = new List<List<int>>();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                var aux = new List<int>();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    aux.Add(array[i,j]);
                }
                list.Add(aux);
            }
            return list;
        }

        public List<int> GetColumn(List<List<int>> matrix, int columnNumber)
        {
            var list = new List<int>();
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (columnNumber == j) list.Add(matrix[i][j]);
                }
            }
            return list;
        }

        public bool AreTheSame(List<List<int>> result, List<List<int>> expected)
        {
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result.Count; j++)
                {
                    if(result[i][j] != expected[i][j]) return false;
                }
            }
            return true;
        }


        private void SortColumns(List<List<int>> matrix)
        {
            var acc1 = 0;
            var acc2 = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (j < matrix.Count / 2) acc1 += matrix[j][i];
                    else acc2 += matrix[j][i];
                }
                if (acc1 < acc2) FlipColumn(ref matrix, i);
                acc1 = 0;
                acc2 = 0;
            }
        }

        private void SortRows(List<List<int>> matrix)
        {
            var acc1 = 0;
            var acc2 = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (j < matrix.Count / 2) acc1 += matrix[i][j];
                    else acc2 += matrix[i][j];
                }
                if (acc1 < acc2) FlipRow(matrix, i);
                acc1 = 0;
                acc2 = 0;
            }
        }

        public void CompareAndChange(List<List<int>> matrix, int row, int column)
        {
            var longitud = matrix.Count;
            var l = matrix.Count - 1;
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    var rightTopCorner = matrix[l-i][j];
                    var leftBaseCorner = matrix[i][l-j];
                    var rightBaseCorner = matrix[l-i][l-j];
                    var array = new List<(int valor, int x, int y)>();
                    array.Add((matrix[i][j], i, j));
                    array.Add((rightTopCorner, l-i, j));
                    array.Add((leftBaseCorner, i, l-j));
                    array.Add((rightBaseCorner, l-i, l-j));
                    var max = array.Max();
                    if (max.valor == rightTopCorner) FlipRow(matrix, max.x);
                    if (max.valor == leftBaseCorner) FlipColumn(ref matrix, max.y);
                    if (max.valor == rightTopCorner) 
                    {
                        FlipColumn(ref matrix, max.y);
                        FlipRow(matrix, max.x);
                    }
                }
            }
        }

        public List<List<int>> GetQuadrant(List<List<int>> matrix)
        {
            var result = new List<List<int>>();
            for (int i = 0; i < matrix.Count/2; i++)
            {
                var aux = new List<int>();
                for (int j = 0; j < matrix.Count/2; j++)
                {
                    aux.Add(matrix[i][j]);
                }
                result.Add(aux);
            }
            return result;
        }
    }


}
