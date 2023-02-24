// File:    ReportOfExaminationService.cs
// Created: Thursday, May 21, 2020 7:36:01 PM
// Purpose: Definition of Class ReportOfExaminationService


using Repository.RepositoryMedicalDocumentation;
using System;
using System.Collections.Generic;

namespace Service.ServiceMedicalDocumentation
{
    public class ReportOfExaminationService
    {
        private IReportOfExaminationRepository _iReportOfExaminationRepository;

        public ReportOfExaminationService(ReportOfExaminationRepository reportOfExaminationRepository)
        {
            _iReportOfExaminationRepository = reportOfExaminationRepository;
        }

        public ReportOfExaminationService() { }

        public void WriteReportOfExamination(ReportOfExamination reportOfExamination)
            => _iReportOfExaminationRepository.Create(reportOfExamination);

        public void EditReportOfExamination(ReportOfExamination reportOfExamination)
            => _iReportOfExaminationRepository.Update(reportOfExamination);

        public void RemoveReportOfExamination(ReportOfExamination reportOfExamination)
            => _iReportOfExaminationRepository.Delete(reportOfExamination.Id);

        public ReportOfExamination GetReportOfExaminationById(string id)
            => _iReportOfExaminationRepository.Get(id);

        public List<ReportOfExamination> GetAllReportsOfExaminations()
            => _iReportOfExaminationRepository.GetAll();

        public List<ReportOfExamination> GetAllReportOfExaminationByPatientChart(PatientChart patientChart)
        {
            List<ReportOfExamination> allPatientsReportsOfExamination = new List<ReportOfExamination>();
            foreach (ReportOfExamination reportOfExamination in GetAllReportsOfExaminations())
            {
                if (reportOfExamination.PatientChart.Id.Equals(patientChart.Id)) allPatientsReportsOfExamination.Add(reportOfExamination);
            }
            return allPatientsReportsOfExamination;
        }


    }
}