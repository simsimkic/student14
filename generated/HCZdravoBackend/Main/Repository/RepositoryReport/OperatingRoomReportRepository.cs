// File:    OperatingRoomReportRepository.cs
// Created: Thursday, May 28, 2020 10:28:33 PM
// Purpose: Definition of Class OperatingRoomReportRepository

using System;
using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public class OperatingRoomReportRepository : IOperatingRoomReportRepository
    {
        public bool Create(OperatingRoomReport obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(OperatingRoomReport obj)
        {
            throw new NotImplementedException();
        }

        public OperatingRoomReport Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<OperatingRoomReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAsPDF(ReportPDF report)
        {
            throw new NotImplementedException();
        }
    }
}