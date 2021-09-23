using Homework7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework7.Controllers
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
