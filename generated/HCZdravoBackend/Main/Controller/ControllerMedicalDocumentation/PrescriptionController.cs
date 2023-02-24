// File:    PrescriptionController.cs
// Created: Thursday, May 21, 2020 9:34:13 PM
// Purpose: Definition of Class PrescriptionController

using Service.ServiceMedicalDocumentation;
using System.Collections.Generic;

namespace Controller.ControllerMedicalDocumentation
{
    public class PrescriptionController
    {
        private PrescriptionService _prescriptionService;

        public PrescriptionController(PrescriptionService prescriptionService) {
            _prescriptionService = prescriptionService;
        }

        public void WritePrescription(Prescription prescription)
            => _prescriptionService.WritePrescription(prescription);

        public void EditPrescription(Prescription prescription)
            => _prescriptionService.EditPrescription(prescription);

        public void RemovePrescription(Prescription prescription)
            => _prescriptionService.RemovePrescription(prescription);

        public Prescription GetPrescriptionById(string id)
            => _prescriptionService.GetPrescriptionById(id);

        public List<Prescription> GetAllPrescriptions()
            => _prescriptionService.GetAllPrescriptions();
        

        public List<Prescription> GetAllPrescriptionsByPatientChart(PatientChart patientChart)
            => _prescriptionService.GetAllPrescriptionsByPatientChart(patientChart);

    }
}