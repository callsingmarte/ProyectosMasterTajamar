using System.Text.Json;
using Xunit;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleAPI.Data.Queries;
using SampleAPI.Models;
using SampleAPI.Data.Repositories;
using SampleAPI.Tests.Mocks;
using Microsoft.Extensions.Logging.Abstractions;

namespace SampleAPI.Tests;

[TestClass]
public class QueryUnitTests
{
    private BaseRepository _dataRepository;
    private ILoggerFactory _logger;

    public QueryUnitTests()
    {
        //Un objeto ILoggerFactory que se usa para crear una instancia de NullLogger que no registra nada.
        _logger = new NullLoggerFactory();
        _dataRepository = new MockRepository(_logger);
    }
    [Fact]
    public void TestGetCoursesQuery()
    {
        Query queryService = new Query(_dataRepository, _logger);
        CourseModel allCourseData = queryService.GetCourseInformation();
        Xunit.Assert.Equal("Baby's First Course", allCourseData.coursesList.FirstOrDefault(course => course.Title == "Baby's First Course").Title);
    }

}