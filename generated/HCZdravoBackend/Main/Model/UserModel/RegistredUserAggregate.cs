// File:    RegistredUserAggregate.cs
// Created: Tuesday, June 02, 2020 6:21:45 PM
// Purpose: Definition of Class RegistredUserAggregate

using System;
using System.Collections.Generic;


public class RegistredUserAggregate : IAggregate<RegistredUserIterator>
{
    private List<RegisteredUser> registredUsers;

    public RegistredUserAggregate()
    {
        registredUsers = new List<RegisteredUser>();
    }
    public int Count()
    {
        return registredUsers.Count;
    }

    public RegistredUserIterator CreateIterator()
    {
        return new RegistredUserIterator(this);
    }


    public List<RegisteredUser> getAllElements()
    {
        return registredUsers;
    }

    public RegisteredUser this[int index]
    {
        get { return registredUsers[index]; }
    }

    public void AddItem(RegisteredUser user)
    {
        registredUsers.Add(user);
    }
    public void RemoveItem(RegisteredUser user)
    {
        registredUsers.Remove(user);
    }

    public void setList(List<RegisteredUser> users)
    {
        registredUsers = new List<RegisteredUser>(users);
    }

}
