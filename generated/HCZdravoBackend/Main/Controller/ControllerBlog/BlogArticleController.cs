// File:    BlogArticleController.cs
// Created: Sunday, May 24, 2020 9:45:16 PM
// Purpose: Definition of Class BlogArticleController

using Service.ServiceBlog;
using System;
using System.Collections.Generic;

namespace Controller.ControllerBlog
{
    public class BlogArticleController
    {
        private BlogArticleService _blogArticleService;

        public BlogArticleController(BlogArticleService blogArticleService)
        {
            _blogArticleService = blogArticleService;
        }

        public bool NewArticle(BlogArticle article)
            => _blogArticleService.NewArticle(article);
        

        public bool EditArticle(BlogArticle article)
            => _blogArticleService.EditArticle(article);
        

        public List<BlogArticle> GetAllArticles()
            => _blogArticleService.GetAllArticles();
        

        public BlogArticle GetArticleById(string id)
            => _blogArticleService.GetArticleById(id);
        

        public bool RemoveArticleById(string id)
            => _blogArticleService.RemoveArticleById(id);


    }
}