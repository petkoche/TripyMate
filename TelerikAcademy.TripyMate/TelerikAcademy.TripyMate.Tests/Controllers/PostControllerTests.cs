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
using TelerikAcademy.TripyMate.Providers.Contracts;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Models;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Controllers;
using System.Web;
using System.Security.Principal;
using System.Security.Claims;
using System.Web.Routing;

namespace TelerikAcademy.TripyMate.Tests.Controllers
{
    [TestFixture]
    public class PostControllerTests
    {
        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullPostAdminServiceIsPassedAsParameter()
        {
            //Arrange
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostController(null, null, mapProvider.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullPostServiceIsPassedAsParameter()
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var townService = new Mock<ITownService>();
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostController(null, townService.Object, null));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullMapProviderIsPassedAsParameter()
        {
            //Arrange
            var PostAdminService = new Mock<IPostsService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostController(PostAdminService.Object, null, null));
        }

        [Test]
        public void ConstructorShould_DoesNotThrow_WhenValidArePassedAsParameters()
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var townService = new Mock<ITownService>();
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            Assert.DoesNotThrow(() => new PostController(postService.Object, townService.Object, mapProvider.Object));
        }

        [Test]
        public void IndexActionShould_ReturnNotNullViewResult()
        {
            // Arrange
            var postService = new Mock<IPostsService>();
            var townService = new Mock<ITownService>();
            var mapProvider = new Mock<IMapProvider>();
            var controller = new PostController(postService.Object, townService.Object, mapProvider.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexActionShould_CallViewWithoutName()
        {
            // Arrange
            var postService = new Mock<IPostsService>();
            var townService = new Mock<ITownService>();
            var mapProvider = new Mock<IMapProvider>();
            var controller = new PostController(postService.Object, townService.Object, mapProvider.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void SearchActionShould_CallViewWithoutName()
        {
            // Arrange
            var postService = new Mock<IPostsService>();
            var townService = new Mock<ITownService>();
            var mapProvider = new Mock<IMapProvider>();
            var controller = new PostController(postService.Object, townService.Object, mapProvider.Object);

            // Act
            ViewResult result = controller.SearchPost() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void SearchActionShould_ReturnNotNullViewResult()
        {
            // Arrange
            var postService = new Mock<IPostsService>();
            var townService = new Mock<ITownService>();
            var mapProvider = new Mock<IMapProvider>();
            var controller = new PostController(postService.Object, townService.Object, mapProvider.Object);

            // Act
            ViewResult result = controller.SearchPost() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
