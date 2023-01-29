using Microsoft.AspNetCore.Mvc;

namespace WeeLink.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class URLController : ControllerBase
    {
        [HttpPost]
        public void TesteRequisicao([FromBody] string userURL)
        {
            Console.WriteLine($"Olá Mundo -> {userURL}");
        }
    }
}
