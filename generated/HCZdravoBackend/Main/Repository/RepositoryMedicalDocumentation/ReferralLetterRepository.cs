// File:    ReferralLetterRepository.cs
// Created: Thursday, May 21, 2020 8:37:22 PM
// Purpose: Definition of Class ReferralLetterRepository


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryMedicalDocumentation
{
    public class ReferralLetterRepository : IReferralLetterRepository
    {
        private string _path = "referralLetters.json";

        public ReferralLetterRepository() {
            if (!File.Exists(_path))
            {
                SaveAll(new List<ReferralLetter>());
            }
        }

        public bool Create(ReferralLetter obj)
        {
            List<ReferralLetter> referralLetters = GetAll();
            if (Get(obj.Id) == null)
            {
                referralLetters.Add(obj);
                SaveAll(referralLetters);
                return true;
            }
            return false;
        }

        public bool Update(ReferralLetter obj)
        {
            List<ReferralLetter> referralLetters = GetAll();
            ReferralLetter foundReferralLetter = Get(obj.Id);
            if (foundReferralLetter != null)
            {
                for (int i = 0; i < referralLetters.Count; i++)
                {
                    if (referralLetters[i].Id.Equals(obj.Id))
                    {
                        referralLetters[i] = obj;
                        SaveAll(referralLetters);
                        return true;
                    }
                }
            }
            return false;
        }

        public ReferralLetter Get(string id)
        {
            List<ReferralLetter> referralLetters = GetAll();
            foreach (ReferralLetter referralLetter in referralLetters)
            {
                if (referralLetter.Id.Equals(id)) return referralLetter;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<ReferralLetter> referralLetters = GetAll();
            ReferralLetter referralLetter = Get(id);
            if (referralLetter != null)
            {
                referralLetters.Remove(referralLetter);
                SaveAll(referralLetters);
                return true;
            }
            return false;
        }

        public List<ReferralLetter> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<ReferralLetter>>(jsonString);
            return new List<ReferralLetter>();
        }

        public void SaveAll(List<ReferralLetter> referralLetters)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, referralLetters);
                }
            }
        }
    }
}