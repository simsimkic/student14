// File:    RegistredUserIterator.cs
// Created: Tuesday, June 02, 2020 6:21:45 PM
// Purpose: Definition of Class RegistredUserIterator

using System;


public class RegistredUserIterator : IIterator<RegisteredUser>
{
    private RegistredUserAggregate aggregate;
    int index;

    public RegistredUserIterator(RegistredUserAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public RegisteredUser First()
    {
        return aggregate[0];
    }

    public RegisteredUser Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public RegisteredUser CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
