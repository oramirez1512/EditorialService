using Microsoft.AspNetCore.Mvc;

namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class publishedController: ControllerBase
    {


        private readonly ILogger<publishedController> _logger;

        public publishedController(ILogger<publishedController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPublished")]
        public async Task<IActionResult> GetPublished()
        {
            return null;
        }

        [HttpPut(Name = "AddComment")]
        public async Task<IActionResult> AddComment()
        {
            return null;
        }

    }
}
