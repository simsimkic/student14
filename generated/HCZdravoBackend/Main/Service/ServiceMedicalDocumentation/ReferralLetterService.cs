// File:    ReferralLetterService.cs
// Created: Thursday, May 21, 2020 7:36:01 PM
// Purpose: Definition of Class ReferralLetterService


using Repository.RepositoryMedicalDocumentation;
using System;
using System.Collections.Generic;

namespace Service.ServiceMedicalDocumentation
{
    public class ReferralLetterService
    {
        private IReferralLetterRepository _iReferralLetterRepository;

        public ReferralLetterService(ReferralLetterRepository referralLetterRepository)
        {
            _iReferralLetterRepository = referralLetterRepository;
        }

        public ReferralLetterService() { }

        public void WriteReferralLetter(ReferralLetter referralLetter)
            => _iReferralLetterRepository.Create(referralLetter);

        public void EditReferralLetter(ReferralLetter referralLetter)
            => _iReferralLetterRepository.Update(referralLetter);

        public void RemoveReferralLetter(ReferralLetter referralLetter)
            => _iReferralLetterRepository.Delete(referralLetter.Id);

        public ReferralLetter GetReferralLetterById(string id)
            => _iReferralLetterRepository.Get(id);

        public List<ReferralLetter> GetAllReferralLetters()
            => _iReferralLetterRepository.GetAll();

        public List<ReferralLetter> GetAllReferralLettersByPatientChart(PatientChart patientChart)
        {
            List<ReferralLetter> referralLetters = new List<ReferralLetter>();
            foreach (ReferralLetter referralLetter in GetAllReferralLetters())
            {
                if (referralLetter.PatientChart.Id.Equals(patientChart.Id))
                    referralLetters.Add(referralLetter);
            }
            return referralLetters;
        }

    }
}