﻿using System;
using System.Linq;
using TelerikAcademy.TripyMate.Data.Model.Contracts;

namespace TelerikAcademy.TripyMate.Data.Repositories.Contracts
{
    public interface IEfRepository<T> where T : class, IDeletable
    {
        T Get(Guid id);
        T GetStr(string id);
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}