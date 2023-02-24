// File:    RegisteredPatientRepository.cs
// Created: Monday, May 18, 2020 7:53:08 PM
// Purpose: Definition of Class RegisteredPatientRepository


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryPatient
{
    public class RegisteredPatientRepository : IRegisteredPatientRepository
    {
        private string _path = "registeredPatients.json";
        public RegisteredPatientRepository()
        {

        }
        public int CountPatients()
        {
            return GetAll().Count;
        }
        
        public bool Create(RegisteredPatient obj)
        {
            List<RegisteredPatient> registeredPatients = GetAll();
            if (Get(obj.Pin) == null)
            {
                registeredPatients.Add(obj);
                SaveAll(registeredPatients);
                return true;
            }
            return false;
        }

        public bool Update(RegisteredPatient obj)
        {
            List<RegisteredPatient> registeredPatients = GetAll();
            RegisteredPatient foundRegisteredPatient = Get(obj.Pin);
            if (foundRegisteredPatient != null)
            {
                for (int i = 0; i < registeredPatients.Count; i++)
                {
                    if (registeredPatients[i].Pin.Equals(obj.Pin)) registeredPatients[i] = obj;
                }
                SaveAll(registeredPatients);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            List<RegisteredPatient> registeredPatients = GetAll();
            RegisteredPatient registeredPatient = Get(id);
            if (registeredPatient != null)
            {
                registeredPatients.Remove(registeredPatient);
                SaveAll(registeredPatients);
                return true;
            }
            return false;
        }
        public RegisteredPatient Get(string id)
        {   
            foreach (RegisteredPatient registeredPatient in GetAll())
            {
                if (registeredPatient.Pin.Equals(id)) return registeredPatient;
            }
            return null;
        }

        public List<RegisteredPatient> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<RegisteredPatient>>(jsonString);
            return new List<RegisteredPatient>();
        }


        public void SaveAll(List<RegisteredPatient> registeredPatients)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, registeredPatients);
                }
            }
        }
    }
}