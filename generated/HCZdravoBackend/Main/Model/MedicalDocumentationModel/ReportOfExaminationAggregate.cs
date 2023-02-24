// File:    ReportOfExaminationAggregate.cs
// Created: Tuesday, June 02, 2020 5:21:06 AM
// Purpose: Definition of Class ReportOfExaminationAggregate

using System;
using System.Collections.Generic;


public class ReportOfExaminationAggregate : IAggregate<ReportOfExaminationIterator>
{
    private List<ReportOfExamination> reportsOfExamination;

    public ReportOfExaminationAggregate()
    {
        reportsOfExamination = new List<ReportOfExamination>();
    }
    public int Count()
    {
        return reportsOfExamination.Count;
    }

    public ReportOfExaminationIterator CreateIterator()
    {
        return new ReportOfExaminationIterator(this);
    }

    public List<ReportOfExamination> getAllElements()
    {
        return reportsOfExamination;
    }

    public ReportOfExamination this[int index]
    {
        get { return reportsOfExamination[index]; }
    }

    public void AddItem(ReportOfExamination report)
    {
        reportsOfExamination.Add(report);
    }
    public void RemoveItem(ReportOfExamination report)
    {
        reportsOfExamination.Remove(report);
    }

    public void setList(List<ReportOfExamination> reports)
    {
        reportsOfExamination = new List<ReportOfExamination>(reports);
    }

}
