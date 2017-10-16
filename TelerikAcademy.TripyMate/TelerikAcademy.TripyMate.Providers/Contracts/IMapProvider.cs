using System.Collections.Generic;

namespace TelerikAcademy.TripyMate.Providers.Contracts
{
    public interface IMapProvider
    {
        T GetMap<T>(object source);

        ICollection<T> GetMapCollection<T>(object source);
    }
}