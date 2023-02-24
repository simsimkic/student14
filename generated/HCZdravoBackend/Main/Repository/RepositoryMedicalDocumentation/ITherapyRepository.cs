// File:    ITherapyRepository.cs
// Created: Wednesday, May 27, 2020 2:00:14 AM
// Purpose: Definition of Interface ITherapyRepository

using System.Collections.Generic;
using System.Globalization;

namespace Repository.RepositoryMedicalDocumentation
{
    public interface ITherapyRepository : IRepository<Therapy>
    {
        bool Create(Therapy obj);

        bool Delete(string id);

        bool Update(Therapy obj);

        Therapy Get(string id);

        List<Therapy> GetAll();

        void SaveAll(List<Therapy> therapies);
    }
}