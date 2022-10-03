using EditorialService.BL.Domain.Model.DTOS;
using EditorialService.BL.Domain.Model.Entities;
using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialService.BL.Common
{
    public static class PostQueries
    {
        public static async Task<PostResponse> getPosts(bool isApproved,bool submited, EditorialDbContext db) 
        {
            List<Post> posts = await Task<List<Post>>.Run(() => { return db.posts.Where(x => x.IsApproved== isApproved && x.Submited== submited).ToList(); });
            PostResponse postResponse = new PostResponse();
            postResponse.posts = new List<PostDTO>();
            foreach (var post in posts)
            {
                List<Comment> comments = await Task<List<Comment>>.Run(() => { return db.comments.Where(x => x.PostId == post.PostId && !(x.beforeApproved==isApproved)).ToList(); });
                PostDTO postDTO = new PostDTO
                {
                    Title = post.Title,
                    ApprovedBy = post.ApprovedBy,
                    AuthorId = post.AuthorId,
                    PostId = post.PostId,
                    Content = post.Content,
                    IsApproved = post.IsApproved,
                    Comments = comments,
                    Submited= post.Submited
                };
                postResponse.posts.Add(postDTO);
            }
            return postResponse;
        }

        public static async Task<bool> addComment(bool beforeApproved,EditorialDbContext db, CommentRequest commentRequest) 
        {
            Post post = await Task<Post>.Run(() => { return db.posts.Where(x => x.PostId == commentRequest.PostId).FirstOrDefault(); });
            User user = await Task<User>.Run(() => { return db.users.Where(x => x.UserId == commentRequest.editorId).FirstOrDefault(); });
            if(post != null) {
                if((post.Submited)&& user.RoleId != 2) 
                {
                    return false;
                }
                db.comments.Add(new Comment { PostId = commentRequest.PostId,
                    beforeApproved=beforeApproved,
                    CommentId=db.comments.Count()+1,
                    CommentAuthorId=commentRequest.editorId,
                     Content=commentRequest.Comment});
                db.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public static async Task<PostResponse> getPostsByAuthor(EditorialDbContext db, OwnPostRequest postRequest) 
        {
            List<Post> posts = await Task<List<Post>>.Run(() => { return db.posts.Where(x => x.AuthorId==postRequest.AuthorId).ToList(); });
            PostResponse postResponse = new PostResponse();
            postResponse.posts = new List<PostDTO>();
            foreach (var post in posts)
            {
                List<Comment> comments = await Task<List<Comment>>.Run(() => { return db.comments.Where(x => x.PostId == post.PostId).ToList(); });
                PostDTO postDTO = new PostDTO
                {
                    Title = post.Title,
                    ApprovedBy = post.ApprovedBy,
                    AuthorId = post.AuthorId,
                    PostId = post.PostId,
                    Content = post.Content,
                    IsApproved = post.IsApproved,
                    Comments = comments,
                    Submited= post.Submited,
                };
                postResponse.posts.Add(postDTO);
            }
            return postResponse;
        }
    }
}
