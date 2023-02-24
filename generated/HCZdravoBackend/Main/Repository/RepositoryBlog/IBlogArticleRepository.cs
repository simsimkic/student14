// File:    IBlogArticleRepository.cs
// Created: Wednesday, May 27, 2020 1:11:00 AM
// Purpose: Definition of Interface IBlogArticleRepository

using System.Collections.Generic;

namespace Repository.RepositoryBlog
{
    public interface IBlogArticleRepository : IRepository<BlogArticle>
    {
        bool Create(BlogArticle obj);

        bool Delete(string id);

        bool Update(BlogArticle obj);

        BlogArticle Get(string id);

        List<BlogArticle> GetAll();

        void SaveAll(List<BlogArticle> blogArticles);
    }
}