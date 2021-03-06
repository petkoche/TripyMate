﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Providers.Contracts;
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
        private readonly IMapProvider mapProvider;

        public PostController(IPostsService postsService, ITownService townService, IMapProvider mapProvider)
        {
            if (postsService == null)
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

            var model = new PostViewModel()
            {              
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
            var startTowns = this.townService.GetAllStartTowns().ToList().Select(x => this.mapProvider.GetMap<StartTown>(x)).ToList();
            var endTowns = this.townService.GetAllEndTowns().ToList().Select(x => this.mapProvider.GetMap<EndTown>(x)).ToList();

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
            var post = this.mapProvider.GetMap<PostCreateViewModel>(model);
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
            this.postsService.CreatePost(toPost, id, townName, endTownName);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult SearchPost()
        {
            var data = postsService
                .GetAllNoLimit()
                .AsQueryable()
                .Select(PostViewModel.FromPost)
                .ToList();

            return this.View(data);
        }

        [HttpPost]
        public ActionResult SearchPost(string query, string queryEnd)
        {
            var result = postsService
                .GetAllNoLimit()
                .AsQueryable()
                .Where(post => post.StartTown.Name.ToLower().Contains(query.ToLower()))
                .Where(post => post.EndTown.Name.ToLower().Contains(queryEnd.ToLower()))
                .Select(PostViewModel.FromPost)
                .ToList();

            if (result.Count == 0)
            {
                var post = new PostViewModel()
                {
                    Title = "No results found! Try again with a different search!"
                };

                result.Add(post);
            }

            return this.PartialView("_PostResult", result);
        }

    }
}