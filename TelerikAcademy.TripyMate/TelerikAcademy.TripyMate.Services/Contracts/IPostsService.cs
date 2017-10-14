using System;
using System.Linq;
using TelerikAcademy.TripyMate.Data.Model;

namespace TelerikAcademy.TripyMate.Services.Contracts
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();
        IQueryable<Post> GetAllNoLimit();
        Post GetById(Guid id);
        void CreatePost(Post post, string id, Guid idSt, Guid idEn);
    }
}