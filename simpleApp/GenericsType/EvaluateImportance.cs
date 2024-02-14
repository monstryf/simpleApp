using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.GenericsType
{
    public class EvaluateImportance : IImportance<int>, IImportance<string>
    {
        /// <summary>
        /// Return the biggest number between two numbers 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int MostImportant(int a, int b)
        {
            return a > b ? a : b;
        }
        /// <summary>
        /// Return the biggest length string between two strings
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string MostImportant(string a, string b)
        {
            return a.Length > b.Length ? a : b;
        }
    }
}
