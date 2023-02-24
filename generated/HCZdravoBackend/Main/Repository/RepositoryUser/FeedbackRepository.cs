// File:    FeedbackRepository.cs
// Created: Monday, May 18, 2020 7:31:35 PM
// Purpose: Definition of Class FeedbackRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryUser
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private string _path = "feedbacks.json";

        public FeedbackRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Feedback>());
            }
        }

        public bool Create(Feedback obj)
        {
            List<Feedback> feedbacks = GetAll();
            if (Get(obj.Id) == null)
            {
                feedbacks.Add(obj);
                SaveAll(feedbacks);
                return true;
            }
            return false;
        }

        public bool Update(Feedback obj)
        {
            List<Feedback> feedbacks = GetAll();
            Feedback foundFeedback = Get(obj.Id);
            if (foundFeedback != null)
            {
                for(int i=0;i<feedbacks.Count;i++)
                {
                    if (feedbacks[i].Id.Equals(obj.Id)) feedbacks[i] = obj;
                }
                SaveAll(feedbacks);
                return true;
            }
            return false;
        }
        public bool Delete(string id)
        {
            List<Feedback> feedbacks = GetAll();
            Feedback feedback = Get(id);
            if (feedback != null)
            {
                feedbacks.Remove(feedback);
                SaveAll(feedbacks);
                return true;
            }
            return false;
        }

        public Feedback Get(string id)
        {
            List<Feedback> feedbacks = GetAll();
            foreach(Feedback feedback in feedbacks)
            {
                if (feedback.Id.Equals(id)) return feedback;
            }
            return null;
        }
        public List<Feedback> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Feedback>>(jsonString);
            return new List<Feedback>();
        }

        public List<Feedback> GetAllUsersFeedbacks(string userId)
        {
            List<Feedback> allFeedbacks = GetAll();
            List<Feedback> usersFeedbacks = new List<Feedback>();
            foreach(Feedback userFeedback in allFeedbacks)
            {
                if (userFeedback.RegisteredUser.Pin.Equals(userId)) usersFeedbacks.Add(userFeedback);
            }
            return usersFeedbacks;
        }
        

        

        public void SaveAll(List<Feedback> feedbacks)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using(StreamWriter writer = new StreamWriter(_path)){
                using (JsonWriter jwriter = new JsonTextWriter(writer)){
                    serializer.Serialize(jwriter, feedbacks);
                }
            }
        }
    }
}