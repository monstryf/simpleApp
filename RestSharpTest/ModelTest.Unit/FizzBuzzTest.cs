using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    public class FizzBuzzTest
    {
        [Fact]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuz()
        {
            var Respons = FizzBuzz.GetOutput(15);

            Assert.Equal(Respons, "FizzBuzz");
        }
        [Fact]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizzBuz()
        {
            var Respons = FizzBuzz.GetOutput(3);

            Assert.Equal(Respons, "Fizz");
        }
        [Fact]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnFizzBuz()
        {
            var Respons = FizzBuzz.GetOutput(5);

            Assert.Equal(Respons, "Buzz");
        }
        [Fact]
        public void GetOutput_InputIsNotDivisibleBy5Or5_ReturnTheSameNumber()
        {
            var Respons = FizzBuzz.GetOutput(1);

            Assert.Equal(Respons, "1");
        }
    }
}
