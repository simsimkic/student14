// File:    DrugIterator.cs
// Created: Tuesday, June 02, 2020 4:53:32 AM
// Purpose: Definition of Class DrugIterator

using System;


public class DrugIterator : IIterator<Drug>
{
    private DrugAggregate aggregate;
    int index;

    public DrugIterator(DrugAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Drug First()
    {
        return aggregate[0];
    }

    public Drug Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Drug CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
