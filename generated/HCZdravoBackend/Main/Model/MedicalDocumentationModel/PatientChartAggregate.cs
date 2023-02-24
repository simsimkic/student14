// File:    PatientChartAggregate.cs
// Created: Tuesday, June 02, 2020 5:15:59 AM
// Purpose: Definition of Class PatientChartAggregate

using System;
using System.Collections.Generic;

public class PatientChartAggregate : IAggregate<PatientChartIterator>
{
    private List<PatientChart> patientCharts;

    public PatientChartAggregate()
    {
        patientCharts = new List<PatientChart>();
    }
    public int Count()
    {
        return patientCharts.Count;
    }

    public PatientChartIterator CreateIterator()
    {
        return new PatientChartIterator(this);
    }

    public List<PatientChart> getAllElements()
    {
        return patientCharts;
    }

    public PatientChart this[int index]
    {
        get { return patientCharts[index]; }
    }

    public void AddItem(PatientChart chart)
    {
        patientCharts.Add(chart);
    }
    public void RemoveItem(PatientChart chart)
    {
        patientCharts.Remove(chart);
    }

    public void setList(List<PatientChart> charts)
    {
        patientCharts = new List<PatientChart>(charts);
    }

}
