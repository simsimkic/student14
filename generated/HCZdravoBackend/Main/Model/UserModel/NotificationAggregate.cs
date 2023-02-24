// File:    NotificationAggregate.cs
// Created: Tuesday, June 02, 2020 6:26:45 PM
// Purpose: Definition of Class NotificationAggregate

using System;
using System.Collections.Generic;


public class NotificationAggregate : IAggregate<NotificationIterator>
{
    private List<Notification> notifications;

    public NotificationAggregate()
    {
        notifications = new List<Notification>();
    }
    public int Count()
    {
        return notifications.Count;
    }

    public NotificationIterator CreateIterator()
    {
       return new NotificationIterator(this);
    }


    public List<Notification> getAllElements()
    {
        return notifications;
    }

    public Notification this[int index]
    {
        get { return notifications[index]; }
    }

    public void AddItem(Notification notification)
    {
        notifications.Add(notification);
    }
    public void RemoveItem(Notification notification)
    {
        notifications.Remove(notification);
    }

    public void setList(List<Notification> notifs)
    {
        notifications = new List<Notification>(notifs);
    }

}
