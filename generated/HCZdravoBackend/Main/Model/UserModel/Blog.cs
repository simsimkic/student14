// File:    Blog.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Blog

using System.Collections.Generic;
using System;
using Controller.ControllerBlog;

public class Blog
{
    public List<BlogArticle> BlogArticles { get; set; }
    public QandA QandA { get; set; }
    public Blog() 
    {
        BlogArticles = new List<BlogArticle>();
        QandA = new QandA();
    }

    public Blog(List<BlogArticle> blogArticles, QandA qandA)
    {
        BlogArticles = blogArticles;
        QandA = qandA;
    }

    public void printBlog()
    {
        foreach(BlogArticle blogArticle in BlogArticles)
        {
            Console.WriteLine(blogArticle.Title);
            Console.WriteLine(blogArticle.Id);
            Console.WriteLine(blogArticle.Text);
            Console.WriteLine("autor:" + blogArticle.Doctor.Name);
            Console.WriteLine("-------------------");
        }
    }

    public void printQA()
    {
        //QuestionController qCntr = new QuestionController(new Service.ServiceBlog.QuestionService(new Repository.RepositoryBlog.QuestionsRepository()));

        foreach (Question question in QandA.Questions)
        {
            Console.WriteLine(question.Title);
            //Console.WriteLine(question.Id);
            Console.WriteLine(question.Text);
            //Console.WriteLine("autor" + question.RegisteredPatient.Name);
            //Console.WriteLine(question.Answered.ToString());
            if (question.Answered)
            {
                Console.WriteLine("odgovor: "+question.Answer.Text);
            }
            Console.WriteLine("-------------------");

        }
    }

}
