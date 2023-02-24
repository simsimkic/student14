// File:    PrescribedDrug.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class PrescribedDrug

using System;


public class PrescribedDrug
{
    public string Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DailyDose { get; set; }
    public Drug Drug { get; set; }

    public PrescribedDrug() { }
    public PrescribedDrug(string id)
    {
        Id = id;
        StartDate = DateTime.MinValue;
        EndDate = DateTime.MaxValue;
        DailyDose = 0;
        Drug = null;
    }
    public PrescribedDrug(string id, DateTime startDate, DateTime endDate, int dailyDose, Drug drug)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
        DailyDose = dailyDose;
        Drug = new Drug(drug.Id);
    }

}
