// File:    TermIterator.cs
// Created: Tuesday, June 02, 2020 5:03:08 AM
// Purpose: Definition of Class TermIterator

using System;


public class TermIterator : IIterator<Term>
{
    private TermAggregate aggregate;
    int index;

    public TermIterator(TermAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Term First()
    {
        return aggregate[0];
    }

    public Term Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Term CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
