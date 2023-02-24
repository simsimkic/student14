// File:    BlogArticlesRepository.cs
// Created: Monday, May 18, 2020 7:24:42 PM
// Purpose: Definition of Class BlogArticlesRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryBlog
{
    public class BlogArticlesRepository : IBlogArticleRepository
    {
        private string _path = "blogArticles.json";
        public BlogArticlesRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<BlogArticle>());
            }
        }
        public bool Create(BlogArticle obj)
        {
            List<BlogArticle> articles = GetAll();
            if (Get(obj.Id) == null)
            {
                articles.Add(obj);
                SaveAll(articles);
                return true;
            }
            return false;
        }
        public bool Delete(string id)
        {
            List<BlogArticle> articles = GetAll();
            BlogArticle article = Get(id);
            if (article != null)
            {
                articles.Remove(article);
                SaveAll(articles);
                return true;
            }
            return false;
        }

        public bool Update(BlogArticle obj)
        {
            List<BlogArticle> articles = GetAll();
            BlogArticle foundArticle = Get(obj.Id);
            if (foundArticle != null)
            {
                for (int i = 0; i < articles.Count; i++)
                {
                    if (articles[i].Id.Equals(obj.Id)) articles[i] = obj;
                }
                SaveAll(articles);
                return true;
            }
            return false;
        }

        public BlogArticle Get(string id)
        {
            foreach (BlogArticle article in GetAll())
            {
                if (article.Id.Equals(id)) return article;
            }
            return null;
        }

        public List<BlogArticle> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<BlogArticle>>(jsonString);
            return new List<BlogArticle>();
        }
        public void SaveAll(List<BlogArticle> articles)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, articles);
                }
            }
        }
    }
}