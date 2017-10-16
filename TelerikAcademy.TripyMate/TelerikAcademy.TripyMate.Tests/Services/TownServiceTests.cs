using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;
using TelerikAcademy.TripyMate.Data.UnitOfWork;
using TelerikAcademy.TripyMate.Services;

namespace TelerikAcademy.TripyMate.Tests.Services
{
    [TestFixture]
    class TownServiceTests
    {
        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullstartTownRepositoryIsPassedAsParameter()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TownService(null,
                                                                        endTownRepository.Object,
                                                                        unitOfWork.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullEndTownRepositoryIsPassedAsParameter()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TownService(startTownRepository.Object, null, unitOfWork.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullAddressRepositoryIsPassedAsParameter()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new TownService(startTownRepository.Object, endTownRepository.Object, null));
        }

        [Test]
        public void ConstructorShould_NotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.DoesNotThrow(() => new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object));
        }

        [Test]
        public void GetAllStartTownsShould_CallCountryRepositoryMothodGetAll()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var sut = new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object);

            //Act 
            sut.GetAllStartTowns();

            //Assert
            startTownRepository.Verify(c => c.All, Times.Once);
        }

        [Test]
        public void GetAllEndTownsShould_CallCountryRepositoryMothodGetAll()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var sut = new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object);

            //Act 
            sut.GetAllEndTowns();

            //Assert
            endTownRepository.Verify(c => c.All, Times.Once);
        }

        [Test]
        public void GetAllStartTownshould_ReturnCollectionWithoutFormating()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();

            var startTowns = new StartTown[] {
                                      new StartTown()
                                      {
                                          Name = "Sofia"
                                      }
                                        };
            var queryableTowns = startTowns.AsQueryable();

            startTownRepository.Setup(c => c.All).Returns(queryableTowns);


            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var sut = new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object);

            //Act 
            var result = sut.GetAllStartTowns();

            //Assert
            CollectionAssert.AreEqual(startTowns, result);
        }

        [Test]
        public void GetAllEndTownsShould_ReturnCollectionWithoutFormating()
        {
            //Arrange
            var endTownRepository = new Mock<IEndTownsRepository>();

            var endTowns = new EndTown[] {
                                      new EndTown()
                                      {
                                          Name = "Sofia"
                                      }
                                        };
            var queryableTowns = endTowns.AsQueryable();

            endTownRepository.Setup(c => c.All).Returns(queryableTowns);


            var startTownRepository = new Mock<IStartTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var sut = new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object);

            //Act 
            var result = sut.GetAllEndTowns();

            //Assert
            CollectionAssert.AreEqual(endTowns, result);
        }

        [Test]
        public void GetTownsByStartIdShould_ReturnCollectionWithoutFormating()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var startTowns = new StartTown();
            startTowns.ID = Guid.NewGuid();

            startTownRepository.Setup(t => t.Get(It.IsAny<Guid>())).Returns(startTowns);

            var sut = new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object);
            var startTownId = Guid.NewGuid();

            //Act 
            var result = sut.GetByIdStartTowns(startTownId);

            //Assert
            CollectionAssert.AreEqual(startTowns.Name, result.Name);
        }

        public void GetTownsByEndIdShould_ReturnCollectionWithoutFormating()
        {
            //Arrange
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var endTowns = new EndTown();
            endTowns.ID = Guid.NewGuid();

            endTownRepository.Setup(t => t.Get(It.IsAny<Guid>())).Returns(endTowns);

            var sut = new TownService(startTownRepository.Object, endTownRepository.Object, unitOfWork.Object);
            var endTownId = Guid.NewGuid();

            //Act 
            var result = sut.GetByIdStartTowns(endTownId);

            //Assert
            CollectionAssert.AreEqual(endTowns.Name, result.Name);
        }
    }
}
