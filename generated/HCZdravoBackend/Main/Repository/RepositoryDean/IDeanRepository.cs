// File:    IDeanRepository.cs
// Created: Thursday, May 28, 2020 7:08:40 PM
// Purpose: Definition of Interface IDeanRepository

using System.Collections.Generic;

namespace Repository.RepositoryDean
{
    public interface IDeanRepository
    {
        bool Create(Dean obj);

        bool Delete();

        bool Update(Dean obj);

        Dean Get();
        

    }
}