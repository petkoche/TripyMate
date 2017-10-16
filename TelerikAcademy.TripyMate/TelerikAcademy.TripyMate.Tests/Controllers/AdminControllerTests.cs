using System.Web.Mvc;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Controllers;

namespace TelerikAcademy.TripyMate.Tests.Controllers
{  
    [TestFixture]
    public class AdminControllerTests
    {
        [Test]
        public void IndexShouldReturnDefaultView_WhenCalled()
        {
            // Arrange 

            // Act
            var adminPanelController = new AdminController();

            // Act & Assert
            adminPanelController
                .WithCallTo(b => b.Index())
                    .ShouldRenderDefaultView();
        }

        [Test]
        public void IndexActionShould_CallViewWithoutName()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
        }

        [Test]
        public void IndexActionShould_CallViewWithoutModel()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.Model);
        }
    }
}
