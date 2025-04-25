using SampleAPI.Data.Repositories;
using SampleAPI.Domain;
using SampleAPI.Models;

namespace SampleAPI.Data.Queries
{
    public class Query : BaseQuery
    {
        public Query(BaseRepository repository, ILoggerFactory logger) : base(repository, logger)
        {
            _repository = repository;
            _logger = logger.CreateLogger("Query");
        }
        public override CourseModel GetCourseInformation()
        {
            _logger.LogInformation("retrieving course data for client");
            return new CourseModel(_repository.GetCourses());
        }
    }
}
