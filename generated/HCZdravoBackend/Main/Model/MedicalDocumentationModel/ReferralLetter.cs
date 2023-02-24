// File:    ReferralLetter.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class ReferralLetter

using System;

public class ReferralLetter
{
    public string Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public PatientChart PatientChart { get; set; }
    public Doctor Doctor { get; set; }
    public ReferralLetter() { }
    public ReferralLetter(string id)
    {
        Id = id;
        Description = null;
        Date = DateTime.MinValue;
        PatientChart = null;
        Doctor = null;
    }
    public ReferralLetter(string description, DateTime date, string id, PatientChart patientChart, Doctor doctor)
    {
        Description = description;
        Date = date;
        Id = id;
        PatientChart = new PatientChart(patientChart.Id);
        Doctor = new Doctor(doctor.Pin);
    }

}
