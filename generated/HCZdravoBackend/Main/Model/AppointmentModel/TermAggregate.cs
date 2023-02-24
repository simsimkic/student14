// File:    TermAggregate.cs
// Created: Tuesday, June 02, 2020 5:03:07 AM
// Purpose: Definition of Class TermAggregate

using System;
using System.Collections.Generic;


public class TermAggregate : IAggregate<TermIterator>
{
    private List<Term> terms;

    public TermAggregate()
    {
        terms = new List<Term>();
    }

    public int Count()
    {
       return terms.Count;
    }

    public TermIterator CreateIterator()
    {
       return new TermIterator(this);
    }

    public List<Term> getAllElements()
    {
        return terms;
    }

    public Term this[int index]
    {
        get { return terms[index]; }
    }

    public void AddItem(Term term)
    {
        terms.Add(term);
    }
    public void RemoveItem(Term term)
    {
        terms.Remove(term);
    }

    public void setList(List<Term> ter)
    {
        terms = new List<Term>(ter);
    }

}
