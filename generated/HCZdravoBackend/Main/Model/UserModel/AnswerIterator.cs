// File:    AnswerIterator.cs
// Created: Tuesday, June 02, 2020 6:20:36 PM
// Purpose: Definition of Class AnswerIterator

using System;


public class AnswerIterator : IIterator<Answer>
{
    private AnswerAggregate aggregate;
    int index;

    public AnswerIterator(AnswerAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Answer First()
    {
        return aggregate[0];
    }

    public Answer Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Answer CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
