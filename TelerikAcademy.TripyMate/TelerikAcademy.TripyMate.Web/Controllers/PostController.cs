using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Services;
using TelerikAcademy.TripyMate.Web.Models.Home;
using TelerikAcademy.TripyMate.Web.Models.Post;

namespace TelerikAcademy.TripyMate.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostsService postsService;

        public PostController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public ActionResult Index()
        {
            var posts = this.postsService
                            .GetAll()
                            .Select(x => new PostViewModel()
                            {
                                ID = x.ID,
                                Title = x.Title,
                                Content = x.Content,
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

        // Get post by id
        [HttpGet]
        public ActionResult Index(Guid id)
        {
            var getPost = this.postsService.GetById(id);

            var model = new PostViewModel() {                
                Title = getPost.Title,
                Content = getPost.Content,
                AuthorEmail = getPost.Author.Email,
                PostedOn = getPost.CreatedOn.Value,
                StartTown = getPost.StartTown.Name,
                EndTown = getPost.EndTown.Name
            };

            return View(model);
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