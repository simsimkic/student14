// File:    Therapy.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class Therapy

using System;
using System.Collections.Generic;

public class Therapy
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public PatientChart PatientChart { get; set; }
    public List<PrescribedDrug> PrescribedDrugs { get; set; }

    public Therapy() { }
    public Therapy(string id)
    {
        Id = id;
        Date = DateTime.MinValue;
        PatientChart = null;
        PrescribedDrugs = new List<PrescribedDrug>();
    }
    public Therapy(DateTime date, string id, List<PrescribedDrug> prescribedDrugs, PatientChart patientChart)
    {
        Date = date;
        Id = id;
        PrescribedDrugs = prescribedDrugs;
        PatientChart = new PatientChart(patientChart.Id);
    }

}
