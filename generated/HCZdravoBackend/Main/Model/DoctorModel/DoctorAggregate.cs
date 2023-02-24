// File:    DoctorAggregate.cs
// Created: Tuesday, June 02, 2020 4:42:34 AM
// Purpose: Definition of Class DoctorAggregate

using System;
using System.Collections.Generic;

namespace Model.DoctorModel
{

    public class DoctorAggregate : IAggregate<DoctorIterator>
    {
        private List<Doctor> doctors;

        public DoctorAggregate()
        {
            doctors = new List<Doctor>();
        }

        public DoctorAggregate(List<Doctor> docs)
        {
            doctors = new List<Doctor>(docs);
        }
        public int Count()
        {
            return doctors.Count;
        }

        public DoctorIterator CreateIterator()
        {
            return new DoctorIterator(this);
        }
        
        public List<Doctor> getAllElements()
        {
            return doctors;
        }

        public Doctor this[int index]
        {
            get { return doctors[index]; }
        }

        public void AddItem(Doctor doctor)
        {
            doctors.Add(doctor);
        }
        public void RemoveItem(Doctor doctor)
        {
            doctors.Remove(doctor);
        }

        public void setList(List<Doctor> doc)
        {
            doctors = new List<Doctor>(doc);
        }

    }

}
