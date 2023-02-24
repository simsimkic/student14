// File:    NotificationIterator.cs
// Created: Tuesday, June 02, 2020 6:26:45 PM
// Purpose: Definition of Class NotificationIterator

using System;


public class NotificationIterator : IIterator<Notification>
{
    private NotificationAggregate aggregate;
    int index;

    public NotificationIterator(NotificationAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Notification First()
    {
        return aggregate[0];
    }

    public Notification Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Notification CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
