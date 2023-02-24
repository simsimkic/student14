// File:    IAppointmentRepository.cs
// Created: Wednesday, May 27, 2020 1:09:29 AM
// Purpose: Definition of Interface IAppointmentRepository

using System;
using System.Collections.Generic;

namespace Repository.RepositoryAppointment
{
    public interface IOperationRepository : IRepository<Operation>
    {
        bool Create(Operation obj);

        bool Delete(string id);

        bool Update(Operation obj);

        Operation Get(string id);

        List<Operation> GetAll();

        List<Operation> GetAllDoctorsOperations(Doctor doctor);
        List<Operation> GetAllPatientOperations(RegisteredPatient patient);

    }
}