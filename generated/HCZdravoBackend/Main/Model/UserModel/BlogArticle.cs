// File:    BlogArticle.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class BlogArticle

using System;

public class BlogArticle : Content
{
    public string Title { get; set; }
    public Doctor Doctor { get; set; }
    public BlogArticle() { }
    public BlogArticle(string blogId) : base(blogId) 
    {
        Doctor = null;
        Title = null;
    }

    public BlogArticle(string title, Doctor doctor, string id, string text, DateTime date) : base(id, text, date)
    {
        Title = title;
        Doctor = new Doctor(doctor.Pin);
    }
}
