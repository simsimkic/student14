// File:    ISecretaryRepository.cs
// Created: Friday, May 29, 2020 3:36:53 AM
// Purpose: Definition of Interface ISecretaryRepository

using System.Collections.Generic;

namespace Repository.RepositorySecretary
{
    public interface ISecretaryRepository : IRepository<Secretary>
    {
        bool Create(Secretary obj);

        bool Delete(string id);

        bool Update(Secretary obj);

        Secretary Get(string id);

        List<Secretary> GetAll();

    }
}