// File:    TherapyService.cs
// Created: Thursday, May 21, 2020 7:36:02 PM
// Purpose: Definition of Class TherapyService


using Repository.RepositoryMedicalDocumentation;
using System;
using System.Collections.Generic;

namespace Service.ServiceMedicalDocumentation
{
    public class TherapyService
    {
        private ITherapyRepository _iTherapyRepository;

        public TherapyService(TherapyRepository therapyRepository)
        {
            _iTherapyRepository = therapyRepository;
        }

        public TherapyService() { }

        public void WriteTherapy(Therapy therapy)
            => _iTherapyRepository.Create(therapy);

        public void EditTherapy(Therapy therapy)
            => _iTherapyRepository.Update(therapy);

        public void RemoveTherapy(Therapy therapy)
            => _iTherapyRepository.Delete(therapy.Id);

        public Therapy GetTherapyById(string id)
            => _iTherapyRepository.Get(id);

        public List<Therapy> GetAllTherapies()
            => _iTherapyRepository.GetAll();


        public List<Therapy> GetAllTherapiesByPatientChart(PatientChart patientChart)
        {
            List<Therapy> therapies = new List<Therapy>();
            foreach (Therapy therapy in GetAllTherapies())
            {
                if (therapy.PatientChart.Id.Equals(patientChart.Id))
                    therapies.Add(therapy);
            }
            return therapies;
        }


    }
}