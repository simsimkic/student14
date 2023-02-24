// File:    SecretaryIterator.cs
// Created: Tuesday, June 02, 2020 4:48:52 AM
// Purpose: Definition of Class SecretaryIterator

using System;


public class SecretaryIterator : IIterator<Secretary>
{

    private SecretaryAggregate aggregate;
    int index;

    public SecretaryIterator(SecretaryAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Secretary First()
    {
        return aggregate[0];
    }

    public Secretary Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Secretary CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
