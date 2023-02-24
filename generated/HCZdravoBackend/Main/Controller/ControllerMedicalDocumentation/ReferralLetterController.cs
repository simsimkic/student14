// File:    ReferralLetterController.cs
// Created: Thursday, May 21, 2020 9:34:15 PM
// Purpose: Definition of Class ReferralLetterController

using Service.ServiceMedicalDocumentation;
using System.Collections.Generic;

namespace Controller.ControllerMedicalDocumentation
{
    public class ReferralLetterController
    {
        private ReferralLetterService _referralLetterService;

        public ReferralLetterController(ReferralLetterService referralLetterService)
        {
            _referralLetterService = referralLetterService;
        }

        public void WriteReferralLetter(ReferralLetter referralLetter)
            => _referralLetterService.WriteReferralLetter(referralLetter);

        public void EditReferralLetter(ReferralLetter referralLetter)
            => _referralLetterService.EditReferralLetter(referralLetter);

        public void RemoveReferralLetter(ReferralLetter referralLetter)
            => _referralLetterService.RemoveReferralLetter(referralLetter);

        public ReferralLetter GetReferralLetterById(string id)
            => _referralLetterService.GetReferralLetterById(id);

        public List<ReferralLetter> GetAllReferralLetters()
            => _referralLetterService.GetAllReferralLetters();
      
        public List<ReferralLetter> GetAllReferralLettersByPatientChart(PatientChart patientChart)
            => _referralLetterService.GetAllReferralLettersByPatientChart(patientChart);
    }
}