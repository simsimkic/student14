// File:    Content.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Content

using System;


public class Content
{
    public string Id { get; set; }
    public string Text { get; set; }
    public DateTime DateOfCreation { get; set; }
    public Content() { }
    public Content(string id) 
    { 
        Id = id;
        Text = null;
        DateOfCreation = DateTime.MinValue;
    }
    public Content(string id, string text, DateTime dateOfCreation)
    {
        Id = id;
        Text = text;
        DateOfCreation = dateOfCreation;
    }
    public Content(Content content)
    {
        Id = content.Id;
        Text = content.Text;
        DateOfCreation = content.DateOfCreation;
    }
    public override bool Equals(object obj)
    {
        return obj is Content content &&
               Id == content.Id;
    }
}
