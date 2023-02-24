// File:    Person.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Person

using System;


public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Pin { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string ParentName { get; set; }

    public City CityOfBirth { get; set; }
    public Location LivingLocation { get; set; }
    public Person() { }
    public Person(string pin)
    {
        Name = null;
        Surname = null;
        Pin = pin;
        BirthDate = DateTime.MinValue;
        PhoneNumber = null;
        Email = null;
        ParentName = null;
        CityOfBirth = null;
        LivingLocation = null;
    }
    public Person(string name, string surname, string pin, DateTime birthDate, string phoneNumber, string email, string parentName, City cityOfBirth, Location livingLocation)
    {
        Name = name;
        Surname = surname;
        Pin = pin;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        Email = email;
        ParentName = parentName;
        CityOfBirth = cityOfBirth;
        LivingLocation = livingLocation;
    }

    public Person(Person person)
    {
        Name = person.Name;
        Surname = person.Surname;
        Pin = person.Pin;
        BirthDate = person.BirthDate;
        PhoneNumber = person.PhoneNumber;
        Email = person.Email;
        ParentName = person.ParentName;
        CityOfBirth = person.CityOfBirth;
        LivingLocation = person.LivingLocation;
    }

    public override bool Equals(object obj)
    {
        return obj is Person person &&
               Pin == person.Pin;
    }
}
