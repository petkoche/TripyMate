using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademy.TripyMate.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MsSqlDbContext context;

        public UnitOfWork(MsSqlDbContext context)
        {
            this.context = context;
        }

        public int Complete()
        {
            return this.context.SaveChanges();
        }
    }
}
