// File:    IScheduleReportRepository.cs
// Created: Thursday, May 28, 2020 10:29:14 PM
// Purpose: Definition of Interface IScheduleReportRepository

using PdfSharp.Pdf;
using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public interface IScheduleReportRepository : IReportRepository<ScheduleReport>
    {
        bool Create(ScheduleReport obj);

        bool Delete(string id);

        bool Update(ScheduleReport obj);

        ScheduleReport Get(string id);

        List<ScheduleReport> GetAll();

        void SaveAsPDF(ReportPDF pdf);

    }
}