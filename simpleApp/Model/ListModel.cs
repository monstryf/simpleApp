using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.Model
{
    internal class ListModel<T>  where T : class
    {
        public int totalCount {get; set;}
        public IEnumerable<T> items { get; set;} 
    }
}
