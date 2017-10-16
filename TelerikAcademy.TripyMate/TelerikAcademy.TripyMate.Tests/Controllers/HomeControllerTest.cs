using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Web.Controllers;
using NUnit.Framework;
using Moq;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Web.Models.Post;
using TelerikAcademy.TripyMate.Web.Models.Home;
using TestStack.FluentMVCTesting;

namespace TelerikAcademy.TripyMate.Tests.Controllers
{  
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullPostServiceIsPassedAsAParameter()
        {
            //Arrange
            var postService = new Mock<IPostsService>();

            //Act & Assert
            NUnit.Framework.Assert.Throws<ArgumentNullException>(() => new HomeController(null));
        }

        [Test]
        public void ConstructorShould_NotThrow_WithValidParameters()
        {
            //Arrange
            var postService = new Mock<IPostsService>();

            //Act & Assert
            NUnit.Framework.Assert.DoesNotThrow(() => new HomeController(postService.Object));
        }

        [Test]
        public void IndexShould_CallRecipeServiceMethodGetALL_WithFalseAsParameter()
        {
            //Arrange
            var postsService = new Mock<IPostsService>();
            var controller = new HomeController(postsService.Object);

            var postList = new List<Post>();
            IQueryable<Post> queryablePosts = postList.AsQueryable();
            postsService.Setup(r => r.GetAll()).Returns(queryablePosts);

            //Act
            controller.Index();

            //Assert
            postsService.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void HomeController_ShouldExecuteAboutPorperlyWhenInvoked()
        {
            // Arrange
            var mockPostService = new Mock<IPostsService>();
            HomeController controller = new HomeController(mockPostService.Object);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void HomeController_ShouldExecuteContactPagePorperlyWhenInvoked()
        {
            // Arrange
            var mockPostService = new Mock<IPostsService>();
            HomeController controller = new HomeController(mockPostService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }

        [Test]
        public void HomeController_ShouldProvideProperDataInCorrectFormatWhenInvoked()
        {
            // Arrange
            var user = new Mock<User>();
            var startTown = new Mock<StartTown>();
            var endTown = new Mock<EndTown>();

            IList<Post> posts = new List<Post>
                {
                    new Post { ID = new Guid(), Title = "C# Unleashed", Content = "Short description here",Author = user.Object, StartTown = startTown.Object, EndTown = endTown.Object},
                    new Post { ID = new Guid(), Title = "ASP.Net Unleashed", Content = "Short description here", Author = user.Object, StartTown = startTown.Object, EndTown = endTown.Object },
                    new Post { ID = new Guid(), Title = "Silverlight Unleashed", Content = "Short description here", Author = user.Object, StartTown = startTown.Object, EndTown = endTown.Object }
                };

            IList<PostViewModel> expectedOutPut = new List<PostViewModel>
                {
                    new PostViewModel { ID = new Guid(), Title = "C# Unleashed", Content = "Short description here",AuthorEmail = user.Name, StartTown = startTown.Name, EndTown = endTown.Name},
                    new PostViewModel { ID = new Guid(), Title = "ASP.Net Unleashed", Content = "Short description here", AuthorEmail = user.Name, StartTown = startTown.Name, EndTown = endTown.Name },
                    new PostViewModel { ID = new Guid(), Title = "Silverlight Unleashed", Content = "Short description here", AuthorEmail = user.Name, StartTown = startTown.Name, EndTown = endTown.Name }
                };

            var mockPostService = new Mock<IPostsService>();           

            // Act
            IQueryable<Post> queryablePosts = posts.AsQueryable();
            mockPostService.Setup(x => x.GetAll()).Returns(queryablePosts);
            HomeController sut = new HomeController(mockPostService.Object);

            // Assert
            ViewResult result = sut.Index() as ViewResult;
            var endRes = result.Model as HomeViewModel;

            Assert.AreEqual(expectedOutPut[0].Title, endRes.Posts[0].Title);
        }

        [Test]
        public void Index_ShouldRenderDefaultView_WhenCalled()
        {
            // Arrange
            var mockPostService = new Mock<IPostsService>();
            HomeController homeController = new HomeController(mockPostService.Object);

            // Act
            ViewResult testResult = homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(testResult);
        }
    }
}
