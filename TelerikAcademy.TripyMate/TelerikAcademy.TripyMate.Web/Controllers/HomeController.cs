﻿using System;
using System.Linq;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Web.Models.Home;
using TelerikAcademy.TripyMate.Web.Models.Post;

namespace TelerikAcademy.TripyMate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            if(postsService == null)
            {
                throw new ArgumentNullException();
            }
            this.postsService = postsService;
        }

        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .Select(x => new PostViewModel()
                {
                    ID = x.ID,
                    FirstName = x.Author.FirstName,
                    LastName = x.Author.LastName,
                    PhoneNumber = x.Author.PhoneNumber,
                    Title = x.Title,
                    Content = x.Content,
                    PhotoId = x.Author.PhotoId,
                    AuthorEmail = x.Author.Email,
                    PostedOn = x.CreatedOn.Value,
                    StartTown = x.StartTown.Name,
                    EndTown = x.EndTown.Name
                })
                .ToList();

            var viewModel = new HomeViewModel()
            {
                Posts = posts
            };

            return View(viewModel);
        }

        [OutputCacheLongLived]
        [ChildActionOnly]
        public ActionResult PostDetailsPartial()
        {
            return this.PartialView();
        }

        [OutputCacheLongLived]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [OutputCacheLongLived]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}