// File:    Secretary.cs
// Created: Monday, June 01, 2020 5:05:05 PM
// Purpose: Definition of Class Secretary

using System;


public class Secretary : RegisteredUser
{
    public ReportFactory ReportFactory { get; set; }
    public Secretary() { }
    public Secretary(string pin) : base(pin) 
    {
        ReportFactory = null;
    }
    public Secretary(ReportFactory reportFactory, Account account, string name, string surname, string pin, DateTime birthDate, string phoneNumber, string email, string parentName, City cityOfBirth, Location location) : base(account, name, surname, pin, birthDate, phoneNumber, email, parentName, cityOfBirth, location)
    {
        ReportFactory = reportFactory;
    }

}
