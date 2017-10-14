using System;
using System.ComponentModel.DataAnnotations.Schema;
using TelerikAcademy.TripyMate.Data.Model.Abstracts;

namespace TelerikAcademy.TripyMate.Data.Model
{
    public class Post : DataModel
    {
        public Post()
        {
            this.ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }

        public Guid StartTownId { get; set; }

        [ForeignKey("StartTownId")]
        public virtual StartTown StartTown { get; set; }

        public Guid EndTownId { get; set; }

        [ForeignKey("EndTownId")]
        public virtual EndTown EndTown { get; set; }
    }
}
