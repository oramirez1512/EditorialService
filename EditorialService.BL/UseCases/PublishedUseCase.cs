using EditorialService.BL.Common;
using EditorialService.BL.Domain.Model.DTOS;
using EditorialService.BL.Domain.Model.Entities;
using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EditorialService.BL.UseCases
{
    public class PublishedUseCase : IPublishedUseCase
    {
        public readonly EditorialDbContext db;

        public PublishedUseCase(EditorialDbContext db)
        {
            this.db = db;
        }

        public async Task<HttpResultMessage> AddComment(CommentRequest commentRequest)
        {
            HttpResultMessage result = new HttpResultMessage();

            

            if ( await PostQueries.addComment(false, db, commentRequest)) 
            {
                result.message = "Comment in post" + commentRequest.PostId + " added!";
            }
            else 
            {
                result.message = "This post can´t be commented";
            }
            return result;
        }

        public async Task<PostResponse> getPublishedPost()
        {
            return await PostQueries.getPosts(true,false, db);
        }
    }
}
