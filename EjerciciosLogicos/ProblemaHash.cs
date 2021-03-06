using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosLogicos
{
    //Ordenar por cantidad de apariciones no requiere comparacion entre los elementos de un array
    //en vez de comparar entre si se puede crear un array que cubra todos los valores posibles en un array
    //Crear un metodo que reciba una de enteros y la devuelva ordenados segun la cantidad de operaciones
    //ejemplo = [1,1,2,3,1]
    //el array de frecuencia de aparciones [0,3,1,1]
    //por lo que el array quedaria [1,1,1,2,3]
    public class OrdenarHash
    {
        public static int[] Ordenar(IEnumerable<int> lista, int maximo)
        {
            int contador = 0;
            var result = new List<int>();
            var hash = new int[maximo + 1];
            foreach (var item in lista)
            {
                hash[item]++;
            }
            foreach (var item in hash)
            {
                for (int i = 0; i < item; i++)
                {
                    result.Add(contador);
                }
                contador++;
            }
            return result.ToArray();
        }
    }
}
