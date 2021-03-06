﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelerikAcademy.TripyMate.Data.Model.Contracts;

namespace TelerikAcademy.TripyMate.Data.Model.Abstracts
{
    public abstract class DataModel : IAuditable, IDeletable
    {

        public DataModel()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime?  DeletedOn {get; set; }
    }
}
