using EditorialService.BL.Common;
using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.UseCases
{
    public class EditorUseCase : IEditorUseCase
    {
        public readonly EditorialDbContext db;

        public EditorUseCase(EditorialDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddComment(CommentRequest commentRequest)
        {
            return await PostQueries.addComment(true, db, commentRequest);
        }

        public async Task<PostResponse> getPendingPost()
        {
            return await PostQueries.getPosts(false, db);
        }
    }
}
