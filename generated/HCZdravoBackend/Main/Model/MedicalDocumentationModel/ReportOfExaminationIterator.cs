// File:    ReportOfExaminationIterator.cs
// Created: Tuesday, June 02, 2020 5:21:06 AM
// Purpose: Definition of Class ReportOfExaminationIterator

using System;


public class ReportOfExaminationIterator : IIterator<ReportOfExamination>
{
    private ReportOfExaminationAggregate aggregate;
    int index;

    public ReportOfExaminationIterator(ReportOfExaminationAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public ReportOfExamination First()
    {
        return aggregate[0];
    }

    public ReportOfExamination Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public ReportOfExamination CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
