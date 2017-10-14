﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public StartTown StartTown { get; set; }

        public virtual EndTown EndTown { get; set; }

    }
}
