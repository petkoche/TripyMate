using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Models;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostAdminController : Controller
    {
        private readonly IPostsService postService;
        private readonly ITownService townService;

        public PostAdminController(IPostsService postService, ITownService townService)
        {
            this.postService = postService;
            this.townService = townService;
        }

        // GET: Admin/Recipе
        [HttpGet]
        public ActionResult Index()
        {
            var startTowns = this.townService.GetAllStartTowns().ToList().Select(x => Mapper.Map<StartTown>(x)).ToList();                                               
            
            var model = new IndexViewModel()
            {
                ID = Guid.NewGuid(),
                StartTowns = startTowns                
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexViewModel model)
        {
            var post = Mapper.Map<IndexViewModel>(model);
            Guid townName = model.StartTown;
            string id = User.Identity.GetUserId();

            var postMod = new Post()
            {
                ID = post.ID,
                Content = post.Content,
                Title = post.Title
            };


            var toPost = Mapper.Map<Post>(postMod);
            this.postService.CreatePost(toPost, id, townName);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}