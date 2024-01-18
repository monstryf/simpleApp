using Moq;
using simpleApp.ModelTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTest.ModelTest.Unit
{
    public class VideoServiceTest: IDisposable
    {
        private readonly Mock<IFileResder> _fileReader;
        private readonly VideoService _service;
        public VideoServiceTest() {
            _fileReader = new Mock<IFileResder>();
            _service = new VideoService(_fileReader.Object);
        }
        public void Dispose()
        {

        }

        [Fact]
        public void RederVideoTitle_EmptyFile_ReturnError()
        {


            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            

            var result = _service.ReadVideoTitle();

            Assert.Contains(result, "Error parsing the video");
        }
    }
}
