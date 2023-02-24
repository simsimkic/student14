// File:    IReportRepository.cs
// Created: Thursday, May 28, 2020 10:27:14 PM
// Purpose: Definition of Interface IReportRepository

namespace Repository.RepositoryReport
{
    public interface IReportRepository<T> : Repository.IRepository<T>
    {
        void SaveAsPDF(ReportPDF report);

    }
}