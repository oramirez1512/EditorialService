using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.UseCases
{
    public interface IPublishedUseCase
    {
        Task<PostResponse> getPublishedPost();
        Task<HttpResultMessage> AddComment(CommentRequest commentRequest);
    }
}
