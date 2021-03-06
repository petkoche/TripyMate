﻿using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;

namespace TelerikAcademy.TripyMate.Data.Repositories
{
    public class StartTownsRepository : EfRepository<StartTown>, IStartTownsRepository
    {
        public StartTownsRepository(MsSqlDbContext context) 
            : base(context)
        {            
        }
        
    }
}