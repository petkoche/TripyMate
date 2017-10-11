using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model;
using TelerikAcademy.TripyMate.Data.Repositories;
using TelerikAcademy.TripyMate.Data.Repositories.Contracts;

namespace TelerikAcademy.TripyMate.Data.Repositories
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(MsSqlDbContext context)
            : base(context)
        {
        }
    }
}
