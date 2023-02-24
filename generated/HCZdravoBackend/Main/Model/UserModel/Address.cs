// File:    Address.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Address

using System;


public class Address
{
    public string StreetName { get; set; }
    public int StreetNumber { get; set; }

    public Address(string streetName, int streetNumber)
    {
        StreetName = streetName;
        StreetNumber = streetNumber;
    }


}
