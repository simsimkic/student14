// File:    TherapyController.cs
// Created: Thursday, May 21, 2020 9:34:16 PM
// Purpose: Definition of Class TherapyController

using Service.ServiceMedicalDocumentation;
using System.Collections.Generic;

namespace Controller.ControllerMedicalDocumentation
{
    public class TherapyController
    {
        private TherapyService _therapyService;

        public TherapyController(TherapyService therapyService)
        {
            _therapyService = therapyService;
        }

        public void WriteTherapy(Therapy therapy)
            => _therapyService.WriteTherapy(therapy);

        public void EditTherapy(Therapy therapy)
            => _therapyService.EditTherapy(therapy);

        public void RemoveTherapy(Therapy therapy)
            => _therapyService.RemoveTherapy(therapy);

        public Therapy GetTherapyById(string id)
            => _therapyService.GetTherapyById(id);

        public List<Therapy> GetAllTherapies()
            => _therapyService.GetAllTherapies();
        

        public List<Therapy> GetAllTherapiesByPatientChart(PatientChart patientChart)
            => _therapyService.GetAllTherapiesByPatientChart(patientChart);
    }
}