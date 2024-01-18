using Moq;
using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    public class ProductTest
    {
        [Fact]
        public void GetPrice_GoIdCustomer_Apply30PercentDiscount()
        {
            var product = new Product { ListPrice = 100 };
            var result = product.GetPrice(new Customer { IsGoId = true });
            
            Assert.Equal(result, 70);
        }
        [Fact]
        public void GetPrice_GoIdCustomer_Apply30PercentDiscount2()
        {
            var customer = new Mock<ICustomer>();
            customer.Setup(c=>c.IsGoId).Returns(true);
            var product = new Product { ListPrice = 100 };
            var result = product.GetPrice(customer.Object);

            Assert.Equal(result, 70);
        }
    }
}
