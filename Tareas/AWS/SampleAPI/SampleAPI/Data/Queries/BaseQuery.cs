using SampleAPI.Data.Repositories;
using SampleAPI.Models;

namespace SampleAPI.Data.Queries
{
    public abstract class BaseQuery
    {
        protected ILogger _logger;
        protected BaseRepository _repository;

        public BaseQuery(BaseRepository repository, ILoggerFactory logger)
        {
            _repository = repository;
            _logger = logger.CreateLogger("BaseQuery");
        }
        public abstract CourseModel GetCourseInformation();
    }
}
