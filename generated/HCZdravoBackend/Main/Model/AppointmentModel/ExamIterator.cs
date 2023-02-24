// File:    ExamIterator.cs
// Created: Tuesday, June 02, 2020 4:00:22 AM
// Purpose: Definition of Class ExamIterator

using System;


public class ExamIterator : IIterator<Examination>
{
    private ExamAggregate aggregate;
    int index;

    public ExamIterator(ExamAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = -1;
    }
    public Examination First()
    {
        return aggregate[0];
    }

    public Examination Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Examination CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
