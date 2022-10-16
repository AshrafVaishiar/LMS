using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lms.api.Controllers;

[ApiController]
[Route("lms/courses")]
[Authorize]
public class CoursesController : ControllerBase {

    [HttpGet]
    public IActionResult ListCourses() {
        return Ok(Array.Empty<string>());
    }
 }