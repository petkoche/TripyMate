using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Services;
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
            this.postsService = postsService;
        }

        [OutputCache(Duration = 30)]
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}