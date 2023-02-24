// File:    Examination.cs
// Created: Monday, June 01, 2020 4:38:30 PM
// Purpose: Definition of Class Examination



using System;


public class Examination : Appointment
{
    public Room ExamRoom { get; set; }

    public Examination() : base(){ }

    public Examination(string id) : base(id) 
    {
        ExamRoom = null;
    }

    public Examination(Room examRoom, bool priority, string id, AppointmentType type, RegisteredPatient registeredPatient, Term term, Doctor doctor, DateTime date) : base(priority, id, type, registeredPatient, term, doctor, date)
    {
        ExamRoom = new Room(examRoom.Id);
        ExamRoom.RoomType = RoomType.EXAMROOM;
    }

    public Examination(Room examRoom, Appointment appointment) : base(appointment)
    {
        ExamRoom = examRoom;
        ExamRoom.RoomType = RoomType.EXAMROOM;
    }

    public override bool Equals(object obj)
    {
        return obj is Examination exam &&
               Id == exam.Id;
    }
}

    


