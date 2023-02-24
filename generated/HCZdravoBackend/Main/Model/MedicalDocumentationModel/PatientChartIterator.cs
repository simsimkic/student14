// File:    PatientChartIterator.cs
// Created: Tuesday, June 02, 2020 5:15:59 AM
// Purpose: Definition of Class PatientChartIterator

using System;

public class PatientChartIterator : IIterator<PatientChart>
{
    private PatientChartAggregate aggregate;
    int index;

    public PatientChartIterator(PatientChartAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public PatientChart First()
    {
        return aggregate[0];
    }

    public PatientChart Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public PatientChart CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
