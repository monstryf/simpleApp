using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    public class VideoServiceTest
    {
        [Fact]
        public void RederVideoTitle_EmptyFile_ReturnError()
        {
            var service = new VideoService();

            service.fileResder = new FakeFileReader();

            var result = service.ReadVideoTitle();

            Assert.Contains(result, "Error parsing the video");
        }
    }
}
