using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Controllers;
using WebApi.JsonModels;
using Xunit;

namespace TestingController
{
    public class PostControllerTest
    {
        [Fact]
        public void Get_ReturnsAViewResult_WithAListOfPosts()
        {
            //Arrage
            var mockService = new Mock<IDataService>();
            mockService.Setup(x => x.GetPostDetail(It.IsAny<int>())).Returns(new PostExtended
            {
                PostId = 1,
                Title = "Testing Post Controller using Moq",
                Score = 60,
                PostBody = "First time using Unit Test with Moq to test the controller!",
                Answers = new List<string> { "Well, hope this works...", "Ohlala it works" },
                UserName = "Group 7 RAWDATA"       
            });
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>()))
                //Using Func + Reflection, because the id was created as an Anonymous Type in ModelFactory.
                .Returns((string urlString, object idObject) =>
                {
                    Type typeOfIdObject = idObject.GetType();
                    int valueOfIdObject =
                        (int) typeOfIdObject.GetProperty("id").GetValue(idObject, null);
                    return "http://localhost/api/posts/" + valueOfIdObject;
                });

            var controller = new PostController(mockService.Object);
            controller.Url = mockUrlHelper.Object;

            //Action
            IActionResult actionResult = controller.Get(1) ;
            OkObjectResult okObjectResult = actionResult as OkObjectResult;
            PostDetailModel asPostDetailModel = (PostDetailModel) okObjectResult.Value;

            //Assert
            Assert.Equal("http://localhost/api/posts/1", asPostDetailModel.Url);
            Assert.Equal("Testing Post Controller using Moq", asPostDetailModel.Title);
            Assert.Equal(60, asPostDetailModel.Score);
            Assert.Equal("First time using Unit Test with Moq to test the controller!", asPostDetailModel.PostBody);
            Assert.Equal("Well, hope this works...", asPostDetailModel.Answers[0]);
            Assert.Equal("Ohlala it works", asPostDetailModel.Answers[1]);
            Assert.Equal("Group 7 RAWDATA", asPostDetailModel.UserName);
        }

    }
}