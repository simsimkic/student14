// File:    SecretaryController.cs
// Created: Tuesday, June 02, 2020 6:33:03 PM
// Purpose: Definition of Class SecretaryController

using System;
using System.Collections.Generic;
using Service.ServiceSecretary;

namespace Controller.ControllerSecretary
{
    public class SecretaryController
    {
        public SecretaryService _secretaryService;

        public SecretaryController(SecretaryService service)
        {
            _secretaryService = service ;
        }
        public bool DoesSecretaryExist(string username, string password)
             => _secretaryService.DoesSecretaryExist(username, password);

        public bool MakeResponseForEmergencyAppointment(Notification notification)
           => _secretaryService.MakeResponseForEmergencyAppointment(notification);
    }
}