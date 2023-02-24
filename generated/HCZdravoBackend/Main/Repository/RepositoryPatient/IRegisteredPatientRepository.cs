// File:    IRegisteredPatientRepository.cs
// Created: Wednesday, May 27, 2020 1:17:26 AM
// Purpose: Definition of Interface IRegisteredPatientRepository


using System.Collections.Generic;

namespace Repository.RepositoryPatient
{
    public interface IRegisteredPatientRepository : IRepository<RegisteredPatient>
    {
        int CountPatients();

        bool Create(RegisteredPatient obj);

        bool Delete(string id);

        bool Update(RegisteredPatient obj);

        RegisteredPatient Get(string id);

        List<RegisteredPatient> GetAll();

    }
}