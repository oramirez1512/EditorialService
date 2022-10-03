

using EditorialService.BL.Domain.Model.DTOS;
using EditorialService.BL.Domain.Requests;
using EditorialService.BL.Domain.Responses;
using EditorialServiceTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EditorialServiceTest.UseCaseTest
{
    public class WriterUseCaseTest
    {
        
        private readonly WriterUseCase writerUseCase;

        public WriterUseCaseTest() 
        {    
            writerUseCase = new WriterUseCase(DbcontextHelper.setDb());
        }

        [Fact]
        public async Task getMyPosts() 
        {
            //Arrange
            OwnPostRequest ownPostRequest = new OwnPostRequest { AuthorId=1};
            //Act
            PostResponse result = await writerUseCase.getPostByAuthor(ownPostRequest);
            //Assert
            Assert.NotNull(result);

        }

        [Fact]
        public async Task Createpost()
        {
            //Arrange
            CreatePostRequest  createPostRequest= new CreatePostRequest { AuthorId = 1, Content="asa", Title="" };
            //Act
            HttpResultMessage result = await writerUseCase.CreateNewPost(createPostRequest);
            //Assert
            Assert.NotNull(result);
            Assert.Equal("New post created!", result.message);

        }
        [Fact]
        public async Task EditPost() 
        {
            //Arrange
            EditPostRequest editPostRequest = new EditPostRequest { AuthorId = 1, Content = "asa", Title = "", PostId=5 };
            //Act
            HttpResultMessage result = await writerUseCase.EditPost(editPostRequest);
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Post" + editPostRequest.PostId + " updated!", result.message);
        }

        [Fact]
        public async Task EditPostError()
        {
            //Arrange
            EditPostRequest editPostRequest = new EditPostRequest { AuthorId = 1, Content = "asa", Title = "", PostId = 1 };
            //Act
            HttpResultMessage result = await writerUseCase.EditPost(editPostRequest);
            //Assert
            Assert.NotNull(result);
            Assert.Equal("This post can´t be edited", result.message);
        }

        [Fact]
        public async Task submitPost()
        {
            //Arrange
            PostRequestBase submitPostRequest = new PostRequestBase { editorId=1,PostId=5 };
            //Act
            HttpResultMessage result = await writerUseCase.SubmitPost(submitPostRequest);
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Post" + submitPostRequest.PostId + " Submited for review!", result.message);
        }
        [Fact]
        public async Task submitPostError()
        {
            //Arrange
            PostRequestBase submitPostRequest = new PostRequestBase { editorId = 1, PostId = 1 };
            //Act
            HttpResultMessage result = await writerUseCase.SubmitPost(submitPostRequest);
            //Assert
            Assert.NotNull(result);
            Assert.Equal("This post can´t be submited", result.message);
        }

    }
}
