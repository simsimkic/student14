// File:    Shift.cs
// Created: Monday, June 01, 2020 4:47:05 PM
// Purpose: Definition of Class Shift

using System;


public class Shift
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public Shift(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }
}
