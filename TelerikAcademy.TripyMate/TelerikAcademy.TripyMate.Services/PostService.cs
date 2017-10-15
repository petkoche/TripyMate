using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;
using TelerikAcademy.TripyMate.Data.UnitOfWork;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Services.Model;

namespace TelerikAcademy.TripyMate.Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostRepository postsRepo;
        private readonly IStartTownsRepository startTownsRepo;
        private readonly IEndTownsRepository endTownsRepo;
        private readonly IUserRepository userRepo;
        private readonly IUnitOfWork unitOfWork;

        public PostsService(IPostRepository postsRepo, IUserRepository userRepo, IStartTownsRepository startTownsRepo, IEndTownsRepository endTownsRepo, IUnitOfWork unitOfWork)
        {

            if (startTownsRepo == null)
            {
                throw new ArgumentNullException();
            }

            this.startTownsRepo = startTownsRepo;

            if (endTownsRepo == null)
            {
                throw new ArgumentNullException();
            }

            this.endTownsRepo = endTownsRepo;

            if (postsRepo == null)
            {
                throw new ArgumentNullException();
            }

            this.postsRepo = postsRepo;

            if (userRepo == null)
            {
                throw new ArgumentNullException();
            }

            this.userRepo = userRepo;

            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }

            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All.OrderByDescending(s => s.CreatedOn).Take(3);
        }

        public IQueryable<Post> GetAllNoLimit()
        {
            return this.postsRepo.All.OrderByDescending(s => s.CreatedOn);
        }

        public Post GetById(Guid id)
        {
            return this.postsRepo.Get(id);
        }

        public void CreatePost(Post post, string id, Guid idSt, Guid idEn)
        {
            post.CreatedOn = DateTime.Now;
            post.Author = this.userRepo.GetStr(id);
            post.StartTownId = this.startTownsRepo.Get(idSt).ID;
            post.EndTownId = this.endTownsRepo.Get(idEn).ID;

            this.postsRepo.Add(post);
            this.unitOfWork.Complete();
        }

        public void DeletePost(Guid postId)
        {
            var post = this.postsRepo.Get(postId);
            if (post == null)
            {
                throw new NullReferenceException("Post not found");
            }

            post.IsDeleted = true;
            this.postsRepo.Update(post);

            this.unitOfWork.Complete();
        }

        public void EditPost(Guid postid, string content)
        {
            var post = this.postsRepo.Get(postid);
            if (post == null)
            {
                throw new NullReferenceException("Post not found");
            }

            post.Content = content;
            post.ModifiedOn = DateTime.Now;
            this.postsRepo.Update(post);

            this.unitOfWork.Complete();
        }

        public void EditPost(Guid postId, PostServiceModel model)
        {
            var post = this.postsRepo.Get(postId);
            if (post == null)
            {
                throw new NullReferenceException("Post not found");
            }

            post.Content = model.Content;
            post.IsDeleted = model.IsDeleted;
            this.postsRepo.Update(post);

            this.unitOfWork.Complete();
        }

        public ICollection<Post> GetAllList()
        {
            return this.postsRepo.All.ToList();
        }
    }
}
