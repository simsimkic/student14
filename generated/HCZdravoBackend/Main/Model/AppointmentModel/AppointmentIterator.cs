// File:    AppointmentIterator.cs
// Created: Tuesday, June 02, 2020 4:12:51 AM
// Purpose: Definition of Class AppointmentIterator

using System;

public class AppointmentIterator : IIterator<Appointment>
{
    private AppointmentAggregate aggregate;
    int index;

    public AppointmentIterator(AppointmentAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Appointment First()
    {
        return aggregate[0];
    }

    public Appointment Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Appointment CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}



