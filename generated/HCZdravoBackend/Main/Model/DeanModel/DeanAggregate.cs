// File:    DeanAggregate.cs
// Created: Tuesday, June 02, 2020 4:39:12 AM
// Purpose: Definition of Class DeanAggregate

using System;
using System.Collections.Generic;

public class DeanAggregate : IAggregate<DeanIterator>
{
    private List<Dean> deans;

    public DeanAggregate()
    {
        deans = new List<Dean>();
    }
    public int Count()
    {
        return  deans.Count;
    }

    public DeanIterator CreateIterator()
    {
        return new DeanIterator(this);
    }

    public List<Dean> getAllElements()
    {
        return deans;
    }

    public Dean this[int index]
    {
        get { return deans[index]; }
    }

    public void AddItem(Dean dean)
    {
        deans.Add(dean);
    }
    public void RemoveItem(Dean dean)
    {
        deans.Remove(dean);
    }

    public void setList(List<Dean> dea)
    {
        deans = new List<Dean>(dea);
    }

}



