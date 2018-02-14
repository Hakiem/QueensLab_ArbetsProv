using System;
using System.Collections.Generic;

namespace ArbetsUppdrag.Services
{
    public interface ILocationsRepository<T> 
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool EntityExists(int id);
    }
}
