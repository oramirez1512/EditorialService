using EditorialService.BL.Common;
using EditorialService.BL.Domain.Model.Entities;
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

        public async Task<HttpResultMessage> AddComment(CommentRequest commentRequest)
        {
            HttpResultMessage httpResult = new HttpResultMessage();
            if( await PostQueries.addComment(true, db, commentRequest)) 
            {
                httpResult.message = "Comment in Post"+commentRequest.PostId+" added!";
            }
            return httpResult;
        }

        public async Task<HttpResultMessage> ApprovePost(PostRequestBase postRequest)
        {
            Post post = await Task<Post>.Run(() => { return db.posts.Where(x => x.PostId == postRequest.PostId).FirstOrDefault(); });
            if (!(post.Submited) || (post.IsApproved)) 
            {
                return new HttpResultMessage { message = "thes Post" + postRequest.PostId + " is published yet or the author not submitted this for review!" };
            }
            post.IsApproved = true;
            post.ApprovedBy = postRequest.editorId;
            post.Submited = false;
            db.posts.Update(post);
            db.SaveChanges();
            return new HttpResultMessage { message="Post"+postRequest.PostId+" Approved!"};
        }

        public async Task<PostResponse> getPendingPost()
        {
            return await PostQueries.getPosts(false, true, db);
        }

        public async Task<HttpResultMessage> RejectPost(PostRequestBase postRequest)
        {
            Post post = await Task<Post>.Run(() => { return db.posts.Where(x => x.PostId == postRequest.PostId).FirstOrDefault(); });
            if ((post.Submited) || (post.IsApproved))
            {
                return new HttpResultMessage { message = "thes Post" + postRequest.PostId + " is published yet or the author not submitted this for review!" };
            }
            post.ApprovedBy = postRequest.editorId;
            post.Submited = false;
            db.posts.Update(post);
            db.SaveChanges();
            return new HttpResultMessage { message = "Post" + postRequest.PostId + " is returned for edit!" };
        }
    }
}
