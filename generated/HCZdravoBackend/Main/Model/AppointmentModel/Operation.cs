// File:    Operation.cs
// Created: Monday, June 01, 2020 4:38:30 PM
// Purpose: Definition of Class Operation


using System;

public class Operation : Appointment
{
    public Room OperatingRoom { get; set; }

    public Operation() : base() {}
    public Operation(string id) : base(id) 
    {
        OperatingRoom = null;
    }
    public Operation(Room operatingRoom, bool priority, string id, AppointmentType type, RegisteredPatient registeredPatient, Term term, Doctor doctor, DateTime date) : base(priority, id, type, registeredPatient, term, doctor, date)
    {
        OperatingRoom = new Room(operatingRoom.Id);
        OperatingRoom.RoomType = RoomType.OPERATINGROOM;
    }

    public override bool Equals(object obj)
    {
        return obj is Operation exam &&
               Id == exam.Id;
    }
}

