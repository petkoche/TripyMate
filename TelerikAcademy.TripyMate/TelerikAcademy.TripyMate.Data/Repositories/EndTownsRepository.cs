using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;

namespace TelerikAcademy.TripyMate.Data.Repositories
{
    public class EndTownsRepository : EfRepository<EndTown>, IEndTownsRepository
    {
        public EndTownsRepository(MsSqlDbContext context)
            : base(context)
        {
        }
    }
}