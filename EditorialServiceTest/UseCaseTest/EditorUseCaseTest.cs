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
    public class EditorUseCaseTest
    {
        private readonly EditorUseCase editorUseCase;
        public EditorUseCaseTest()
        {
            editorUseCase = new EditorUseCase(DbcontextHelper.setDb());
        }

        [Fact]
        public async Task getPendingPost() 
        {
            //act
            var result = await editorUseCase.getPendingPost();
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        async Task addComment() 
        {
            //Arrange
            CommentRequest commentRequest = new CommentRequest { Comment = "asasas", editorId = 2, PostId = 1 };
            //Act
            HttpResultMessage result = await editorUseCase.AddComment(commentRequest);
            //Assert
            Assert.Equal("Comment in Post" + commentRequest.PostId + " added!",result.message);
        }
    }
}
