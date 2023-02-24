// File:    DrugAggregate.cs
// Created: Tuesday, June 02, 2020 4:53:32 AM
// Purpose: Definition of Class DrugAggregate

using System;
using System.Collections.Generic;

public class DrugAggregate : IAggregate<DrugIterator>
{
    private List<Drug> drugs;
    public DrugAggregate()
    {
        drugs = new List<Drug>();
    }

    public int Count()
    {
        return drugs.Count;
    }

    public DrugIterator CreateIterator()
    {
        return new DrugIterator(this);
    }


    public List<Drug> getAllElements()
    {
        return drugs;
    }

    public Drug this[int index]
    {
        get { return drugs[index]; }
    }

    public void AddItem(Drug drug)
    {
        drugs.Add(drug);
    }
    public void RemoveItem(Drug drug)
    {
        drugs.Remove(drug);
    }

    public void setList(List<Drug> drg)
    {
        drugs = new List<Drug>(drg);
    }

}
