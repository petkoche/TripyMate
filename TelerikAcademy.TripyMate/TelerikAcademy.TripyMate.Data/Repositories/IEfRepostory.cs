using System.Linq;
using TelerikAcademy.TripyMate.Data.Model.Contracts;

namespace TelerikAcademy.TripyMate.Data.Repositories
{
    public interface IEfRepostory<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}