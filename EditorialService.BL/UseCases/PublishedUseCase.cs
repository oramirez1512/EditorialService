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

        public async Task<bool> AddComment(CommentRequest commentRequest)
        {
            return await PostQueries.addComment(false, db, commentRequest);
        }

        public async Task<PostResponse> getPublishedPost()
        {
            return await PostQueries.getPosts(true, db);
        }
    }
}
