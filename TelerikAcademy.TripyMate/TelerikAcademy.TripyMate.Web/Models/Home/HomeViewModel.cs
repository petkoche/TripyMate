﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikAcademy.TripyMate.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}