using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TelerikAcademy.TripyMate.Services.Contracts;
using TelerikAcademy.TripyMate.Services.Model;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Models;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GridPostController : Controller
    {
        private readonly IPostsService postService;

        public GridPostController(IPostsService postService)
        {
            if (postService == null)
            {
                throw new ArgumentNullException();
            }

            this.postService = postService;
        }

        // GET: Admin/GridPost
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPosts([DataSourceRequest] DataSourceRequest request)
        {
            var posts = this.postService.GetAllList();
            var commentViewList = Mapper.Map<ICollection<GridPostViewModel>>(posts);
            var result = commentViewList.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult UpdatePost(GridPostViewModel model)
        {
            var serviceModel = new PostServiceModel(model.Content, model.IsDeleted);
            this.postService.EditPost(model.ID, serviceModel);

            return Json(new[] { model });
        }

        public ActionResult DeleteComment(GridPostViewModel model)
        {
            this.postService.DeletePost(model.ID);

            return Json(new[] { model });
        }
    }

}