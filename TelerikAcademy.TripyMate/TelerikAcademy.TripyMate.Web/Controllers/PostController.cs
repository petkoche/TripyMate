using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Services;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Web.Models.Home;
using TelerikAcademy.TripyMate.Web.Models.Post;

namespace TelerikAcademy.TripyMate.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ITownService townService;

        public PostController(IPostsService postsService, ITownService townService)
        {
            this.postsService = postsService;
            this.townService = townService;
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

        // Get post by id
        [HttpGet]
        public ActionResult Index(Guid id)
        {
            var getPost = this.postsService.GetById(id);

            var model = new PostViewModel() {

                FirstName = getPost.Author.FirstName,
                LastName = getPost.Author.LastName,
                PhoneNumber = getPost.Author.PhoneNumber,
                Title = getPost.Title,
                Content = getPost.Content,
                PhotoId = getPost.Author.PhotoId,
                AuthorEmail = getPost.Author.Email,
                PostedOn = getPost.CreatedOn.Value,
                StartTown = getPost.StartTown.Name,
                EndTown = getPost.EndTown.Name
            };

            return View(model);
        }


        public ActionResult Create()
        {
            var startTowns = this.townService.GetAllStartTowns().ToList().Select(x => Mapper.Map<StartTown>(x)).ToList();
            var endTowns = this.townService.GetAllEndTowns().ToList().Select(x => Mapper.Map<EndTown>(x)).ToList();

            var model = new PostCreateViewModel()
            {
                ID = Guid.NewGuid(),
                StartTowns = startTowns,
                EndTowns = endTowns
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel model)
        {
            var post = Mapper.Map<PostCreateViewModel>(model);
            Guid townName = model.StartTown;
            Guid endTownName = model.EndTown;
            string id = User.Identity.GetUserId();

            var postMod = new Post()
            {
                ID = post.ID,
                Content = post.Content,
                Title = post.Title
            };


            var toPost = Mapper.Map<Post>(postMod);
            this.postsService.CreatePost(toPost, id, townName, endTownName);

            return RedirectToAction("Index", "Home", new { area = "" });
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