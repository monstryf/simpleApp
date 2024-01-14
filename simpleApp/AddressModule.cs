using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp
{
    internal class AddressModule
    {
                public Guid Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
    }
}
