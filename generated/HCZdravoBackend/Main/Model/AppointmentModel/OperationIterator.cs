// File:    OperationIterator.cs
// Created: Tuesday, June 02, 2020 4:06:02 AM
// Purpose: Definition of Class OperationIterator

using System;


public class OperationIterator : IIterator<Operation>
{
    private OperationAggregate aggregate;
    int index;

    public OperationIterator(OperationAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = -1;
    }
    public Operation First()
    {
        return aggregate[0];
    }

    public Operation Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Operation CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
