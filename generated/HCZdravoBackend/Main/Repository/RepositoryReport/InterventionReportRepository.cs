// File:    InterventionReportRepository.cs
// Created: Thursday, May 28, 2020 10:28:34 PM
// Purpose: Definition of Class InterventionReportRepository

using System;
using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public class InterventionReportRepository : IInterventionReportRepository
    {
        public bool Create(InterventionReport obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(InterventionReport obj)
        {
            throw new NotImplementedException();
        }

        public InterventionReport Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<InterventionReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAsPDF(ReportPDF report)
        {
            throw new NotImplementedException();
        }
    }
}