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

        public PostAdminController(IPostsService postService)
        {
            this.postService = postService;
        }

        // GET: Admin/Recipе
        [HttpGet]
        public ActionResult Index()
        {            
            var model = new IndexViewModel()
            {
                ID = Guid.NewGuid()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexViewModel model)
        {
            var post = Mapper.Map<Post>(model);
            string id = User.Identity.GetUserId();
            this.postService.CreatePost(post, id);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}