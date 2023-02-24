// File:    PatientChartController.cs
// Created: Thursday, May 21, 2020 9:34:12 PM
// Purpose: Definition of Class PatientChartController

using Service.ServiceMedicalDocumentation;
using System.Collections.Generic;

namespace Controller.ControllerMedicalDocumentation
{
    public class PatientChartController
    {
        private PatientChartService _patientChartService;

        public PatientChartController(PatientChartService patientChartService)
        {
            _patientChartService = patientChartService;
        }

        public void NewPatientChart(PatientChart patientChart)
            => _patientChartService.NewPatientChart(patientChart);
        

        public void SetPatientChart(PatientChart patientChart)
            => _patientChartService.SetPatientChart(patientChart);
        

        public void DeletePatientChart(PatientChart patientChart)
            => _patientChartService.DeletePatientChart(patientChart);

        public PatientChart GetPatientChartById(string id)
            => _patientChartService.GetPatientChartById(id);


        public List<PatientChart> GetAllPatientCharts()
            => _patientChartService.GetAllPatientCharts();
        

        public PatientChart GetPatientChartByPatient(RegisteredPatient patient)
            => _patientChartService.GetPatientChartByPatient(patient);
        

        public void AddAllergy(Allergy allergy, PatientChart patientChart)
            => _patientChartService.AddAllergy(allergy, patientChart);

    }
}