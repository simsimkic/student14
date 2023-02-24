// File:    RegisteredPatientService.cs
// Created: Monday, May 18, 2020 7:52:40 PM
// Purpose: Definition of Class RegisteredPatientService

using Repository.RepositoryMedicalDocumentation;
using Repository.RepositoryPatient;
using Repository.RepositoryUser;
using Service.ServiceMedicalDocumentation;
using System.Collections.Generic;

namespace Service.ServicePatient
{
    public class RegisteredPatientService
    {
        private IRegisteredPatientRepository _iRegisteredPatientRepository;
        private IRegisteredUserRepository _iRegisteredUserRepository;
        private PatientChartService _patientChartService;

        public RegisteredPatientService(RegisteredPatientRepository registeredPatientRepository,  RegisteredUserRepository registeredUserRepository, PatientChartRepository patientChartRepository)
        {
            _iRegisteredPatientRepository = registeredPatientRepository;
            _iRegisteredUserRepository = registeredUserRepository;
            _patientChartService = new PatientChartService(patientChartRepository);
        }

        public bool NewRegisteredPatient(RegisteredPatient registeredPatient)
        {
            return _iRegisteredPatientRepository.Create(registeredPatient) && _iRegisteredUserRepository.Create(registeredPatient) && _patientChartService.NewEmptyChart(registeredPatient);
        }
        public bool ConvertRegisteredUserToRegisteredPatient( Doctor chosenDoctor, RegisteredUser registeredUser)
        {
            RegisteredPatient newRegisteredPatient = new RegisteredPatient(chosenDoctor, registeredUser);
            return _iRegisteredPatientRepository.Create(newRegisteredPatient) && _patientChartService.NewEmptyChart(newRegisteredPatient);

        }


        public bool RemoveRegisteredPatient(string id)
        {
            if (_iRegisteredPatientRepository.Delete(id) && _iRegisteredUserRepository.Delete(id))
                return true;
            return false;
        }

        public RegisteredPatient Get(string id)
            => _iRegisteredPatientRepository.Get(id);

        public bool EditRegisteredPatient(RegisteredPatient registeredPatient)
        {
            if (_iRegisteredPatientRepository.Update(registeredPatient) && _iRegisteredUserRepository.Update(registeredPatient))
                return true;
            return false;
        }

        public Doctor ChangeChosenDoctor(Doctor newChosenDoctor, RegisteredPatient patient)
        {
            RegisteredPatient foundPatient = _iRegisteredPatientRepository.Get(patient.Pin);
            if (foundPatient != null)
            {
                foundPatient.ChosenDoctor = newChosenDoctor;
                EditRegisteredPatient(foundPatient);
                return newChosenDoctor;
            }
            return null;
        }
        public List<RegisteredPatient> GetAll()
            => _iRegisteredPatientRepository.GetAll();
        
    }
}