// File:    RatingsRepository.cs
// Created: Sunday, May 24, 2020 5:38:53 PM
// Purpose: Definition of Class RatingsRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;

namespace Repository.RepositoryPatient
{
    public class RatingsRepository : IRatingsRepository
    {
        private string _path = "ratings.json";

        public bool Create(Rating obj)
        {
            List<Rating> ratings = GetAll();
            if (Get(obj.Id) == null)
            {
                ratings.Add(obj);
                SaveAll(ratings);
                return true;
            }
            return false;
        }
        public bool Update(Rating obj)
        {
            List<Rating> ratings = GetAll();
            Rating foundRating = Get(obj.Id);
            Console.WriteLine(foundRating.Text);
            if (foundRating != null)
            {
                for (int i = 0; i < ratings.Count; i++)
                {
                    if (ratings[i].Id.Equals(obj.Id))
                    {
                        ratings[i] = obj;
                    }
                }
                SaveAll(ratings);
                return true;
            }
            return false;
        }

        public Rating Get(string id)
        {
            List<Rating> ratings = GetAll();
            foreach (Rating rating in ratings)
            {
                if (rating.Id.Equals(id)) return rating;
            }
            return null;
        }

        public List<Rating> GetAllDoctorsRatings(Doctor doctor)
        {
            List<Rating> doctorsRatings = new List<Rating>();
            foreach(Rating rating in GetAll())
            {
                if (rating.Doctor.Equals(doctor)) doctorsRatings.Add(rating);
            }
            return doctorsRatings;
        }

        public List<Rating> GetAllPatientsRatings(RegisteredPatient patient)
        {
            List<Rating> patientsRatings = new List<Rating>();
            foreach (Rating rating in GetAll())
            {
                if (rating.RegisteredPatient.Equals(patient)) patientsRatings.Add(rating);
            }
            return patientsRatings;
        }

        public bool Delete(string id)
        {
            List<Rating> ratings = GetAll();
            Rating rating = Get(id);
            if (rating != null)
            {
                ratings.Remove(rating);
                SaveAll(ratings);
                return true;
            }
            return false;
        }

        public List<Rating> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Rating>>(jsonString);
            return new List<Rating>();
        }
        public void SaveAll(List<Rating> ratings)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, ratings);
                }
            }
        }
    }
}