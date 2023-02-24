using System;

public class Appointment
{
    public bool Priority { get; set; }
    public string Id { get; set; }
    public AppointmentType Type { get; set; }

    public RegisteredPatient RegisteredPatient { get; set; }
    public Term Term { get; set; }

    public Doctor Doctor { get; set; }
    public DateTime Date { get; set; }

    public Appointment() { }

    public Appointment(string id) 
    {
        Id = id;
        Priority = false;
        Type = AppointmentType.EXAMINATION;
        RegisteredPatient = null;
        Term = null;
        Doctor = null;
        Date = DateTime.MinValue;
    }
    public Appointment(Appointment appointment)
    {
        Priority = appointment.Priority;
        Id = appointment.Id;
        Type = appointment.Type;
        RegisteredPatient = new RegisteredPatient(appointment.RegisteredPatient.Pin);
        Term = appointment.Term;
        Doctor = new Doctor(appointment.Doctor.Pin);
        Date = appointment.Date;
    }
    public Appointment(bool priority, string id, AppointmentType type, RegisteredPatient registeredPatient, Term term, Doctor doctor, DateTime date)
    {
        Priority = priority;
        Id = id;
        Type = type;
        RegisteredPatient = new RegisteredPatient(registeredPatient.Pin);
        Term = term;
        Doctor = new Doctor(doctor.Pin);
        Date = date;
    }

    public override bool Equals(object obj)
    {
        return obj is Appointment app &&
               Id == app.Id;
    }

}



