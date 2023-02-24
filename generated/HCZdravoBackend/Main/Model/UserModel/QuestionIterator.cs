// File:    QuestionIterator.cs
// Created: Tuesday, June 02, 2020 6:28:36 PM
// Purpose: Definition of Class QuestionIterator

using System;


public class QuestionIterator : IIterator<Question>
{
    private QuestionAggregate aggregate;
    int index;

    public QuestionIterator(QuestionAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public Question First()
    {
        return aggregate[0];
    }

    public Question Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Question CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
