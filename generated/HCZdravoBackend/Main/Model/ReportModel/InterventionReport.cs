// File:    InterventionReport.cs
// Created: Monday, June 01, 2020 5:02:56 PM
// Purpose: Definition of Class InterventionReport



using System;
using System.Collections.Generic;

public class InterventionReport : Report
{
    public List<Operation> Operations { get; set; }

    public List<Examination> Examinations { get; set; }

    public InterventionReport(string reportId) : base(reportId) { }
    public InterventionReport(List<Operation> operations, List<Examination> examinations, DateTime startDate, DateTime endDate, string reportId, string content):base(startDate,endDate,reportId, content)
    {
        Operations = operations;
        Examinations = examinations;
    }


}