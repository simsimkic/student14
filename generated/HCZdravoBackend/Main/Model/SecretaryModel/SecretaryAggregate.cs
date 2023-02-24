// File:    SecretaryAggregate.cs
// Created: Tuesday, June 02, 2020 4:48:52 AM
// Purpose: Definition of Class SecretaryAggregate

using System;
using System.Collections.Generic;


public class SecretaryAggregate : IAggregate<SecretaryIterator>
{
    private List<Secretary> secretaries;
    
    public SecretaryAggregate()
    {
        secretaries = new List<Secretary>();
    }

    public SecretaryAggregate(List<Secretary> sec)
    {
        secretaries = new List<Secretary>(sec);
    }

    public SecretaryIterator CreateIterator()
    {
        return new SecretaryIterator(this);
    }

    public int Count()
    {
        return secretaries.Count;
    }
    public List<Secretary> getAllElements()
    {
        return secretaries;
    }

    public Secretary this[int index]
    {
        get { return secretaries[index]; }
    }

    public void AddItem(Secretary student)
    {
        secretaries.Add(student);
    }
    public void RemoveItem(Secretary student)
    {
        secretaries.Remove(student);
    }

    public void setList(List<Secretary> sec)
    {
        secretaries = new List<Secretary>(sec);
    }


}
