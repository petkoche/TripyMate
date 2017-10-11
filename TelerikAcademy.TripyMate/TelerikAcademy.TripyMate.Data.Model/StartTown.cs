using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model.Abstracts;

namespace TelerikAcademy.TripyMate.Data.Model
{
    public class StartTown
    {
        public StartTown()
        {
            this.ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
