// File:    TherapyAggregate.cs
// Created: Tuesday, June 02, 2020 5:19:18 AM
// Purpose: Definition of Class TherapyAggregate

using System;
using System.Collections.Generic;


public class TherapyAggregate : IAggregate<TherapyIterator>
{
    private List<Therapy> therapies;

    public TherapyAggregate()
    {
        therapies = new List<Therapy>();
    }
    public int Count()
    {
       return therapies.Count;
    }

    public TherapyIterator CreateIterator()
    {
        return new TherapyIterator(this);
    }


    public List<Therapy> getAllElements()
    {
        return therapies;
    }

    public Therapy this[int index]
    {
        get { return therapies[index]; }
    }

    public void AddItem(Therapy therapy)
    {
        therapies.Add(therapy);
    }
    public void RemoveItem(Therapy therapy)
    {
        therapies.Remove(therapy);
    }

    public void setList(List<Therapy> ther)
    {
        therapies = new List<Therapy>(ther);
    }

}
