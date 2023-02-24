// File:    IInventoryServices.cs
// Created: Thursday, May 21, 2020 4:54:12 PM
// Purpose: Definition of Interface IInventoryServices

using System.Collections.Generic;

namespace Service.ServiceDean
{
    public interface IInventoryServices<T>
    {
        bool Add(T obj);

        bool Set(T obj);

        List<T> GetAll();

        T Get(string id);

        bool Remove(string id);

    }
}