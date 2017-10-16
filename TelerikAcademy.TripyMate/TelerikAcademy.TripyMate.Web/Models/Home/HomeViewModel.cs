using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelerikAcademy.TripyMate.Web.Models.Post;

namespace TelerikAcademy.TripyMate.Web.Models.Home
{
    public class HomeViewModel
    {
        public IList<PostViewModel> Posts { get; set; }
    }
}