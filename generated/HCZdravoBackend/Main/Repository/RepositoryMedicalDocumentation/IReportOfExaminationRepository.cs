// File:    IReportOfExaminationRepository.cs
// Created: Wednesday, May 27, 2020 1:58:59 AM
// Purpose: Definition of Interface IReportOfExaminationRepository

using System.Collections.Generic;

namespace Repository.RepositoryMedicalDocumentation
{
    public interface IReportOfExaminationRepository : IRepository<ReportOfExamination>
    {
        bool Create(ReportOfExamination obj);

        bool Delete(string id);

        bool Update(ReportOfExamination obj);

        ReportOfExamination Get(string id);

        List<ReportOfExamination> GetAll();

        void SaveAll(List<ReportOfExamination> reportOfExaminations);
    }
}