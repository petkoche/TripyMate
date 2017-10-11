﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelerikAcademy.TripyMate.Web.Models.Home
{
    public class PostViewModel
    {
        public string Title { get; set; }

        public string StartTown { get; set; }

        public string EndTown { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime PostedOn { get; set; }
    }
}