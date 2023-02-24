// File:    DocReport.cs
// Created: Monday, June 01, 2020 5:02:56 PM
// Purpose: Definition of Class DocReport


using System;

public class DocReport : Report
{
    public Doctor Doctor { get; set; }
    public DocReport(string reportId) : base(reportId) { }
    public DocReport(Doctor doctor, string reportId, DateTime startDate, DateTime endDate, string content):base(startDate,endDate,reportId, content)
    {
        Doctor = doctor;
    }
}
