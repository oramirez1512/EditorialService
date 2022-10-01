using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WriterCotroller : ControllerBase
    {


        private readonly ILogger<WriterCotroller> _logger;

        public WriterCotroller(ILogger<WriterCotroller> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetMyPosts")]
        public async Task<IActionResult> GetMyPosts()
        {
            return null;
        }

        [HttpPut(Name = "CreateNewPost")]
        public async Task<IActionResult> CreateNewPost()
        {
            return null;
        }

        [HttpPost(Name = "EditPost")]
        public async Task<IActionResult> EditPost()
        {
            return null;
        }

        [HttpPost(Name = "SubmitPost")]
        public async Task<IActionResult> SubmitPost()
        {
            return null;
        }

    }
}
