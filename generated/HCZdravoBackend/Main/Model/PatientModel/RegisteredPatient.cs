// File:    RegisteredPatient.cs
// Created: Monday, June 01, 2020 4:32:16 PM
// Purpose: Definition of Class RegisteredPatient

using System;
using System.Collections.Generic;

public class RegisteredPatient : RegisteredUser
{
    public Doctor ChosenDoctor { get; set; }

    public RegisteredPatient() { }
    public RegisteredPatient(string id) : base(id) {
        ChosenDoctor = null;
    }
    public RegisteredPatient(Doctor doctor, Account account, string name, string surname, string pin, DateTime birthDate, string phoneNumber, string email, string parentName, City cityOfBirth, Location location) : base(account, name, surname, pin, birthDate, phoneNumber, email, parentName, cityOfBirth, location)
    {
        ChosenDoctor = new Doctor(doctor.Pin);
    }
    public RegisteredPatient(Doctor doctor, RegisteredUser registeredUser) : base(registeredUser)
    {
        ChosenDoctor = new Doctor(doctor.Pin);
    }
    public override bool Equals(object obj)
    {
        return obj is RegisteredPatient patient &&
               base.Equals(obj) &&
               Pin == patient.Pin;
    }
}
