// File:    IItemRepository.cs
// Created: Thursday, May 28, 2020 10:32:09 AM
// Purpose: Definition of Interface IItemRepository

using System.Collections.Generic;

namespace Repository.RepositoryDean
{
    public interface IItemRepository : IRepository<Item>
    {
        bool Create(Item obj);

        bool Delete(string id);

        bool Update(Item obj);

        Item Get(string id);

        List<Item> GetAll();

    }
}