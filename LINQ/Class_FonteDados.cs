using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_FonteDeDados
{
    public class FonteDeDados
    {
        public static List<int> GetNumeros()
        {
            List<int> numeros = new List<int>()
        {
            1 , 10, 5, 25, 277, 399
        };
            return numeros;

        }
        public static List<int> GetListaNegra()
        {
            List<int> numeros = new List<int>()
            {
                1, 5
            };
            return numeros;
        }
    }
}