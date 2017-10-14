﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;
using TelerikAcademy.TripyMate.Data.UnitOfWork;
using TelerikAcademy.TripyMate.Services.Contracts;

namespace TelerikAcademy.TripyMate.Services
{
    public class PostsService : IPostsService
    {
        private readonly IPostRepository postsRepo;
        private readonly IStartTownsRepository startTownsRepo;
        private readonly IUserRepository userRepo;
        private readonly IUnitOfWork unitOfWork;

        public PostsService(IPostRepository postsRepo, IUserRepository userRepo, IStartTownsRepository startTownsRepo, IUnitOfWork unitOfWork)
        {
            this.startTownsRepo = startTownsRepo;
            this.postsRepo = postsRepo;
            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All.OrderByDescending(s => s.CreatedOn).Take(3);
        }

        public Post GetById(Guid id)
        {
            return this.postsRepo.Get(id);
        }

        public void CreatePost(Post post, string id, Guid idSt)
        {
            post.CreatedOn = DateTime.Now;
            post.Author = this.userRepo.GetStr(id);
            post.StartTown = this.startTownsRepo.Get(idSt);
            this.postsRepo.Add(post);
            this.unitOfWork.Complete();
        }

    }
}
