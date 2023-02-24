
using System;
using System.Collections.Generic;


public class AppointmentAggregate : IAggregate<AppointmentIterator>
{
    private List<Appointment> appointments;

    public AppointmentAggregate()
    {
        appointments = new List<Appointment>();
    }
    public int Count()
    {
        return appointments.Count;
    }

    public AppointmentIterator CreateIterator()
    {
        return new AppointmentIterator(this);
    }

    public List<Appointment> getAllElements()
    {
        return appointments;
    }

    public Appointment this[int index]
    {
        get { return appointments[index]; }
    }

    public void AddItem(Appointment app)
    {
        appointments.Add(app);
    }
    public void RemoveItem(Appointment app)
    {
        appointments.Remove(app);
    }

    public void setList(List<Appointment> apps)
    {
        appointments = new List<Appointment>(apps);
    }


}


