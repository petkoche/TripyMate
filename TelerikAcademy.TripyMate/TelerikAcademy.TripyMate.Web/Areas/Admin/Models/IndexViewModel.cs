using System;
using TelerikAcademy.TripyMate.Web.Infreastructure;
using TelerikAcademy.TripyMate.Data.Model;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Models
{
    public class IndexViewModel : IMapFrom<Post>
    {
        public IndexViewModel()
        {
            this.ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}