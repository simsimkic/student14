// File:    PatientChartService.cs
// Created: Thursday, May 21, 2020 7:37:48 PM
// Purpose: Definition of Class PatientChartService


using Main.View;
using Repository.RepositoryMedicalDocumentation;
using System;
using System.Collections.Generic;

namespace Service.ServiceMedicalDocumentation
{
    public class PatientChartService
    {
        private IPatientChartRepository _iPatientChartRepository;

        public PatientChartService(PatientChartRepository patientChartRepository)
        {
            _iPatientChartRepository = patientChartRepository;
        }

        public PatientChartService() { }
        public string GenerateRandomPatientChartId()
        {
            RandomStringGenerator randomId = new RandomStringGenerator(11);
            while (_iPatientChartRepository.Get(randomId.RandomString) != null)
            {
                randomId = new RandomStringGenerator(11);
            }
            return randomId.RandomString;
        }
        public bool NewEmptyChart(RegisteredPatient registeredPatient)
        {
            PatientChart emptyPatientChart = new PatientChart(GenerateRandomPatientChartId(), registeredPatient);
            return _iPatientChartRepository.Create(emptyPatientChart);
        }
        public void NewPatientChart(PatientChart patientChart)
            => _iPatientChartRepository.Create(patientChart);

        public void SetPatientChart(PatientChart patientChart)
            => _iPatientChartRepository.Update(patientChart);

        public void DeletePatientChart(PatientChart patientChart)
            => _iPatientChartRepository.Delete(patientChart.Id);

        public PatientChart GetPatientChartById(string id)
            => _iPatientChartRepository.Get(id);

        public List<PatientChart> GetAllPatientCharts()
            => _iPatientChartRepository.GetAll();

        public PatientChart GetPatientChartByPatient(RegisteredPatient patient)
        {
            foreach (PatientChart patientChart in GetAllPatientCharts())
            {
                if (patientChart.RegisteredPatient.Pin.Equals(patient.Pin))
                    return patientChart;
            }
            return null;
        }

        public void AddAllergy(Allergy allergy, PatientChart patientChart)
        {
            foreach (Allergy a in patientChart.Allergies) {
                if (a.Id.Equals(allergy.Id))
                    return;
            }
            patientChart.Allergies.Add(allergy);
            _iPatientChartRepository.Update(patientChart);
        }

        

    }
}