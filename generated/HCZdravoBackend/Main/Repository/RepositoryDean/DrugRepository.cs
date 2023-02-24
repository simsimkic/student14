// File:    DrugRepository.cs
// Created: Thursday, May 28, 2020 10:32:09 AM
// Purpose: Definition of Class DrugRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.RepositoryDean
{
    public class DrugRepository : IDrugRepository
    {
        private string _path = "drugs.json";

        public DrugRepository()
        {
            if(!File.Exists(_path))
            {
                SaveAll(new List<Drug>());
            }
        }

        private void SaveAll(List<Drug> Drugs)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, Drugs);
                }
            }
        }
        public bool Create(Drug obj)
        {
            List<Drug> Drugs = GetAll();
            if(!Drugs.Contains(obj))
            {
                Drugs.Add(obj);
                SaveAll(Drugs);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            List<Drug> Drugs = GetAll();
            Drug drug = Drugs.FirstOrDefault(x => x.Id.Equals(id));
            if(drug != null)
            {
                Drugs.Remove(drug);
                SaveAll(Drugs);
                return true;
            }
            return false;
        }

        public bool Update(Drug obj)
        {
            List<Drug> Drugs = GetAll();
            Drug drug = Drugs.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if(drug != null)
            {
                drug = obj;
                SaveAll(Drugs);
                return true;
            }
            return false;
        }

        public Drug Get(string id)
        {
            List<Drug> Drugs = GetAll();
            return Drugs.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Drug> GetAll()
        {
            string json = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if(!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<List<Drug>>(json);
            }
            return new List<Drug>();
        }
    }
}