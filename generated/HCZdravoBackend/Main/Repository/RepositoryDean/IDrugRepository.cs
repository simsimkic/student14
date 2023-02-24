// File:    IDrugRepository.cs
// Created: Thursday, May 28, 2020 10:32:09 AM
// Purpose: Definition of Interface IDrugRepository

using System.Collections.Generic;

namespace Repository.RepositoryDean
{
    public interface IDrugRepository : IRepository<Drug>
    {
        bool Create(Drug obj);

        bool Delete(string id);

        bool Update(Drug obj);

        Drug Get(string id);

        List<Drug> GetAll();

    }
}