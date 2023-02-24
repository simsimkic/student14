// File:    NotificationRepository.cs
// Created: Monday, June 01, 2020 5:56:40 PM
// Purpose: Definition of Class NotificationRepository

using Newtonsoft.Json;
using Repository.RepositoryPatient;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryUser
{
    public class NotificationRepository : INotificationRepository
    {
        private string _path = "notification.json";
        public NotificationRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Notification>());
            }
        }

        public bool Create(Notification obj)
        {
            List<Notification> notifications = GetAll();
            if (Get(obj.Id) == null)
            {
                notifications.Add(obj);
                SaveAll(notifications);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            List<Notification> notifications = GetAll();
            Notification notification = Get(id);
            if (notification != null)
            {
                notifications.Remove(notification);
                SaveAll(notifications);
                return true;
            }
            return false;
        }

        public bool Update(Notification obj)
        {
            List<Notification> notifications = GetAll();
            Notification foundNotification = Get(obj.Id);
            if (foundNotification != null)
            {
                for (int i = 0; i < notifications.Count; i++)
                {
                    if (notifications[i].Id.Equals(obj.Id)) notifications[i] = obj;
                }
                SaveAll(notifications);
                return true;
            }
            return false;
        }

        public Notification Get(string id)
        {
            List<Notification> notifications = GetAll();
            foreach (Notification notification in notifications)
            {
                if (notification.Id.Equals(id)) return notification;
            }
            return null;
        }

        public List<Notification> GetAllUsersNotifications(string userId)
        {
            List<Notification> usersNotifications = new List<Notification>();
            foreach(Notification notification in GetAll())
            {
                if (notification.RegisteredUser.Pin.Equals(userId)) usersNotifications.Add(notification);
            }
            return usersNotifications;
        }

        public List<Notification> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Notification>>(jsonString);
            return new List<Notification>();
        }

        public void SaveAll(List<Notification> notifications)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, notifications);
                }
            }
        }
    }
}