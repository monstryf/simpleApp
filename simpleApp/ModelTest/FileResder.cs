using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.ModelTest
{
    public interface IFileResder
    {
        public string Read(string path);
    }
    public class FileResder:IFileResder
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
