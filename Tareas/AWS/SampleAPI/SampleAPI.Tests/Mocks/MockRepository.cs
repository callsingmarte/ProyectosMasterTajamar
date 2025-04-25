using SampleAPI.Data.Repositories;
using SampleAPI.Domain;

namespace SampleAPI.Tests.Mocks
{
    public class MockRepository : BaseRepository
    {
        public MockRepository(ILoggerFactory logger) : base(logger)
        {
            _logger = logger.CreateLogger<MockRepository>();
        }

        public override List<Course> GetCourses()
        {
            List<Course> _courses = new List<Course>();
            Course course1 = new Course("Baby's First Course", "Marwan Nakhaleh", "APIs", "this is a course", new List<Video>());
            Course course2 = new Course("Yet Another Course", "Marwan Nakhaleh", "APIs", "this is another course", new List<Video>());
            _courses.Add(course1);
            _courses.Add(course2);
            return _courses;
        }
    }
}
