using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.GenericsType
{
    public interface IImportance<T>
    {
        /// <summary>
        /// Return the most important item between two items
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        T MostImportant(T a, T b);
    }
}
