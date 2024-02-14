using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace simpleApp.ModelTest
{
    public class VideoService
    {
        private IFileResder _fileResder { get; set; }


        public VideoService(IFileResder fileResder)
        {
            _fileResder = fileResder;
        }
        public string ReadVideoTitle()
        {
            var str = _fileResder.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
            {
                return "Error parsing the video";
            }
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            using (var context = new VideoContext())
            {
                var videos = (from video in context.Videos
                              where !video.IsPocessed
                              select video).ToList();
                foreach (var v in videos)
                {
                    videoIds.Add(v.Id);
                }
                return string.Join(",", videoIds);
            }
        }

    }
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsPocessed { get; set; }
    }
    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}
