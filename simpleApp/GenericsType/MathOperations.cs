using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.GenericsType
{
    public class MathOperations<T> where T : INumber<T>
    {
        /// <summary>
        /// Method to add two numbers of type T
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public T Add(T x, T y)
        {
            return x + y;
        }
    }
}
