// File:    DoctorRepository.cs
// Created: Thursday, May 21, 2020 9:23:01 PM
// Purpose: Definition of Class DoctorRepository

using Model.DoctorModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryDoctor
{
    public class DoctorRepository : IDoctorRepository
    {
        private string _path = "doctors.json";

        public DoctorRepository() { }

        public bool Create(Doctor obj)
        {
            List<Doctor> doctors = GetAll();
            if (Get(obj.Pin) == null)
            {
                doctors.Add(obj);
                SaveAll(doctors);
                return true;
            }
            return false;
        }

        public bool Update(Doctor obj)
        {
            List<Doctor> doctors = GetAll();
            Doctor foundDoctor = Get(obj.Pin);
            if (foundDoctor != null)
            {
                for (int i = 0; i < doctors.Count; i++)
                {
                    if (doctors[i].Pin.Equals(obj.Pin))
                    {
                        doctors[i] = obj;
                        SaveAll(doctors);
                        return true;
                    }
                }
            }
            return false;
        }

        public Doctor Get(string id)
        {
            List<Doctor> doctors = GetAll();
            foreach (Doctor doctor in doctors)
            {
                if (doctor.Pin.Equals(id)) return doctor;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<Doctor> doctors = GetAll();
            Doctor doctor = Get(id);
            if (doctor != null)
            {
                doctors.Remove(doctor);
                SaveAll(doctors);
                return true;
            }
            return false;
        }

        public List<Doctor> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Doctor>>(jsonString);
            return new List<Doctor>();
        }

        public void SaveAll(List<Doctor> doctors)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, doctors);
                }
            }
        }
    }
}