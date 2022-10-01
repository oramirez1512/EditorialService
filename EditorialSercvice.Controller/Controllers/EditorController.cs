using EditorialService.BL.Domain.Requests;
using EditorialService.BL.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EditorController:ControllerBase
    {
        private readonly ILogger<EditorController> _logger;
        private readonly IEditorUseCase _editor;

        public EditorController(ILogger<EditorController> logger, IEditorUseCase editorUse)
        {
            _logger = logger;
            _editor = editorUse;
        }

        [HttpGet(Name = "GetPendingPosts")]
        public async Task<IActionResult> GetPendingPosts()
        {
            return Ok(await _editor.getPendingPost());
        }

        [HttpPut(Name = "AddCommentBeforePublish")]
        public async Task<IActionResult> AddCommentBeforePublish([FromBody] CommentRequest commentRequest)
        {
            return Ok(await _editor.AddComment(commentRequest));
        }


    }
}
