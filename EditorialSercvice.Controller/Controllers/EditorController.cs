using Microsoft.AspNetCore.Mvc;

namespace EditorialService.Controller.Controllers
{
    public class EditorController:ControllerBase
    {
        private readonly ILogger<EditorController> _logger;

        public EditorController(ILogger<EditorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPendingPosts")]
        public async Task<IActionResult> GetPendingPosts()
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
