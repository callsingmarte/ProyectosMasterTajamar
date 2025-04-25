using SampleAPI.Domain;

namespace SampleAPI.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected List<Course> _courses { get; }
        protected ILogger _logger;

        public BaseRepository(ILoggerFactory logger)
        {
            _courses = new List<Course>();
            _logger = logger.CreateLogger("BaseRepository");
        }

        public abstract List<Course> GetCourses();
    }
}
