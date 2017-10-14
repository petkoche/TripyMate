﻿using System;
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
            this.endTownsRepo = endTownsRepo;
            this.startTownsRepo = startTownsRepo;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<StartTown> GetAllStartTowns()
        {
            return this.startTownsRepo.All;
        }

        public StartTown GetByIdStartTowns(Guid id)
        {
            return this.startTownsRepo.Get(id);
        }

        public IQueryable<EndTown> GetAllEndTowns()
        {
            return this.endTownsRepo.All;
        }

        public EndTown GetByIdEndTowns(Guid id)
        {
            return this.endTownsRepo.Get(id);
        }
    }
}
