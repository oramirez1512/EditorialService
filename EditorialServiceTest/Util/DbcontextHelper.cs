using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialServiceTest.Util
{
    public static class DbcontextHelper
    {
        public static EditorialDbContext setDb() 
        {
            var builder = new DbContextOptionsBuilder<EditorialDbContext>();
            builder.UseInMemoryDatabase(databaseName: "EditorialDb");
            var options = builder.Options;
            EditorialDbContext db = new EditorialDbContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            Person person1 = new Person { PersonId = 1, Name = "user1" };
            Person person2 = new Person { PersonId = 2, Name = "user2" };
            Person person3 = new Person { PersonId = 3, Name = "user3" };
            db.people.Add(person1);
            db.people.Add(person2);
            db.people.Add(person3);
            Role role1 = new Role { RoleId = 1, Name = "Writer" };
            Role role2 = new Role { RoleId = 2, Name = "Editor" };
            Role role3 = new Role { RoleId = 3, Name = "Commentarist" };
            db.roles.Add(role1);
            db.roles.Add(role2);
            db.roles.Add(role3);
            Permissions permissions1 = new Permissions { PermissionsId = 1, RoleId = 1, CanApproveReject = false, CanCreateEditPost = true };
            Permissions permissions2 = new Permissions { PermissionsId = 2, RoleId = 2, CanApproveReject = true, CanCreateEditPost = false };
            Permissions permissions3 = new Permissions { PermissionsId = 3, RoleId = 3, CanApproveReject = false, CanCreateEditPost = false };
            db.permissions.Add(permissions1);
            db.permissions.Add(permissions2);
            db.permissions.Add(permissions3);
            User user1 = new User { UserId = 1, PersonId = 1, RoleId = 1, UserName = "Writer1", Password = "123Writer" };
            User user2 = new User { UserId = 2, PersonId = 2, RoleId = 2, UserName = "Editor1", Password = "123Editor" };
            User user3 = new User { UserId = 3, PersonId = 3, RoleId = 3, UserName = "Commentarist1", Password = "123Commentarist" };
            db.users.Add(user1);
            db.users.Add(user2);
            db.users.Add(user3);
            Post post1 = new Post { PostId = 1, AuthorId = 1, ApprovedBy = 2, IsApproved = true, Title = "Title1", Content = "loremp ipsun", Submited = false };
            Post post2 = new Post { PostId = 2, AuthorId = 1, IsApproved = false, Title = "Title2", Content = "loremp ipsun", Submited = true };
            Post post3 = new Post { PostId = 3, AuthorId = 1, ApprovedBy = 2, IsApproved = true, Title = "Title3", Content = "loremp ipsun", Submited = false };
            Post post4 = new Post { PostId = 4, AuthorId = 1, IsApproved = false, Title = "Title4", Content = "loremp ipsun", Submited = true };
            Post post5 = new Post { PostId = 5, AuthorId = 1, IsApproved = false, Title = "Title4", Content = "loremp ipsun", Submited = false };
            db.posts.Add(post1);
            db.posts.Add(post2);
            db.posts.Add(post3);
            db.posts.Add(post4);
            db.posts.Add(post5);
            Comment comment1 = new Comment { CommentId = 1, PostId = 1, CommentAuthorId = 3, beforeApproved = false, Content = "Hi" };
            Comment comment2 = new Comment { CommentId = 2, PostId = 1, CommentAuthorId = 1, beforeApproved = false, Content = "Hi2" };
            Comment comment3 = new Comment { CommentId = 3, PostId = 1, CommentAuthorId = 2, beforeApproved = true, Content = "Hi3" };
            Comment comment4 = new Comment { CommentId = 4, PostId = 2, CommentAuthorId = 2, beforeApproved = true, Content = "Hi4" };
            Comment comment5 = new Comment { CommentId = 5, PostId = 2, CommentAuthorId = 2, beforeApproved = false, Content = "Hi5" };
            db.comments.Add(comment1);
            db.comments.Add(comment2);
            db.comments.Add(comment3);
            db.comments.Add(comment4);

            db.SaveChanges();
            return db;
        }
    }
}
