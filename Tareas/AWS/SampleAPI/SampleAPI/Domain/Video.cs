using Newtonsoft.Json;

namespace SampleAPI.Domain
{
    public class Video
    {
        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("subsection")]
        public string? SubsectionName { get; set; }

        [JsonProperty("course")]
        public string? CourseName { get; set; }

        public Video(string title, string subsection, string description, string course)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Video needs a title");
            }
            if (string.IsNullOrEmpty(subsection))
            {
                throw new ArgumentException("Video needs an subsection name");
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Video needs a description");
            }
            if (string.IsNullOrEmpty(course))
            {
                throw new ArgumentException("Video needs a course");
            }
            Title = title;
            SubsectionName = subsection;
            Description = description;
            CourseName = course;
        }
    }
}
