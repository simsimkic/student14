// File:    BlogArticleAggregate.cs
// Created: Tuesday, June 02, 2020 6:23:47 PM
// Purpose: Definition of Class BlogArticleAggregate

using System;
using System.Collections.Generic;


public class BlogArticleAggregate : IAggregate<BlogArticleIterator>
{
    private List<BlogArticle> blogArticles;

    public BlogArticleAggregate()
    {
        blogArticles = new List<BlogArticle>();
    }
    public int Count()
    {
       return blogArticles.Count;
    }

    public BlogArticleIterator CreateIterator()
    {
        return new BlogArticleIterator(this);
    }


    public List<BlogArticle> getAllElements()
    {
        return blogArticles;
    }

    public BlogArticle this[int index]
    {
        get { return blogArticles[index]; }
    }

    public void AddItem(BlogArticle article)
    {
        blogArticles.Add(article);
    }
    public void RemoveItem(BlogArticle article)
    {
        blogArticles.Remove(article);
    }

    public void setList(List<BlogArticle> articles)
    {
        blogArticles = new List<BlogArticle>(articles);
    }

}
