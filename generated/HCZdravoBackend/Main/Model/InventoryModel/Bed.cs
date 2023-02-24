// File:    Bed.cs
// Created: Monday, June 01, 2020 4:57:22 PM
// Purpose: Definition of Class Bed

using System;


public class Bed : Item
{
    public Boolean Taken { get; set; }
    public Bed(string id) : base(id) 
    {
        Taken = false;
    }
    public Bed(bool taken, Room recoveryRoom, string id, int count, string name):base(id,count,name)
    {
        Taken = taken;
    }


}
