using System;
using System.Collections.Generic;
using System.Linq;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Services.Model;

namespace TelerikAcademy.TripyMate.Services.Contracts
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();
        IQueryable<Post> GetAllNoLimit();
        Post GetById(Guid id);

        ICollection<Post> GetAllList();

        void CreatePost(Post post, string id, Guid idSt, Guid idEn);
        void DeletePost(Guid postId);
        void EditPost(Guid postid, string content);
        void EditPost(Guid postId, PostServiceModel model);
    }
}