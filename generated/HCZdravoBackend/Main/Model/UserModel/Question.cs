// File:    Question.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Question

using System;


public class Question : Content
{
    public Boolean Answered { get; set; }
    public string Title { get; set; }
    public Answer Answer { get; set; }
    public RegisteredPatient RegisteredPatient { get; set; }
    
    public Question() { }

    public Question(string id) : base(id)
    {
        Answered = false;
        Answer = null;
        Title = null;
    }
    public Question(string title, RegisteredPatient registeredPatient, string id, string text, DateTime dateOfCreation) : base(id, text, dateOfCreation)
    {
        Answered = false;
        Title = title;
        RegisteredPatient = new RegisteredPatient(registeredPatient.Pin);
        Answer = null;
    }
    public Question(bool answered, string title, Answer answer, RegisteredPatient registeredPatient, string id, string text, DateTime date) : base(id, text, date)
    {
        Answered = answered;
        Title = title;
        Answer = answer;
        RegisteredPatient = new RegisteredPatient(registeredPatient.Pin);
    }

    public override bool Equals(object obj)
    {
        return obj is Question question &&
               Id == question.Id;
    }

}
