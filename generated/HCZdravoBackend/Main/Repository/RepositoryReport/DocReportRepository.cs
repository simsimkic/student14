// File:    DocReportRepository.cs
// Created: Thursday, May 28, 2020 10:28:34 PM
// Purpose: Definition of Class DocReportRepository

using System;
using System.Collections.Generic;

namespace Repository.RepositoryReport
{
    public class DocReportRepository : IDocReportRepository
    {
        public bool Create(DocReport obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(DocReport obj)
        {
            throw new NotImplementedException();
        }

        public DocReport Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<DocReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveAsPDF(ReportPDF report)
        {
            throw new NotImplementedException();
        }
    }
}