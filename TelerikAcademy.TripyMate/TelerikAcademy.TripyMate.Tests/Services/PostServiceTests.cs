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
    public class PostServiceTests
    {
        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullstartTownRepositoryIsPassedAsParameter()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostsService(null, userRepository. Object, startTownRepository.Object, endTownRepository.Object,
                                                                        unitOfWork.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullUserRepoIsPassedAsParameter()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostsService(postsRepository.Object, null, startTownRepository.Object, endTownRepository.Object,
                                                                        unitOfWork.Object));
        }

        [Test]
        public void ConstructorShould_ThrowArgumentNullException_WhenNullStartIsPassedAsParameter()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostsService(postsRepository.Object, userRepository.Object, null, endTownRepository.Object,
                                                                        unitOfWork.Object));
        }

        public void ConstructorShould_ThrowArgumentNullException_WhenNullEndIsPassedAsParameter()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostsService(postsRepository.Object, userRepository.Object, startTownRepository.Object, null,
                                                                        unitOfWork.Object));
        }

        public void ConstructorShould_ThrowArgumentNullException_WhenNullunitOfWorkIsPassedAsParameter()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new PostsService(postsRepository.Object, userRepository.Object, startTownRepository.Object, null,
                                                                        null));
        }

        [Test]
        public void ConstructorShould_NotThrow_WhenValidParametersArePassed()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            //Act & Assert
            Assert.DoesNotThrow(() => new PostsService(postsRepository.Object, userRepository.Object, startTownRepository.Object, endTownRepository.Object,
                                                                        unitOfWork.Object));
        }

        [Test]
        public void GetAllStartTownsShould_CallCountryRepositoryMothodGetAll()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var sut = new PostsService(postsRepository.Object, userRepository.Object, startTownRepository.Object, endTownRepository.Object,
                                                                        unitOfWork.Object);

            //Act 
            sut.GetAll();

            //Assert
            postsRepository.Verify(c => c.All, Times.Once);
        }

        [Test]
        public void GetAllPostsShould_ReturnCollectionWithoutFormating()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var posts = new Post[] {
                                      new Post()
                                      {
                                          Content = "Sofia"
                                      }
                                        };
            var queryableTowns = posts.AsQueryable();

            postsRepository.Setup(c => c.All).Returns(queryableTowns);


            var sut = new PostsService(postsRepository.Object, userRepository.Object, startTownRepository.Object, endTownRepository.Object,
                                                                        unitOfWork.Object);

            //Act 
            var result = sut.GetAll();

            //Assert
            CollectionAssert.AreEqual(queryableTowns, result);
        }


        [Test]
        public void GetPostsByIdShould_ReturnCollectionWithoutFormating()
        {
            //Arrange
            var postsRepository = new Mock<IPostRepository>();
            var userRepository = new Mock<IUserRepository>();
            var startTownRepository = new Mock<IStartTownsRepository>();
            var endTownRepository = new Mock<IEndTownsRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var posts = new Post();
            posts.ID = Guid.NewGuid();

            postsRepository.Setup(t => t.Get(It.IsAny<Guid>())).Returns(posts);

            var sut = new PostsService(postsRepository.Object, userRepository.Object, startTownRepository.Object, endTownRepository.Object,
                                                                        unitOfWork.Object);
            var postId = Guid.NewGuid();

            //Act 
            var result = sut.GetById(postId);

            //Assert
            CollectionAssert.AreEqual(posts.Content, result.Content);
        }
    }
}
