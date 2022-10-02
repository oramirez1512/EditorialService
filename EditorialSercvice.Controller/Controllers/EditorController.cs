using EditorialService.BL.Domain.Requests;
using EditorialService.BL.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize (Policy = "Editors")]
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

        [HttpPost(Name ="ApprovePost")]
        public async Task<IActionResult> ApprovePost([FromBody] PostRequestBase postRequest) 
        {
            return Ok(await _editor.ApprovePost(postRequest));
        }

        [HttpPost(Name = "RejectPost")]
        public async Task<IActionResult> RejectPost([FromBody] PostRequestBase postRequest)
        {
            return Ok(await _editor.RejectPost(postRequest));
        }


    }
}
