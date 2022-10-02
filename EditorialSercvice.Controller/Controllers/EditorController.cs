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

        /// <summary>
        /// Get all posts pending for review
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPendingPosts")]
        public async Task<IActionResult> GetPendingPosts()
        {
            return Ok(await _editor.getPendingPost());
        }

        /// <summary>
        /// Add a comment in a pending post
        /// </summary>
        /// <param name="commentRequest"></param>
        /// <returns></returns>
        [HttpPut(Name = "AddCommentBeforePublish")]
        public async Task<IActionResult> AddCommentBeforePublish([FromBody] CommentRequest commentRequest)
        {
            return Ok(await _editor.AddComment(commentRequest));
        }

        /// <summary>
        /// Approve a post
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        [HttpPost(Name ="ApprovePost")]
        public async Task<IActionResult> ApprovePost([FromBody] PostRequestBase postRequest) 
        {
            return Ok(await _editor.ApprovePost(postRequest));
        }

        /// <summary>
        /// Reject a post and return for edit
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        [HttpPost(Name = "RejectPost")]
        public async Task<IActionResult> RejectPost([FromBody] PostRequestBase postRequest)
        {
            return Ok(await _editor.RejectPost(postRequest));
        }


    }
}
