using Microsoft.AspNetCore.Mvc;

namespace HumAnalysis.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new[]
            {
                new { Name = "Medet"},
                new { Name = "Zhan"},
                new { Name = "Max"},
                new { Name = "Aray"}
            };
            return Json(users);
        }
    }
}
