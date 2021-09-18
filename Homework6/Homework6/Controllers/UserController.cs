using Homework6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<User> Index([FromRoute] User user)
        {
            return user;
        }
    }
}
