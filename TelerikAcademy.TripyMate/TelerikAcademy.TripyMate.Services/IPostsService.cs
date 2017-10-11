﻿using System;
using System.Linq;
using TelerikAcademy.TripyMate.Data.Model;

namespace TelerikAcademy.TripyMate.Services
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();
        Post GetById(Guid id);
    }
}