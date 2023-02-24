// File:    IStorageRepository.cs
// Created: Thursday, May 28, 2020 10:21:28 PM
// Purpose: Definition of Interface IStorageRepository

using System.Collections.Generic;

namespace Repository.RepositoryRoom
{
    public interface IStorageRepository
    {
        bool Create(Room obj);

        bool Delete();

        bool Update(Room obj);

        Room Get();

    }
}