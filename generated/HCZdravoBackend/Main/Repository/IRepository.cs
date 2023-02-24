// File:    IRepository.cs
// Created: Thursday, May 21, 2020 5:54:22 PM
// Purpose: Definition of Interface IRepository

using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<T>
    {
        bool Create(T obj);

        bool Delete(string id);

        bool Update(T obj);

        T Get(string id);

        List<T> GetAll();
    }
}