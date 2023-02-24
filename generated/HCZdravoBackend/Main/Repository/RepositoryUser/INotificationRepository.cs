// File:    INotificationRepository.cs
// Created: Monday, June 01, 2020 6:10:47 PM
// Purpose: Definition of Interface INotificationRepository

using System.Collections.Generic;

namespace Repository.RepositoryUser
{
    public interface INotificationRepository : IRepository<Notification>
    {
        bool Create(Notification obj);

        bool Delete(string id);

        bool Update(Notification obj);

        Notification Get(string id);

        List<Notification> GetAllUsersNotifications(string usersId);
    }
}