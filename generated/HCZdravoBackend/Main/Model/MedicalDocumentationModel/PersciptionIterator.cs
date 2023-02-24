// File:    PersciptionIterator.cs
// Created: Tuesday, June 02, 2020 5:17:24 AM
// Purpose: Definition of Class PersciptionIterator

using System;

public class PersciptionIterator : IIterator<Prescription>
{
    private PersciptionAggregate aggregate;
    int index;

    public PersciptionIterator(PersciptionAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Prescription First()
    {
        return aggregate[0];
    }

    public Prescription Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Prescription CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
