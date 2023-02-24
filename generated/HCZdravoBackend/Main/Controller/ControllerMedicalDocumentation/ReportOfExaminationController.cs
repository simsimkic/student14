// File:    ReportOfExaminationController.cs
// Created: Thursday, May 21, 2020 9:34:15 PM
// Purpose: Definition of Class ReportOfExaminationController


using Service.ServiceMedicalDocumentation;
using System.Collections.Generic;

namespace Controller.ControllerMedicalDocumentation
{
    public class ReportOfExaminationController
    {
        private ReportOfExaminationService _reportOfExaminationService;

        public ReportOfExaminationController(ReportOfExaminationService reportOfExaminationService)
        {
            _reportOfExaminationService = reportOfExaminationService;
        }

        public void WriteReportOfExamination(ReportOfExamination reportOfExamination)
            => _reportOfExaminationService.WriteReportOfExamination(reportOfExamination);

        public void EditReportOfExamination(ReportOfExamination reportOfExamination)
             => _reportOfExaminationService.EditReportOfExamination(reportOfExamination);

        public void RemoveReportOfExamination(ReportOfExamination reportOfExamination)
            => _reportOfExaminationService.RemoveReportOfExamination(reportOfExamination);

        public ReportOfExamination GetReportOfExaminationById(string id)
            => _reportOfExaminationService.GetReportOfExaminationById(id);

        public List<ReportOfExamination> GetAllReportsOfExaminations()
            => _reportOfExaminationService.GetAllReportsOfExaminations();


        public List<ReportOfExamination> GetAllReportOfExaminationByPatientChart(PatientChart patientChart)
            => _reportOfExaminationService.GetAllReportOfExaminationByPatientChart(patientChart);

    }
}