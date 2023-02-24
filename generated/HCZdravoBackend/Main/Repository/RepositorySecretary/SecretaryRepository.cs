// File:    SecretaryRepository.cs
// Created: Friday, May 29, 2020 3:34:28 AM
// Purpose: Definition of Class SecretaryRepository

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Repository.RepositorySecretary
{
    public class SecretaryRepository : ISecretaryRepository
    {
        private string _path = "secretary.json";

        public SecretaryRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Secretary>());
            }
        }
        public bool Create(Secretary obj)
        {
            if (Get(obj.Pin) == null)
            {
                List<Secretary> secretaries = GetAll();
                secretaries.Add(obj);
                SaveAll(secretaries);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            Secretary secretary = Get(id);
            if (secretary != null)
            {
                List<Secretary> secretaries = GetAll();
                secretaries.Remove(secretary);
                SaveAll(secretaries);
                return true;
            }
            return false;
        }

        public bool Update(Secretary obj)
        {
            if (Get(obj.Pin) != null)
            {
                List<Secretary> secretaries = GetAll();
                foreach (Secretary secretary in secretaries)
                {
                    if (secretary.Pin.Equals(obj.Pin))
                    {
                        secretaries[secretaries.IndexOf(secretary)] = obj;
                        SaveAll(secretaries);
                        return true;
                    }
                }
            }
            return false;
        }

        public Secretary Get(string id)
        {
            List<Secretary> secretaries = GetAll();
            foreach (Secretary secretary in secretaries)
                if (secretary.Pin.Equals(id)) return secretary;
            return null;
        }

        public List<Secretary> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Secretary>>(jsonString);
            return new List<Secretary>();
        }
        public void SaveAll(List<Secretary> secretaries)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, secretaries);
                }
            }
        }


    }
}