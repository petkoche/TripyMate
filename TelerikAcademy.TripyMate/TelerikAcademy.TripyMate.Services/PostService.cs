using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;
using TelerikAcademy.TripyMate.Services.Contracts;

namespace TelerikAcademy.TripyMate.Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostRepository postsRepo;

        public PostsService(IPostRepository postsRepo)
        {
            this.postsRepo = postsRepo;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All.OrderBy(s => s.CreatedOn);
        }

        public Post GetById(Guid id)
        {
            return this.postsRepo.Get(id);
        }

    }
}
