using lms.Application.Services.Courses;
using lms.Contracts.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace lms.api.Controllers;

//[EnableCors("corspolicy")]
[ApiController]
[Route("lms/courses")]
//[Authorize]
public class CoursesController : ControllerBase {

    private  readonly ICoursesService _coursesService;

    public CoursesController(ICoursesService coursesService)
    {
        _coursesService = coursesService;
    }

    [AllowAnonymous]
    [HttpGet("getall")]
    public IActionResult GetAll() {
        var response = _coursesService.GetAll();
        return Ok(response);
    }

    [HttpGet("get")]
    public IActionResult Get(string technology, int durationFrom, int durationTO)
    {
        var response = _coursesService.Get(technology, durationFrom, durationTO);
        return Ok(response);
    }

    [HttpGet("Info")]
    public IActionResult GetByTechnology(string technology)
    {
        var response = _coursesService.Info(technology);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost]
    //[Authorize(Roles = "admin")]
    public IActionResult Add(AddCourseRequest request)
    {
        var response = _coursesService.Add(request);
        return Ok(response);
    }

    [HttpDelete]
    //[Authorize(Roles = "admin")]
    public IActionResult Delete(string CourseName)
    {
        var response = _coursesService.Delete(CourseName);
        string message = $"course - {response.CourseName} - deleted";
        return Ok(message);
    }
}