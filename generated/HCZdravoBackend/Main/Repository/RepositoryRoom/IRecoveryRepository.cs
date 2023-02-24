// File:    IRecoveryRepository.cs
// Created: Wednesday, May 27, 2020 1:51:37 AM
// Purpose: Definition of Interface IRecoveryRepository

using System.Collections.Generic;

namespace Repository.RepositoryRoom
{
    public interface IRecoveryRepository : IRepository<Room>
    {
        bool Create(Room obj);

        bool Delete(string id);

        bool Update(Room obj);

        Room Get(string id);

        List<Room> GetAll();

    }
}