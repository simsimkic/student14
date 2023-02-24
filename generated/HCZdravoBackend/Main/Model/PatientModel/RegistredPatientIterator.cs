// File:    RegistredPatientIterator.cs
// Created: Tuesday, June 02, 2020 4:45:10 AM
// Purpose: Definition of Class RegistredPatientIterator

using System;


public class RegistredPatientIterator : IIterator<RegisteredPatient>
{
    private RegistredPatientAggregate aggregate;
    int index;

    public RegistredPatientIterator(RegistredPatientAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public RegisteredPatient First()
    {
        return aggregate[0];
    }

    public RegisteredPatient Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public RegisteredPatient CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
