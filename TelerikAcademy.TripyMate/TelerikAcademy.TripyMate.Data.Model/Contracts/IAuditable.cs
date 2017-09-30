using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademy.TripyMate.Data.Model.Contracts
{
    interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
