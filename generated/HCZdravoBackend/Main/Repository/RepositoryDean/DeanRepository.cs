// File:    DeanRepository.cs
// Created: Thursday, May 28, 2020 7:08:47 PM
// Purpose: Definition of Class DeanRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.RepositoryDean
{
    public class DeanRepository : IDeanRepository
    {
        private string _path = "dean.json";

        public DeanRepository()
        {
            if(!File.Exists(_path))
            {
                Save(new Dean("d"));
            }
        }

        private void Save(Dean dean)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, dean);
                }
            }
        }

        public bool Create(Dean obj)
        {
            Dean dean= Get();
            if (dean == null)
            {
                Save(obj);
                return true;
            }
            return false;
        }

        public bool Update(Dean obj)
        {
            Dean dean = Get();
            if(dean != null)
            {
                dean = obj;
                Save(dean);
                return true;
            }
            return false;
        }

        public Dean Get()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString))
            {
                Dean dean = JsonConvert.DeserializeObject<Dean>(jsonString);
                return dean;
            }
            return new Dean("d");
        }

        public bool Delete()
        {
            Dean dean = Get();
            if(dean != null)
            {
                Save(new Dean("d"));
                return true;
            }
            return false;
        }
    }
}