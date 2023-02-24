// File:    Report.cs
// Created: Monday, June 01, 2020 5:02:56 PM
// Purpose: Definition of Class Report

using System;


public abstract class Report
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Id { get; set; }

    public string Content { get; set; }

    public Report(string reportId)
    {
        Id = reportId;
    }
    public Report(DateTime startDate, DateTime endDate, string reportId, string content)
    {
        StartDate = startDate;
        EndDate = endDate;
        Id = reportId;
        Content = content;
    }

}