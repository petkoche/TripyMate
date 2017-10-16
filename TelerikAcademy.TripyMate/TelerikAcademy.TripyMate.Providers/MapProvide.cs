using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademy.TripyMate.Providers
{
    using AutoMapper;
    using System.Collections.Generic;
    using Contracts;

    public class MapProvider : IMapProvider
    {
        public T GetMap<T>(object source)
        {
            return Mapper.Map<T>(source);
        }

        public ICollection<T> GetMapCollection<T>(object source)
        {
            return Mapper.Map<ICollection<T>>(source);
        }
    }
}
