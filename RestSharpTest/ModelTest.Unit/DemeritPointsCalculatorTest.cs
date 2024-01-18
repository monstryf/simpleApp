using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    public class DemeritPointsCalculatorTest
    {
        [Fact]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_TherowArgumentOutOfRangeException()
        {
            var calaulater = new DemeritPointsCalculator();

            Assert.Throws<ArgumentOutOfRangeException>(() => calaulater.CalculateDemeritPoints(-1));
        }
        [Theory]
        [InlineData(0,0)]
        [InlineData(65,0)]
        [InlineData(66,0)]
        [InlineData(70,1)]
        [InlineData(75,2)]
        public void CalculateDemeritPoints_SpeedIsLessThenOrEqualSpeedLimit_ReturnZero(int speed,int speeded)
        {
            var calaulater = new DemeritPointsCalculator();
            var points = calaulater .CalculateDemeritPoints(speed);
            Assert.Equal(points, speeded);
        }
    }
}
