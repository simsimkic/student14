// File:    BlogArticleService.cs
// Created: Sunday, May 24, 2020 9:24:35 PM
// Purpose: Definition of Class BlogArticleService

using Repository.RepositoryBlog;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Service.ServiceBlog
{
    public class BlogArticleService
    {
        private IBlogArticleRepository _iBlogArticleRepository;
        public BlogArticleService(BlogArticlesRepository blogArticlesRepository)
        {
            _iBlogArticleRepository = blogArticlesRepository;
        }

        public bool NewArticle(BlogArticle article)
            => _iBlogArticleRepository.Create(article);

        public bool EditArticle(BlogArticle article)
            => _iBlogArticleRepository.Update(article);

        public List<BlogArticle> GetAllArticles()
            => _iBlogArticleRepository.GetAll();

        public BlogArticle GetArticleById(string id)
            => _iBlogArticleRepository.Get(id);

        public bool RemoveArticleById(string id)
            => _iBlogArticleRepository.Delete(id);
       
    }
}