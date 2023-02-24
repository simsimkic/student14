// File:    IPatientChartRepository.cs
// Created: Wednesday, May 27, 2020 1:56:28 AM
// Purpose: Definition of Interface IPatientChartRepository

using System.Collections.Generic;
using System.Globalization;

namespace Repository.RepositoryMedicalDocumentation
{
    public interface IPatientChartRepository : IRepository<PatientChart>
    {
        bool Create(PatientChart obj);

        bool Delete(string id);

        bool Update(PatientChart obj);

        PatientChart Get(string id);

        List<PatientChart> GetAll();

        void SaveAll(List<PatientChart> patientCharts);

    }
}