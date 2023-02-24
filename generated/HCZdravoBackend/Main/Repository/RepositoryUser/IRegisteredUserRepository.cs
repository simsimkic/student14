// File:    IRegisteredUserRepository.cs
// Created: Wednesday, May 27, 2020 12:26:58 AM
// Purpose: Definition of Interface IRegisteredUserRepository

using System.Collections.Generic;

namespace Repository.RepositoryUser
{
    public interface IRegisteredUserRepository : IRepository<RegisteredUser>
    {
        bool Create(RegisteredUser obj);

        bool Delete(string id);

        bool Update(RegisteredUser obj);

        RegisteredUser Get(string id);

        RegisteredUser GetRegisteredUserByUsername(string username);

        List<RegisteredUser> GetAll();

    }
}