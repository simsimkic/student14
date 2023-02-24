// File:    DeanIterator.cs
// Created: Tuesday, June 02, 2020 4:39:13 AM
// Purpose: Definition of Class DeanIterator

using System;

public class DeanIterator : IIterator<Dean>
{

    private DeanAggregate aggregate;
    int index;

    public DeanIterator(DeanAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Dean First()
    {
        return aggregate[0];
    }

    public Dean Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Dean CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}


