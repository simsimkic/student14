// File:    RegistredPatientAggregate.cs
// Created: Tuesday, June 02, 2020 4:45:10 AM
// Purpose: Definition of Class RegistredPatientAggregate

using System;
using System.Collections.Generic;


public class RegistredPatientAggregate : IAggregate<RegistredPatientIterator>
{
    private List<RegisteredPatient> patients;
    public RegistredPatientAggregate()
    {
        patients = new List<RegisteredPatient>();
    }

    public int Count()
    {
        return patients.Count;
    }

    public RegistredPatientIterator CreateIterator()
    {
        return new RegistredPatientIterator(this);
    }

    public List<RegisteredPatient> getAllElements()
    {
        return patients;
    }

    public RegisteredPatient this[int index]
    {
        get { return patients[index]; }
    }

    public void AddItem(RegisteredPatient registeredPatient)
    {
        patients.Add(registeredPatient);
    }
    public void RemoveItem(RegisteredPatient registeredPatient)
    {
        patients.Remove(registeredPatient);
    }

    public void setList(List<RegisteredPatient> registeredPatients)
    {
        patients = new List<RegisteredPatient>(registeredPatients);
    }


}
