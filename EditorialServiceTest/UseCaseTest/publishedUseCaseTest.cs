using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using EditorialService.BL.UseCases;
using EditorialServiceTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorialServiceTest.UseCaseTest
{
    public class publishedUseCaseTest
    {
        private readonly PublishedUseCase publishedUseCase;
        public publishedUseCaseTest()
        {
            publishedUseCase = new PublishedUseCase(DbcontextHelper.setDb());
        }

        [Fact]
        public async Task getPublishedost()
        {
            //act
            var result = await publishedUseCase.getPublishedPost();
            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        async Task addComment()
        {
            //Arrange
            CommentRequest commentRequest = new CommentRequest { Comment = "asasas", editorId = 3, PostId = 1 };
            //Act
            HttpResultMessage result = await publishedUseCase.AddComment(commentRequest);
            //Assert
            Assert.Equal("Comment in post" + commentRequest.PostId + " added!", result.message);
        }

        [Fact]
        async Task addCommentError()
        {
            //Arrange
            CommentRequest commentRequest = new CommentRequest { Comment = "asasas", editorId = 3, PostId = 4 };
            //Act
            HttpResultMessage result = await publishedUseCase.AddComment(commentRequest);
            //Assert
            Assert.Equal("This post can´t be commented", result.message);
        }
    }
}
