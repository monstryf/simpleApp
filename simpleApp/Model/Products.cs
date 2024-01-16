using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.Model
{
    internal class Products
    {
        public Guid id {  get; set; }
        public string code { get; set; }
        public bool isActive { get; set; }
        public string tags { get; set; }
        public bool? isQueryable { get; set; } = default!;
        public string displayName { get; set; }
    }
}
