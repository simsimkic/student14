// File:    QandA.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class QandA

using System.Collections.Generic;


public class QandA
{
    public int NumbeOfQuestions { get; set; }

    public List<Question> Questions { get; set; }

    public QandA() 
    {
        NumbeOfQuestions = 0;
        Questions = new List<Question>();
    }
    public QandA(List<Question> questions)
    {
        NumbeOfQuestions = questions.Count;
        Questions = questions;
    }

}
