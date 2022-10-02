using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.UseCases
{
    public interface IWriterUseCase
    {
        Task<PostResponse> getPostByAuthor(OwnPostRequest postRequest);
        Task<HttpResultMessage> CreateNewPost(CreatePostRequest createPostRequest);
        Task<HttpResultMessage> EditPost(EditPostRequest editPostRequest);

        Task<HttpResultMessage> SubmitPost(PostRequestBase postRequest); 
    }
}
