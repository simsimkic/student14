// File:    PersciptionAggregate.cs
// Created: Tuesday, June 02, 2020 5:17:24 AM
// Purpose: Definition of Class PersciptionAggregate

using System;
using System.Collections.Generic;

public class PersciptionAggregate : IAggregate<PersciptionIterator>
{
    private List<Prescription> presciptions;

    public PersciptionAggregate()
    {
        presciptions = new List<Prescription>();
    }
    public int Count()
    {
        return presciptions.Count;
    }

    public PersciptionIterator CreateIterator()
    {
        return new PersciptionIterator(this);
    }


    public List<Prescription> getAllElements()
    {
        return presciptions;
    }

    public Prescription this[int index]
    {
        get { return presciptions[index]; }
    }

    public void AddItem(Prescription prescription)
    {
        presciptions.Add(prescription);
    }
    public void RemoveItem(Prescription prescription)
    {
        presciptions.Remove(prescription);
    }

    public void setList(List<Prescription> presc)
    {
        presciptions = new List<Prescription>(presc);
    }

}
