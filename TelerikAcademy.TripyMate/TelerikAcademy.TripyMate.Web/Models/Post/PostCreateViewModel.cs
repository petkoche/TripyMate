using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TelerikAcademy.TripyMate.Data.Model;

namespace TelerikAcademy.TripyMate.Web.Models.Post
{
    public class PostCreateViewModel
    {
        public PostCreateViewModel()
        {
            this.ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public ICollection<StartTown> StartTowns { get; set; }

        public ICollection<EndTown> EndTowns { get; set; }

        [Required]
        [MaxLength(60)]
        public string Content { get; set; }

        public Guid StartTown { get; set; }

        public Guid EndTown { get; set; }

        [Required]
        public string Author { get; set; }
    }
}