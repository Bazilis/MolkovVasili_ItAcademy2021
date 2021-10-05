using Homework8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // GET user/index/{name}
        [HttpGet]
        [Route("[action]/{name}")]
        public ActionResult<UserItem> Index([FromRoute] UserItem user)
        {
            return user;
        }
    }
}
