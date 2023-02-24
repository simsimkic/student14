// File:    Prescription.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class Prescription

using System;


public class Prescription
{
    public string Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Drug Drug { get; set; }
    public PatientChart PatientChart{ get; set; }

    public Prescription() { }

    public Prescription(string id)
    {
        Id = id;
        Description = null;
        Date = DateTime.MinValue;
        Drug = null;
        PatientChart = null;
    }
    public Prescription(string description, DateTime date, string id, Drug drug, PatientChart patientChart)
    {
        Description = description;
        Date = date;
        Id = id;
        Drug = new Drug(drug.Id);
        PatientChart = new PatientChart(patientChart.Id);
    }

}
