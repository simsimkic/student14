// File:    IAppointmentRepository.cs
// Created: Wednesday, May 27, 2020 1:09:29 AM
// Purpose: Definition of Interface IAppointmentRepository

using System;
using System.Collections.Generic;

namespace Repository.RepositoryAppointment
{
    public interface IExaminationRepository : IRepository<Examination>
    {

        bool Create(Examination obj);

        bool Delete(string id);
        bool Update(Examination obj);

        Examination Get(string id);

        List<Examination> GetAll();

        List<Examination> GetAllDoctorsExaminations(Doctor doctor);
        List<Examination> GetAllPatientExaminations(RegisteredPatient patient);

    }
}