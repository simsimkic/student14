// File:    SecretaryService.cs
// Created: Tuesday, June 02, 2020 6:31:19 PM
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using Repository.RepositorySecretary;
using Repository.RepositoryUser;

namespace Service.ServiceSecretary
{
    public class SecretaryService
    {
        private ISecretaryRepository _secretaryRepository;
        private INotificationRepository _notificationRepository;

        public SecretaryService(SecretaryRepository secretaryRepository, NotificationRepository notificationRepository)
        {
            _secretaryRepository = secretaryRepository;
            _notificationRepository = notificationRepository;
        }

        public bool DoesSecretaryExist(string username, string password)
        {
            SecretaryAggregate secretaries = new SecretaryAggregate(_secretaryRepository.GetAll());
            var iterator = secretaries.CreateIterator();
            while(iterator.IsDone())
            {
                if (iterator.CurrentItem().Account.Username.Equals(username) &&
                    iterator.CurrentItem().Account.Password.Equals(password))
                    return true;
            }
            return false;
        }

        public bool MakeResponseForEmergencyAppointment(Notification notification)
            => _notificationRepository.Update(notification);

    }
}