using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories;

namespace TelerikAcademy.TripyMate.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepo;

        public PostsService(IEfRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All;
        }

        public Post GetById(Guid id)
        {
            return this.postsRepo.Get(id);
        }
    }
}
