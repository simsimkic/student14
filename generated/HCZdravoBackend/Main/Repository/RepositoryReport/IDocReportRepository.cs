// File:    IDocReportRepository.cs
// Created: Thursday, May 28, 2020 10:29:15 PM
// Purpose: Definition of Interface IDocReportRepository

using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public interface IDocReportRepository : IReportRepository<DocReport>
    {
        bool Create(DocReport obj);

        bool Delete(string id);

        bool Update(DocReport obj);

        DocReport Get(string id);

        List<DocReport> GetAll();

        void SaveAsPDF(ReportPDF report);

    }
}