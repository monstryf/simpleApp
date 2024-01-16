using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.Model
{
    internal class Articles
    {
        public Guid id { get ; set;}
        public string productId {get ; set;}
        public string code { get; set;}
        public Decimal price { get; set;}
        public bool isActive { get; set;}
        public string currency { get; set;}
        public string description { get; set;}
        public string displayName { get; set;}
    }
}
