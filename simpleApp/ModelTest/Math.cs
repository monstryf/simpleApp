using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.ModelTest
{
    public class Math
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Max(int a , int b)
        {
            return (a>b)?a:b;
        }
        public IEnumerable<int> GetOddNumber(int Limit)
        {
            for (var i = 0; i<= Limit; i++)
            {
                if(i%2 != 0)
                {
                    yield return i;
                }
            }
        }
    }
}
