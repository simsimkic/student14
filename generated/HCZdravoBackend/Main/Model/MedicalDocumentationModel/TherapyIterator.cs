// File:    TherapyIterator.cs
// Created: Tuesday, June 02, 2020 5:19:18 AM
// Purpose: Definition of Class TherapyIterator

using System;

public class TherapyIterator : IIterator<Therapy>
{
    private TherapyAggregate aggregate;
    int index;

    public TherapyIterator(TherapyAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Therapy First()
    {
        return aggregate[0];
    }

    public Therapy Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Therapy CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
