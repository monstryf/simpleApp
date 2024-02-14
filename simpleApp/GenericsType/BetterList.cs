using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.GenericsType
{
    public class BetterList<T>
    {
        /// <summary>
        /// Private list of type T
        /// </summary>
        private List<T> data = new();
        /// <summary>
        /// Add item to the list of type T
        /// </summary>
        /// <param name="item"></param>
        public void AddToList(T item)
        {
            data.Add(item);
            Console.WriteLine($"{item} added to the list");
        }
    }
}
