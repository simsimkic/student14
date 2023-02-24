// File:    ReportOfExamination.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class ReportOfExamination

using System;


public class ReportOfExamination
{
    public string Id { get; set; }
    public string Opinion { get; set; }
    public string Diagnosis { get; set; }
    public string Symptom { get; set; }
    public DateTime Date { get; set; }
    public PatientChart PatientChart { get; set; }
    public ReportOfExamination() { }
    public ReportOfExamination(string id)
    {
        Id = id;
        Opinion = null;
        Diagnosis = null;
        Symptom = null;
        Date = DateTime.MinValue;
        PatientChart = null;
    }
    public ReportOfExamination(string opinion, string diagnosis, string symptom, DateTime date, string id, PatientChart patientChart)
    {
        Opinion = opinion;
        Diagnosis = diagnosis;
        Symptom = symptom;
        Date = date;
        Id = id;
        PatientChart = new PatientChart(patientChart.Id);
    }

}
