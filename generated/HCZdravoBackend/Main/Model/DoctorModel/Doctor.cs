// File:    Doctor.cs
// Created: Monday, June 01, 2020 4:51:17 PM
// Purpose: Definition of Class Doctor

using Newtonsoft.Json;
using System;
using System.Collections.Generic;



public class Doctor : RegisteredUser
{

    public string Specialization { get; set; }
    public Room DefaultOperationRoom { get; set; }
    public Room DefaultExamRoom { get; set; }
    public DoctorStatus Status { get; set; }

    public List<Shift> Shifts { get; set; }
    public Doctor() : base() { }
    public Doctor(string id) : base(id) 
    {
        Specialization = null;
        DefaultExamRoom = null;
        DefaultOperationRoom = null;
        Shifts = new List<Shift>();
        Status = DoctorStatus.WORKING;
    }
    public Doctor(string specialization, Room examRoom, Room operatingRoom, 
        Account account, string name, string surname, string pin, DateTime birthDate,
        string phoneNumber, string email, string parentName, City cityOfBirth, Location location) : base(account, name, surname, pin, birthDate, phoneNumber, email, parentName, cityOfBirth, location)
    {
        Specialization = specialization;
        DefaultExamRoom = new Room(examRoom.Id);
        DefaultExamRoom.RoomType = RoomType.EXAMROOM;
        DefaultOperationRoom = new Room(operatingRoom.Id);
        DefaultOperationRoom.RoomType = RoomType.OPERATINGROOM;
        Shifts = new List<Shift>();
        Status = DoctorStatus.WORKING;
    }

    public override bool Equals(object obj)
    {
        return obj is Doctor doctor &&
               base.Equals(obj) &&
               Pin == doctor.Pin;
    }

    public override string ToString()
    {
        return Pin + " " + "Dr. " + Name + " " + Status.ToString();
    }
}