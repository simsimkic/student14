// File:    ExamAggregate.cs
// Created: Tuesday, June 02, 2020 4:00:22 AM
// Purpose: Definition of Class ExamAggregate

using System;
using System.Collections.Generic;


public class ExamAggregate : IAggregate<ExamIterator>
{
    private List<Examination> examinations;

    public ExamAggregate()
    {
        examinations = new List<Examination>();
    }

    public ExamAggregate(List<Examination> exams)
    {
        examinations = new List<Examination>(exams);
    }
    public int Count()
    {
        return examinations.Count;
    }

    public ExamIterator CreateIterator()
    {
        return new ExamIterator(this);
    }

    public List<Examination> getAllElements()
    {
        return examinations;
    }

    public Examination this[int index]
    {
        get { return examinations[index]; }
    }

    public void AddItem(Examination exa)
    {
        examinations.Add(exa);
    }
    public void RemoveItem(Examination exa)
    {
        examinations.Remove(exa);
    }

    public void setList(List<Examination> exams)
    {
        examinations = new List<Examination>(exams);
    }


}


