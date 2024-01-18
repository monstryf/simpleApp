using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    internal class FakeFileReader : IFileResder
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
