// File:    BlogArticleIterator.cs
// Created: Tuesday, June 02, 2020 6:23:47 PM
// Purpose: Definition of Class BlogArticleIterator

using System;

public class BlogArticleIterator : IIterator<BlogArticle>
{
    private BlogArticleAggregate aggregate;
    int index;

    public BlogArticleIterator(BlogArticleAggregate aggregate)
    {
        this.aggregate = aggregate;
        index = 0;
    }
    public BlogArticle First()
    {
        return aggregate[0];
    }

    public BlogArticle Next()
    {
        return aggregate[++index];
    }

    public bool IsDone()
    {
        return ++index < aggregate.Count();
    }

    public BlogArticle CurrentItem()
    {
        return aggregate[index];
    }

    public void Reset()
    {
        index = -1;
    }

}
