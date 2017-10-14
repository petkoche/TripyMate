using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Web.Infreastructure;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Models
{
    public class NewPostViewModel : IMapFrom<Data.Model.Post>
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public IList<StartTown> StartTown { get; set; }

        public IList<EndTown> EndTown { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}