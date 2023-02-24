// File:    RegisteredUser.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class RegisteredUser

using System;
using System.Collections.Generic;


public class RegisteredUser : Person
{
    public Account Account { get; set; }

    public RegisteredUser() { }
    public RegisteredUser(string id) : base(id) 
    {
        Account = null;
    }

    public RegisteredUser(Account account, string name, string surname, string pin, DateTime birthDate, 
        string phoneNumber, string email, string parentName, City cityOfBirth, Location location) : 
        base(name, surname, pin, birthDate, phoneNumber, email, parentName, cityOfBirth, location)
    {
        Account = account;

    }
    public RegisteredUser(Account account, Person person) : base(person)
    {
        Account = account;
    }
    public RegisteredUser(RegisteredUser registeredUser) : base(registeredUser)
    {
        Account = registeredUser.Account;

    }

    public override bool Equals(object obj)
    {
        return obj is RegisteredUser registeredUser &&
               Pin == registeredUser.Pin;
    }
}
