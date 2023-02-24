// File:    ReferralLetterIterator.cs
// Created: Tuesday, June 02, 2020 5:13:17 AM
// Purpose: Definition of Class ReferralLetterIterator

using System;


public class ReferralLetterIterator : IIterator<ReferralLetter>
{
    private ReferralLetterAggregate aggregate;
    int index;

    public ReferralLetterIterator(ReferralLetterAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public ReferralLetter First()
    {
        return aggregate[0];
    }

    public ReferralLetter Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public ReferralLetter CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
