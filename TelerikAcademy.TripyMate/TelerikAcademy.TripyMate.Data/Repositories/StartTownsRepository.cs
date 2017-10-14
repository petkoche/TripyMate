using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;

namespace TelerikAcademy.TripyMate.Data.Repositories
{
    public class StartTownsRepository : IStartTownsRepository
    {
        private readonly MsSqlDbContext context;

        public StartTownsRepository(MsSqlDbContext context)
        {
            this.context = context;
        }

        public IQueryable<StartTown> All
        {
            get
            {
                return this.context.Set<StartTown>();
            }
        }

        public void Add(StartTown entity)
        {
            DbEntityEntry entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.context.Set<StartTown>().Add(entity);
            }
        }

        public StartTown Get(Guid id)
        {
            return this.context.StartTowns.First(x => x.ID == id);
        }

        public StartTown GetFirst(string name)
        {
            return this.context.Set<StartTown>().First(x => x.Name == name);
        }
    }
}
