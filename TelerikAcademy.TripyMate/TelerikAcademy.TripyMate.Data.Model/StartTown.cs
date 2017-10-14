using System;
using TelerikAcademy.TripyMate.Data.Model.Abstracts;

namespace TelerikAcademy.TripyMate.Data.Model
{
    public class StartTown : DataModel
    {
        public StartTown()
        {
            this.ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
