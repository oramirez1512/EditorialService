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
    public class WriterUseCase : IWriterUseCase
    {
        public readonly EditorialDbContext db;

        public WriterUseCase(EditorialDbContext db)
        {
            this.db = db;
        }

        public async Task<HttpResultMessage> CreateNewPost(CreatePostRequest createPostRequest)
        {
            await Task.Run(() =>
            {
                db.posts.Add(new Post { PostId = db.posts.Count() + 1,
                    AuthorId = createPostRequest.AuthorId,
                    Content = createPostRequest.Content,
                    Title = createPostRequest.Title,
                    IsApproved = false,
                    Submited = false });
            }
            );
            db.SaveChanges();
            return new HttpResultMessage { message="New post created!"};
        }

        public async Task<HttpResultMessage> EditPost(EditPostRequest editPostRequest)
        {
            Post post = await Task<Post>.Run(() => { return db.posts.Where(x => x.PostId == editPostRequest.PostId).FirstOrDefault(); });
            if(post.IsApproved || post.Submited) 
            {
                return new HttpResultMessage { message = "This post can´t be edited" };
            }
            post.Title = editPostRequest.Title;
            post.Content = editPostRequest.Content;
            db.posts.Update(post);
            db.SaveChanges();
            return new HttpResultMessage { message = "Post"+editPostRequest.PostId+" updated!" }; 
        }

        public async Task<PostResponse> getPostByAuthor(OwnPostRequest postRequest)
        {
            return await PostQueries.getPostsByAuthor(db, postRequest);
        }

        public async Task<HttpResultMessage> SubmitPost(PostRequestBase postRequest)
        {
            Post post = await Task<Post>.Run(() => { return db.posts.Where(x => x.PostId == postRequest.PostId).FirstOrDefault(); });
            if (post.IsApproved || post.Submited)
            {
                return new HttpResultMessage { message = "This post can´t be submited" };
            }
            post.Submited = true;
            db.posts.Update(post);
            db.SaveChanges();
            return new HttpResultMessage { message = "Post" + postRequest.PostId + " Submited for review!" };
        }
    }
}
