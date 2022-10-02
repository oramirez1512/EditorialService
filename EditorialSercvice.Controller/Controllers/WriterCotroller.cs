using EditorialService.BL.Domain.Requests;
using EditorialService.BL.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Policy ="Writers")]
    
    public class WriterCotroller : ControllerBase
    {


        private readonly ILogger<WriterCotroller> _logger;
        private readonly IWriterUseCase _writerUseCase;

        public WriterCotroller(ILogger<WriterCotroller> logger, IWriterUseCase writerUseCase)
        {
            _logger = logger;
            _writerUseCase = writerUseCase;
        }
        /// <summary>
        /// Get all posts given a WriterId
        /// </summary>
        /// <param name="ownPostRequest"></param>
        /// <returns></returns>
        [HttpPost(Name = "GetMyPosts")]
        public async Task<IActionResult> GetMyPosts([FromBody] OwnPostRequest ownPostRequest)
        {
            return Ok(await _writerUseCase.getPostByAuthor(ownPostRequest));
        }
        /// <summary>
        /// Create a new post with published and submited in false per default
        /// </summary>
        /// <param name="createPostRequest"></param>
        /// <returns></returns>
        [HttpPut(Name = "CreateNewPost")]
        public async Task<IActionResult> CreateNewPost([FromBody] CreatePostRequest createPostRequest)
        {
            return Ok(await _writerUseCase.CreateNewPost(createPostRequest));
        }

        /// <summary>
        /// Edit a Post if this is not submited or published
        /// </summary>
        /// <param name="editPostRequest"></param>
        /// <returns></returns>
        [HttpPost(Name = "EditPost")]
        public async Task<IActionResult> EditPost([FromBody] EditPostRequest editPostRequest)
        {
            return Ok(await _writerUseCase.EditPost(editPostRequest));
        }

        /// <summary>
        /// Send a post for Review
        /// </summary>
        /// <param name="postRequest"></param>
        /// <returns></returns>
        [HttpPost(Name = "SubmitPost")]
        public async Task<IActionResult> SubmitPost([FromBody]PostRequestBase postRequest)
        {
            return Ok(await _writerUseCase.SubmitPost(postRequest));
        }

    }
}
