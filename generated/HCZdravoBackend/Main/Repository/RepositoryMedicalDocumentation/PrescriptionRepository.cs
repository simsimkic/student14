// File:    PrescriptionRepository.cs
// Created: Thursday, May 21, 2020 8:37:21 PM
// Purpose: Definition of Class PrescriptionRepository


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryMedicalDocumentation
{
    public class PrescriptionRepository : IPerscriptionRepository
    {
        private string _path = "prescriptions.json";

        public PrescriptionRepository() {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Prescription>());
            }
        }

        public bool Create(Prescription obj)
        {
            List<Prescription> prescriptions = GetAll();
            if (Get(obj.Id) == null)
            {
                prescriptions.Add(obj);
                SaveAll(prescriptions);
                return true;
            }
            return false;
        }


        public bool Update(Prescription obj)
        {
            List<Prescription> prescriptions = GetAll();
            Prescription foundPrescription = Get(obj.Id);
            if (foundPrescription != null)
            {
                for (int i = 0; i < prescriptions.Count; i++)
                {
                    if (prescriptions[i].Id.Equals(obj.Id))
                    {
                        prescriptions[i] = obj;
                        SaveAll(prescriptions);
                        return true;
                    }
                }
            }
            return false;
        }

        public Prescription Get(string id)
        {
            List<Prescription> prescriptions = GetAll();
            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Id.Equals(id)) return prescription;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<Prescription> prescriptions = GetAll();
            Prescription prescription = Get(id);
            if (prescription != null)
            {
                prescriptions.Remove(prescription);
                SaveAll(prescriptions);
                return true;
            }
            return false;
        }

        public List<Prescription> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Prescription>>(jsonString);
            return new List<Prescription>();
        }

        public void SaveAll(List<Prescription> prescriptions)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, prescriptions);
                }
            }
        }
    }
}