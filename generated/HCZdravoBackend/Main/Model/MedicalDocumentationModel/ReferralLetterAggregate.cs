// File:    ReferralLetterAggregate.cs
// Created: Tuesday, June 02, 2020 5:13:17 AM
// Purpose: Definition of Class ReferralLetterAggregate

using System;
using System.Collections.Generic;


public class ReferralLetterAggregate : IAggregate<ReferralLetterIterator>
{
    private List<ReferralLetter> referralLetters;

    public ReferralLetterAggregate()
    {
        referralLetters = new List<ReferralLetter>();
    }
    public int Count()
    {
        return referralLetters.Count;
    }

    public ReferralLetterIterator CreateIterator()
    {
        return new ReferralLetterIterator(this);
    }

    public List<ReferralLetter> getAllElements()
    {
        return referralLetters;
    }

    public ReferralLetter this[int index]
    {
        get { return referralLetters[index]; }
    }

    public void AddItem(ReferralLetter referral)
    {
        referralLetters.Add(referral);
    }
    public void RemoveItem(ReferralLetter referral)
    {
        referralLetters.Remove(referral);
    }

    public void setList(List<ReferralLetter> referrals)
    {
        referralLetters = new List<ReferralLetter>(referrals);
    }

}
