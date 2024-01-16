using simpleApp.ModelTest;
using Math = simpleApp.ModelTest.Math;

namespace RestSharpTest.ModelTest.Unit
{
    public class MathUnitTest: IDisposable
    {
        readonly Math _math;
        public MathUnitTest()
        {
            _math = new Math();
        }
        public void Dispose()
        {
           
        }
        [Fact]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {


            var Respons = _math.Add(1, 2);

            Assert.Equal(Respons, 3);
        }
        [Fact(Skip = "Because I do it in Max_WhenCalled_RetutrnTheGreaterArgument Method")]
        public void Max_FirstArgumentIsGeater_RetutrnTheFirstArgument()
        {
            

            var Respons = _math.Max(1, 2);

            Assert.Equal(Respons, 2);

        }
        [Fact(Skip = "Because I do it in Max_WhenCalled_RetutrnTheGreaterArgument Method")]
        public void Max_SecondtArgumentIsGeater_RetutrnTheSecondArgument()
        {
            

            var Respons = _math.Max(2, 1);

            Assert.Equal(Respons, 2);
        }
        [Fact(Skip = "Because I do it in Max_WhenCalled_RetutrnTheGreaterArgument Method")]
        
        public void Max_ArgumentsArEqual_ReturnTheSameArgument()
        {
            
            var Respons = _math.Max(1, 1);

            Assert.Equal(Respons, 1);
        }
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        [InlineData(1, 1, 1)]
        public void Max_WhenCalled_RetutrnTheGreaterArgument(int a, int b, int expRes)
        {


            var Respons = _math.Max(a, b);

            Assert.Equal(Respons, expRes);

        }

    }
}
