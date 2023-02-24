// File:    AnswerAggregate.cs
// Created: Tuesday, June 02, 2020 6:20:36 PM
// Purpose: Definition of Class AnswerAggregate

using System;
using System.Collections.Generic;


public class AnswerAggregate : IAggregate<AnswerIterator>
{
    private List<Answer> answers;
    public AnswerAggregate()
    {
        answers = new List<Answer>();
    }

    public int Count()
    {
       return answers.Count;
    }

    public AnswerIterator CreateIterator()
    {
        return new AnswerIterator(this);
    }


    public List<Answer> getAllElements()
    {
        return answers;
    }

    public Answer this[int index]
    {
        get { return answers[index]; }
    }

    public void AddItem(Answer ans)
    {
        answers.Add(ans);
    }
    public void RemoveItem(Answer ans)
    {
        answers.Remove(ans);
    }

    public void setList(List<Answer> ans)
    {
        answers = new List<Answer>(ans);
    }

}
