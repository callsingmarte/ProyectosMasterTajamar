using Microsoft.AspNetCore.Mvc;
using SampleAPI.Data.Queries;
using SampleAPI.Domain;

namespace SampleAPI.Controllers;

[Route("api/v1/[controller]")]
public class CourseController : ControllerBase
{
    private readonly BaseQuery _queryService;
    private readonly ILogger _logger;

    public CourseController(BaseQuery queryService, ILoggerFactory logger)
    {
        _logger = logger.CreateLogger("CourseController");
        _queryService = queryService;
    }

    [HttpGet]
    public IEnumerable<Course> Get()
    {
        _logger.LogInformation("starting GET /api/v1/courses");
        return _queryService.GetCourseInformation().coursesList;
    }
}