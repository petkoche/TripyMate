using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Providers.Contracts;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Services.Model;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Controllers;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Models;
using TelerikAcademy.TripyMate.Web.Models.Post;

namespace TelerikAcademy.TripyMate.Tests.Admin.Controllers
{
    [TestFixture]
    public class AdminpostControllerTests
    {
        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullpostServiceIsPassedAsParameter()
        {
            //Arrange
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GridPostController(null, null));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullMapProviderIsPassedAsParameter()
        {
            //Arrange
            var postService = new Mock<IPostsService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GridPostController(postService.Object, null));
        }

        [Test]
        public void ConstructorShould_NotThrow_WhenValidArePassedAsParameters()
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var mapProvider = new Mock<IMapProvider>();

            //Act & Assert
            Assert.DoesNotThrow(() => new GridPostController(postService.Object, mapProvider.Object));
        }

        [Test]
        public void GetpostsShould_CallpostServiceMethodGetAll()
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new GridPostController(postService.Object, mapProvider.Object);

            var request = new DataSourceRequest();
            var post = new List<Post>();
            postService.Setup(c => c.GetAllList()).Returns(post);

            var postViewList = new List<GridPostViewModel>();
            mapProvider.Setup(m => m.GetMapCollection<GridPostViewModel>(It.IsAny<Object>())).Returns(postViewList);

            //Act 
            sut.GetPosts(request);

            //Assert
            postService.Verify(c => c.GetAllList(), Times.Once);
        }

        [Test]
        public void GetpostsShould_CallMapperProviderMethodGetMapCollection()
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new GridPostController(postService.Object, mapProvider.Object);

            var request = new DataSourceRequest();
            var posts = new List<Post>();
            postService.Setup(c => c.GetAllList()).Returns(posts);

            var postViewList = new List<GridPostViewModel>();
            mapProvider.Setup(m => m.GetMapCollection<GridPostViewModel>(It.IsAny<Object>())).Returns(postViewList);

            //Act 
            sut.GetPosts(request);

            //Assert
            mapProvider.Verify(m => m.GetMapCollection<GridPostViewModel>(posts), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdatepostsShould_CallpostServiceMethodEditpost(bool isDeleted)
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new GridPostController(postService.Object, mapProvider.Object);

            var content = "Description";
            var isDeleteT = isDeleted;
            var model = new GridPostViewModel()
            {
                Content = content,
                IsDeleted = isDeleteT
            };

            //Act 
            sut.UpdatePost(model);

            //Assert
            postService.Verify(c => c.EditPost(model.ID, It.Is<PostServiceModel>(s => s.Content == content && s.IsDeleted == isDeleteT)), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void UpdatepostsShould_ReturnJSON_WithModelParameter(bool isDeleted)
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new GridPostController(postService.Object, mapProvider.Object);

            var content = "Description";
            var isDeletedP = isDeleted;
            var model = new GridPostViewModel()
            {
                Content = content,
                IsDeleted = isDeletedP
            };

            //Act 
            var result = sut.UpdatePost(model) as JsonResult;

            var data = result.Data as IList<GridPostViewModel>;

            //Assert
            Assert.AreEqual(model, data[0]);
        }

        [Test]
        public void DeletepostsShould_CallpostServiceMethodDeletepost()
        {
            //Arrange
            var postService = new Mock<IPostsService>();
            var mapProvider = new Mock<IMapProvider>();
            var sut = new GridPostController(postService.Object, mapProvider.Object);

            var content = "Description";
            var model = new GridPostViewModel()
            {
                Content = content
            };

            //Act 
            sut.DeletePost(model);

            //Assert
            postService.Verify(c => c.DeletePost(model.ID), Times.Once);
        }
    }
}
