// File:    Answer.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Answer



using System;

public class Answer : Content
{
    public Doctor Doctor { get; set; }
    public Answer() { }
    public Answer(string id) : base(id) 
    {
        Doctor = null;
    }
    public Answer(Doctor doctor, string id, string text, DateTime date) : base(id, text, date)
    {
        Doctor = new Doctor(doctor.Pin);
    }
    public Answer(Doctor doctor, Content answerContent) : base(answerContent)
    {
        Doctor = new Doctor(doctor.Pin);
    }
    public override bool Equals(object obj)
    {
        return obj is Answer answer &&
               Id == answer.Id;
    }
}
