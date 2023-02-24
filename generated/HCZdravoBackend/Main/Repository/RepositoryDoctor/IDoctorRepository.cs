// File:    IDoctorRepository.cs
// Created: Wednesday, May 27, 2020 1:55:17 AM
// Purpose: Definition of Interface IDoctorRepository

using Model.DoctorModel;
using System.Collections.Generic;

namespace Repository.RepositoryDoctor
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        bool Create(Doctor obj);

        bool Delete(string id);

        bool Update(Doctor obj);

        Doctor Get(string id);

        List<Doctor> GetAll();

        void SaveAll(List<Doctor> doctors);
    }
}