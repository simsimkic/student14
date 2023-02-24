// File:    City.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class City

using System;


public class City
{
    public string Name { get; set; }
    public int Pin { get; set; }

    public City(string name, int pin)
    {
        Name = name;
        Pin = pin;
    }
}
