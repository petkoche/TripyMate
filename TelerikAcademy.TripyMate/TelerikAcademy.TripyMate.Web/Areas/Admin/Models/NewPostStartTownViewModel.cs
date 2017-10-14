using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Web.Infreastructure;

namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Models
{
    public class NewPostStartTownViewModel : IMapFrom<StartTown>
    {
        public Guid ID { get; set;}

        public string Name { get; set; }
    }
}