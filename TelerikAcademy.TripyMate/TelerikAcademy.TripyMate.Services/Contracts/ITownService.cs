using System;
using System.Linq;
using TelerikAcademy.TripyMate.Data.Model;

namespace TelerikAcademy.TripyMate.Services.Contracts
{
    public interface ITownService
    {
        IQueryable<StartTown> GetAllStartTowns();

        StartTown GetByIdStartTowns(Guid id);

        IQueryable<EndTown> GetAllEndTowns();

        EndTown GetByIdEndTowns(Guid id);
    }
}