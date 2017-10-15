using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;
using TelerikAcademy.TripyMate.Data.UnitOfWork;
using TelerikAcademy.TripyMate.Services.Contracts;

namespace TelerikAcademy.TripyMate.Services
{
    public class TownService : ITownService
    {
        private readonly IStartTownsRepository startTownsRepo;
        private readonly IEndTownsRepository endTownsRepo;
        private readonly IUnitOfWork unitOfWork;

        public TownService(IStartTownsRepository startTownsRepo, IEndTownsRepository endTownsRepo, IUnitOfWork unitOfWork)
        {
            if (endTownsRepo == null)
            {
                throw new ArgumentNullException();
            }

            this.endTownsRepo = endTownsRepo;

            if (startTownsRepo == null)
            {
                throw new ArgumentNullException();
            }

            this.startTownsRepo = startTownsRepo;

            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }

            this.unitOfWork = unitOfWork;
        }

        public IQueryable<StartTown> GetAllStartTowns()
        {
            var towns = this.startTownsRepo.All;
            if (towns == null)
            {
                throw new NullReferenceException("Town not found");
            }

            return towns;
        }

        public StartTown GetByIdStartTowns(Guid id)
        {
            var town = this.startTownsRepo.Get(id);
            if (town == null)
            {
                throw new NullReferenceException("Town not found");
            }

            return town;
        }

        public IQueryable<EndTown> GetAllEndTowns()
        {
            var towns = this.endTownsRepo.All;
            if (towns == null)
            {
                throw new NullReferenceException("Town not found");
            }

            return towns;
        }

        public EndTown GetByIdEndTowns(Guid id)
        {
            var towns = this.endTownsRepo.Get(id);
            if (towns == null)
            {
                throw new NullReferenceException("Town not found");
            }

            return towns;
        }
    }
}