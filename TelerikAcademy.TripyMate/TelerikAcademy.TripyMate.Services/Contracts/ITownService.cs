using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;

namespace TelerikAcademy.TripyMate.Services.Contracts
{
    public interface ITownService
    {
        IQueryable<StartTown> GetAllStartTowns();

        StartTown GetByIdStartTowns(Guid id);

        StartTown GetByNameStartTowns(string name);
    }
}
