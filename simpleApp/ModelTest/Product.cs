using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleApp.ModelTest;

public class Product
{
    public float ListPrice { get; set; }
    public float GetPrice(ICustomer customer)
    {
        if (customer.IsGoId)
        {
            return ListPrice * 0.7f;

        }
            return ListPrice;
    }
}
public class Customer : ICustomer
{
    public bool IsGoId { get; set; }
}
