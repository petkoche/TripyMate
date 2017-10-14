using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;

namespace TelerikAcademy.TripyMate.Data.Repositories.Contracts
{
    public interface IStartTownsRepository
    {
        IQueryable<StartTown> All { get; }

        void Add(StartTown entity);

        StartTown Get(Guid id);

        StartTown GetFirst(string name);
    }
}
