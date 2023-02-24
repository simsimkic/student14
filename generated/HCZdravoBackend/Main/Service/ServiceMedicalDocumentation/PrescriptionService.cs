// File:    PrescriptionService.cs
// Created: Thursday, May 21, 2020 7:35:59 PM
// Purpose: Definition of Class PrescriptionService


using Repository.RepositoryMedicalDocumentation;
using System;
using System.Collections.Generic;

namespace Service.ServiceMedicalDocumentation
{
    public class PrescriptionService
    {
        private IPerscriptionRepository _iPrescriptionRepository;

        public PrescriptionService(PrescriptionRepository prescriptionRepository) {
            _iPrescriptionRepository = prescriptionRepository;
        }

        public PrescriptionService() { }

        public void WritePrescription(Prescription prescription)
            => _iPrescriptionRepository.Create(prescription);

        public void EditPrescription(Prescription prescription)
            => _iPrescriptionRepository.Update(prescription);

        public void RemovePrescription(Prescription prescription)
            => _iPrescriptionRepository.Delete(prescription.Id);

        public Prescription GetPrescriptionById(string id)
            => _iPrescriptionRepository.Get(id);

        public List<Prescription> GetAllPrescriptions()
            => _iPrescriptionRepository.GetAll();

        public List<Prescription> GetAllPrescriptionsByPatientChart(PatientChart patientChart)
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach (Prescription prescription in GetAllPrescriptions())
            {
                if (prescription.PatientChart.Id.Equals(patientChart.Id))
                    prescriptions.Add(prescription);
            }
            return prescriptions;
        }

    }
}