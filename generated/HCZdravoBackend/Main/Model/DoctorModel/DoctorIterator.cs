using System;
using Model.DoctorModel;

public class DoctorIterator : IIterator<Doctor>
{
    private DoctorAggregate aggregate;
    int index;

    public DoctorIterator(DoctorAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = -1;
    }
    public Doctor First()
    {
        return aggregate[0];
    }

    public Doctor Next()
    {
        return aggregate[++index];
    }

    public Doctor GetItem(int i)
    {
        if(i < aggregate.Count() && i > -1) return aggregate[i];
        return null;
    }


    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public Doctor CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}


