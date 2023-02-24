// File:    ReportFactory.cs
// Created: Monday, June 01, 2020 5:02:56 PM
// Purpose: Definition of Class ReportFactory

using System;
using System.Collections;


public class ReportFactory
{
    public Hashtable RegisteredReports { get; set; }

    public Report MakeReport(string type)
    {
        throw new NotImplementedException();
    }

}
