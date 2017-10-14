using System;
using TelerikAcademy.TripyMate.Web.Infreastructure;
using TelerikAcademy.TripyMate.Data.Model;
using System.Collections.Generic;
using TelerikAcademy.TripyMate.Web.Areas.Admin.Models;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Models
{
    public class IndexViewModel : IMapFrom<Data.Model.Post>
    {
        public IndexViewModel()
        {
            this.ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public string Title { get; set; }

        public ICollection<StartTown> StartTowns { get; set; }

        public ICollection<EndTown> EndTowns { get; set; }

        public string Content { get; set; }

        public Guid StartTown { get; set; }

        public Guid EndTown { get; set; }

        public string Author { get; set; }
    }
}