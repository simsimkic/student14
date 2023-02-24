// File:    QuestionsRepository.cs
// Created: Monday, May 18, 2020 7:24:42 PM
// Purpose: Definition of Class QuestionsRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryBlog
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private string _path = "questions.json";

        public QuestionsRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Question>());
            }
        }

        public List<Question> GetUnansweredQuestions()
        {
            List<Question> unansweredQuestions = new List<Question>();
            foreach(Question question in GetAll())
            {
                if (!question.Answered) unansweredQuestions.Add(question);
            }
            return unansweredQuestions;
        }

        public bool Create(Question obj)
        {
            List<Question> questions = GetAll();
            if (Get(obj.Id) == null)
            {
                questions.Add(obj);
                SaveAll(questions);
                return true;
            }
            return false;
        }

        public bool Update(Question obj)
        {
            List<Question> questions = GetAll();
            Question foundQuestion = Get(obj.Id);
            if (foundQuestion != null)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].Id.Equals(obj.Id))
                    {
                        questions[i] = obj;
                        SaveAll(questions);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Delete(string id)
        {
            List<Question> questions = GetAll();
            Question question = Get(id);
            if (question != null)
            {
                questions.Remove(question);
                SaveAll(questions);
                return true;
            }
            return false;
        }
        public Question Get(string id)
        {
            foreach (Question question in GetAll())
            {
                if (question.Id.Equals(id)) return question;
            }
            return null;
        }
        public Question GetQuestionByAnswer(string id)
        {
            foreach (Question question in GetAll())
            {
                if (question.Answer.Id.Equals(id)) return question;
            }
            return null;
        }
        public List<Question> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Question>>(jsonString);
            return new List<Question>();
        }
        public void SaveAll(List<Question> questions)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, questions);
                }
            }
        }
    }
}