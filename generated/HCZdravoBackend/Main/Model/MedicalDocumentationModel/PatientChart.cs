// File:    PatientChart.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class PatientChart

using System.Collections.Generic;

public class PatientChart
{
    public string Id { get; set; }

    public List<Allergy> Allergies { get; set; }

    public RegisteredPatient RegisteredPatient { get; set; }

    public PatientChart() { }

    public PatientChart(string id)
    {
        Id = id;
        Allergies = new List<Allergy>();
        RegisteredPatient = null;
    }
    public PatientChart(string id, List<Allergy> allergies, RegisteredPatient registeredPatient)
    {
        Id = id;
        Allergies = allergies;
        RegisteredPatient = new RegisteredPatient(registeredPatient.Pin);
    }

    public PatientChart(string id, RegisteredPatient registeredPatient)
    {
        Id = id;
        Allergies = new List<Allergy>();
        RegisteredPatient = new RegisteredPatient(registeredPatient.Pin);
    }



}
