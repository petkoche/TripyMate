﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Models;
using TelerikAcademy.TripyMate.Providers.Contracts;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostAdminController : Controller
    {
        private readonly IPostsService postService;
        private readonly ITownService townService;
        private readonly IMapProvider mapProvider;

        public PostAdminController(IPostsService postService, ITownService townService, IMapProvider mapProvider)
        {
            if (postService == null)
            {
                throw new ArgumentNullException();
            }

            if (townService == null)
            {
                throw new ArgumentNullException();
            }

            if (mapProvider == null)
            {
                throw new ArgumentNullException();
            }

            this.mapProvider = mapProvider;
            this.postService = postService;
            this.townService = townService;
        }

        // GET: Admin/Recipе
        [HttpGet]
        public ActionResult Index()
        {
            var startTowns = this.townService.GetAllStartTowns().ToList().Select(x => this.mapProvider.GetMap<StartTown>(x)).ToList();
            var endTowns = this.townService.GetAllEndTowns().ToList().Select(x => this.mapProvider.GetMap<EndTown>(x)).ToList();

            var model = new IndexViewModel()
            {
                ID = Guid.NewGuid(),
                StartTowns = startTowns,
                EndTowns = endTowns
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexViewModel model)
        {
            var post = this.mapProvider.GetMap<IndexViewModel>(model);
            Guid townName = model.StartTown;
            Guid endTownName = model.EndTown;
            string id = User.Identity.GetUserId();

            var postMod = new Post()
            {
                ID = post.ID,
                Content = post.Content,
                Title = post.Title
            };

            var toPost = this.mapProvider.GetMap<Post>(postMod);
            this.postService.CreatePost(toPost, id, townName, endTownName);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}