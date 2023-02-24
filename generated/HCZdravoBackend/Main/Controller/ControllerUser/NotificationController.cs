// File:    NotificationController.cs
// Created: Monday, June 01, 2020 5:54:12 PM
// Purpose: Definition of Class NotificationController

using Service.ServiceUser;
using System.Collections.Generic;

namespace Controller.ControllerUser
{
    public class NotificationController
    {
        private NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        public bool NewNotification(Notification notification)
            => _notificationService.NewNotification(notification);
        

        public bool SetNotification(Notification notification)
            => _notificationService.SetNotification(notification);
        

        public bool DeleteNotification(string notificationId)
            => _notificationService.DeleteNotification(notificationId);
        
        public List<Notification> GetAllUsersNotifications(string userId)
            => _notificationService.GetAllUsersNotifications(userId);
        public bool MakeRequestForEmergencyAppointment(Notification notification)
           => _notificationService.MakeRequestForEmergencyAppointment(notification);
        public List<Notification> GetAllEmergencyExamsRequests()
            => _notificationService.GetAllEmergencyExamsRequests();
        public Notification GetNotification(string id)
            => _notificationService.GetNotification(id);

        public bool ResponseToEmergencyRequest(Notification notification)
            => _notificationService.ResponseToEmergencyRequest(notification);


    }
}