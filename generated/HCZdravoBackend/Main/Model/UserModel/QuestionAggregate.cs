// File:    QuestionAggregate.cs
// Created: Tuesday, June 02, 2020 6:28:36 PM
// Purpose: Definition of Class QuestionAggregate

using System;
using System.Collections.Generic;


public class QuestionAggregate : IAggregate<QuestionIterator>
{
    private List<Question> questions;

    public QuestionAggregate()
    {
        questions = new List<Question>();
    }
    public int Count()
    {
        return questions.Count;
    }

    public QuestionIterator CreateIterator()
    {
        return new QuestionIterator(this);
    }


    public List<Question> getAllElements()
    {
        return questions;
    }

    public Question this[int index]
    {
        get { return questions[index]; }
    }

    public void AddItem(Question question)
    {
        questions.Add(question);
    }
    public void RemoveItem(Question question)
    {
        questions.Remove(question);
    }

    public void setList(List<Question> ques)
    {
        questions = new List<Question>(ques);
    }

}
