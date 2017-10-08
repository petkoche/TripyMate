using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Services;
using TelerikAcademy.TripyMate.Web.Models.Home;

namespace TelerikAcademy.TripyMate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsService postsService;

        public HomeController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .Select(x => new PostViewModel()
                {
                    Title = x.Title,
                    Content = x.Content,
                    AuthorEmail = x.Author.Email,
                    PostedOn = x.CreatedOn.Value
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