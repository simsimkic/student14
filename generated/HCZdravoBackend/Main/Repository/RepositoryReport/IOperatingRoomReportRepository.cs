// File:    IOperatingRoomReportRepository.cs
// Created: Thursday, May 28, 2020 10:29:14 PM
// Purpose: Definition of Interface IOperatingRoomReportRepository

using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public interface IOperatingRoomReportRepository : IReportRepository<OperatingRoomReport>
    {
        bool Create(OperatingRoomReport obj);

        bool Delete(string id);

        bool Update(OperatingRoomReport obj);

        OperatingRoomReport Get(string id);

        List<OperatingRoomReport> GetAll();

        void SaveAsPDF(ReportPDF report);

    }
}