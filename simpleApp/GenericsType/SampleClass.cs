using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.GenericsType
{
    public class SampleClass<T, U> where T : class, new()
    {
    }
}
