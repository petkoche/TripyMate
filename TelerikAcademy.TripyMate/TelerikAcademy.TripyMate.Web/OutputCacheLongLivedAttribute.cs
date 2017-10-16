using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelerikAcademy.TripyMate.Web
{
    public class OutputCacheLongLivedAttribute : OutputCacheAttribute
    {
        public OutputCacheLongLivedAttribute()
        {
            CacheProfile = "LongLived";
        }
    }
}