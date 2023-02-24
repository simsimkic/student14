// File:    TherapyRepository.cs
// Created: Thursday, May 21, 2020 8:37:22 PM
// Purpose: Definition of Class TherapyRepository


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryMedicalDocumentation
{
    public class TherapyRepository : ITherapyRepository
    {
        private string _path = "therapies.json";

        public TherapyRepository() {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Therapy>());
            }
        }

        public bool Create(Therapy obj)
        {
            List<Therapy> therapies = GetAll();
            if (Get(obj.Id) == null)
            {
                therapies.Add(obj);
                SaveAll(therapies);
                return true;
            }
            return false;
        }

        public bool Update(Therapy obj)
        {
            List<Therapy> therapies = GetAll();
            Therapy foundTherapy = Get(obj.Id);
            if (foundTherapy != null)
            {
                for (int i = 0; i < therapies.Count; i++)
                {
                    if (therapies[i].Id.Equals(obj.Id))
                    {
                        therapies[i] = obj;
                        SaveAll(therapies);
                        return true;
                    }
                }
            }
            return false;
        }

        public Therapy Get(string id)
        {
            List<Therapy> therapies = GetAll();
            foreach (Therapy therapy in therapies)
            {
                if (therapy.Id.Equals(id)) return therapy;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<Therapy> therapies = GetAll();
            Therapy therapy = Get(id);
            if (therapy != null)
            {
                therapies.Remove(therapy);
                SaveAll(therapies);
                return true;
            }
            return false;
        }

        public List<Therapy> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Therapy>>(jsonString);
            return new List<Therapy>();
        }

        public void SaveAll(List<Therapy> therapies)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, therapies);
                }
            }
        }
    }
}