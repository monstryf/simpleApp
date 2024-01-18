using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    public class ErrorLoggerTests
    {
        [Fact]
        public void Log_WhenCalled_SetTheLastErrorProerty()
        {
            var logger = new ErrorLogger();
            logger.Log("ab");
            Assert.Equal(logger.LastError, "ab");
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Log_InvalidErorr_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();
            Assert.Throws<ArgumentNullException>(()=> logger.Log(error));
        }
        [Fact]
        public void Log_ValidErorr_RaiseRrror_LoggdEvent()
        {
            var logger = new ErrorLogger();

            var Id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { Id = args; };
            logger.Log("a");
            Assert.NotEqual(Id, Guid.Empty);
        }
    }
}
