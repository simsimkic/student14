// File:    NotificationService.cs
// Created: Monday, June 01, 2020 5:47:42 PM
// Purpose: Definition of Class NotificationService

using Repository.RepositoryUser;
using System;
using System.Collections.Generic;

namespace Service.ServiceUser
{
    public class NotificationService
    {
        private INotificationRepository _iNotificationRepository;

        public NotificationService(NotificationRepository notificationRepository)
        {
            _iNotificationRepository = notificationRepository;
        }

        public bool NewNotification(Notification notification)
            => _iNotificationRepository.Create(notification);

        public bool SetNotification(Notification notification)
            => _iNotificationRepository.Update(notification);

        public bool DeleteNotification(string notificationId)
            => _iNotificationRepository.Delete(notificationId);

        public List<Notification> GetAllUsersNotifications(string userId)
            => _iNotificationRepository.GetAllUsersNotifications(userId);

        public bool MakeRequestForEmergencyAppointment(Notification notification)
           => _iNotificationRepository.Create(notification);

        public List<Notification> GetAllEmergencyExamsRequests()
        {
            List<Notification> allNotifications = _iNotificationRepository.GetAll();
            List<Notification> emergencyRequestsNotifications = new List<Notification>();
            foreach(Notification notification in allNotifications)
            {
                if (notification.IsEmergencyAppointment.Equals(NotificationType.EMERGENCY_REQUEST)) emergencyRequestsNotifications.Add(notification);
            }
            return emergencyRequestsNotifications;
        }

        public Notification GetNotification(string id)
            => _iNotificationRepository.Get(id);

        public bool ResponseToEmergencyRequest(Notification notification)
            => _iNotificationRepository.Update(notification);
    }
}