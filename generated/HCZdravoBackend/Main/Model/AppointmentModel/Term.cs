// File:    Term.cs
// Created: Monday, June 01, 2020 4:38:30 PM
// Purpose: Definition of Class Term

using System;


public class Term
{ 
    public DateTime Start { get; set; }
    public  DateTime End { get; set; }
    public Term(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    public override bool Equals(object obj)
    {
        return obj is Term term &&
               Start == term.Start &&
               End == term.End;
    }
}
