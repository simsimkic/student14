// File:    IPerscriptionRepository.cs
// Created: Wednesday, May 27, 2020 1:57:54 AM
// Purpose: Definition of Interface IPerscriptionRepository

using System.Collections.Generic;

namespace Repository.RepositoryMedicalDocumentation
{
    public interface IPerscriptionRepository : IRepository<Prescription>
    {
        bool Create(Prescription obj);

        bool Delete(string id);

        bool Update(Prescription obj);

        Prescription Get(string id);

        List<Prescription> GetAll();

        void SaveAll(List<Prescription> prescriptions);
    }
}