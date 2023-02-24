// File:    IInterventionReportRepository.cs
// Created: Thursday, May 28, 2020 10:29:14 PM
// Purpose: Definition of Interface IInterventionReportRepository

using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public interface IInterventionReportRepository : IReportRepository<InterventionReport>
    {
        bool Create(InterventionReport obj);

        bool Delete(string id);

        bool Update(InterventionReport obj);

        InterventionReport Get(string id);

        List<InterventionReport> GetAll();

        void SaveAsPDF(ReportPDF report);

    }
}