// File:    RegisteredPatientController.cs
// Created: Monday, May 18, 2020 7:56:16 PM
// Purpose: Definition of Class RegisteredPatientController

using Service.ServicePatient;
using System;
using System.Collections.Generic;

namespace Controller.ControllerPatient
{
    public class RegisteredPatientController
    {
        private RegisteredPatientService _registeredPatientService;

        public RegisteredPatientController(RegisteredPatientService registeredPatientService)
        {
            _registeredPatientService = registeredPatientService;
        }

        public bool NewRegisteredPatient(RegisteredPatient registeredPatient)
         => _registeredPatientService.NewRegisteredPatient(registeredPatient);

        public bool ConvertRegisteredUserToRegisteredPatient(Doctor chosenDoctor, RegisteredUser registeredUser)
            => _registeredPatientService.ConvertRegisteredUserToRegisteredPatient(chosenDoctor,registeredUser);
        public bool RemoveRegisteredPatient(string id)
            => _registeredPatientService.RemoveRegisteredPatient(id);

        public bool EditRegisteredPatient(RegisteredPatient registeredPatient)
            => _registeredPatientService.EditRegisteredPatient(registeredPatient);

        public RegisteredPatient Get(string id)
            => _registeredPatientService.Get(id);

        public Doctor ChangeChosenDoctor(Doctor newChosenDoctor, RegisteredPatient patient)
            => _registeredPatientService.ChangeChosenDoctor(newChosenDoctor, patient);

        public List<RegisteredPatient> GetAll()
            => _registeredPatientService.GetAll();
    }
}