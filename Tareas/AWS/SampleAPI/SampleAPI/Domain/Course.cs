using Newtonsoft.Json;

namespace SampleAPI.Domain
{
    public class Course
    {
        [JsonProperty("title")]
        public string? Title { get; }

        [JsonProperty("instructor")]
        public string? Instructor { get; }

        [JsonProperty("category")]
        public string? Category { get; }

        [JsonProperty("description")]
        public string Description { get; }

        [JsonProperty("videos")]
        public List<Video>? Videos { get; }

        public Course(string title, string instructor, string category, string description, List<Video> videos)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Course needs a name");
            }
            if (string.IsNullOrEmpty(instructor))
            {
                throw new ArgumentException("Course needs an instructor");
            }
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException("Course needs a category");
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Course needs a description");
            }
            Title = title;
            Instructor = instructor;
            Category = category;
            Description = description;
            Videos = videos;
        }

    }
}
