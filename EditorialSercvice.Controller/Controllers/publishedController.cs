using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using EditorialService.BL.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class publishedController: ControllerBase
    {


        private readonly ILogger<publishedController> _logger;
        private readonly IPublishedUseCase _useCase;

        public publishedController(ILogger<publishedController> logger, IPublishedUseCase publishedUseCase)
        {
            _logger = logger;
            _useCase = publishedUseCase;
        }

        /// <summary>
        /// Get all published posts
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPublished")]
        public async Task<IActionResult> GetPublished()
        {
            PostResponse publishedResponse = await _useCase.getPublishedPost();
            return Ok(publishedResponse);
        }

        /// <summary>
        /// Add a comment in a published post
        /// </summary>
        /// <param name="commentRequest"></param>
        /// <returns></returns>
        [HttpPut(Name = "AddComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentRequest commentRequest)
        {
            return Ok(await _useCase.AddComment(commentRequest));
        }

    }
}
