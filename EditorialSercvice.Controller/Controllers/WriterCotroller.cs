using EditorialService.BL.Domain.Requests;
using EditorialService.BL.UseCases;
using Microsoft.AspNetCore.Mvc;
namespace EditorialService.Controller.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WriterCotroller : ControllerBase
    {


        private readonly ILogger<WriterCotroller> _logger;
        private readonly IWriterUseCase _writerUseCase;

        public WriterCotroller(ILogger<WriterCotroller> logger, IWriterUseCase writerUseCase)
        {
            _logger = logger;
            _writerUseCase = writerUseCase;
        }

        [HttpPost(Name = "GetMyPosts")]
        public async Task<IActionResult> GetMyPosts([FromBody] OwnPostRequest ownPostRequest)
        {
            return Ok(await _writerUseCase.getPostByAuthor(ownPostRequest));
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
