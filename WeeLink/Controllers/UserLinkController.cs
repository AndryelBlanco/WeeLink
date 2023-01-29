using Microsoft.AspNetCore.Mvc;
using WeeLink.Models;

namespace WeeLink.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLinkController : ControllerBase
    {
        private static List<UserLink> _users = new List<UserLink>();

        [HttpGet]
        public IEnumerable<UserLink> GetLinks()
        {
            return _users;
        }

        [HttpPost]
        public IActionResult TesteRequisicao([FromBody] UserLink batata)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _users.Add(batata);
            return Ok("CREATED WITH SUCCESS");
        }

       
    }
}
