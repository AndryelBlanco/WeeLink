using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeeLink.Models;
using WeeLink.Services;
using WeeLink.Utils;

namespace WeeLink.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserLinkController : ControllerBase
    {
        private readonly DBServices _dbServices;
        private Helpers codeHelper;

        public UserLinkController (DBServices dBServices)
        {
            _dbServices = dBServices;
            codeHelper = new Helpers();
        }

        [HttpGet]
        public IActionResult GetLinks()
        {
            return NoContent();
        }

        [HttpGet("{shortLink}")]
        public async Task<IActionResult?> GetLinks(string shortLink)
        {
            if (string.IsNullOrEmpty(shortLink))
                return BadRequest("Not Found");

            var rawLink = await _dbServices.GetUserLinkAsync(shortLink);

            if (rawLink == null)
                return BadRequest("Your link not exists!");

            return !string.IsNullOrEmpty(rawLink.userLinkRaw) ? Redirect(rawLink.userLinkRaw) : BadRequest("The link not exists!");
        }

        [HttpPost]
        public async Task<string> SaveUserLink([FromBody] UserLink inputedLink)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state.");

            string shortedLink;
            string environmentHost = HttpContext.Request.Host.Value;


            var hasLinkInDB = false;
            do
            {
                shortedLink = codeHelper.randomLinkGenerator();
                hasLinkInDB = !string.IsNullOrEmpty(shortedLink) ? await _dbServices.AlreadyHasLinkInDB(shortedLink) : true;
            } while (hasLinkInDB);

            inputedLink.userLinkShorted = shortedLink;
            
            
            try
            {
                await _dbServices.SaveUserLinkAsync(inputedLink);
            }catch (Exception ex)
            {
                throw new Exception("Error ->", ex);
            }
            
            return $"{environmentHost}/{shortedLink}";
        }


       
    }
}
