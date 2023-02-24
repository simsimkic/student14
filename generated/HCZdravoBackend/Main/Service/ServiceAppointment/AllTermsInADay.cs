// File:    AllTermsInADay.cs
// Created: Sunday, May 24, 2020 1:51:43 PM
// Purpose: Definition of Class AllTermsInADay

using System;
using System.Collections.Generic;

namespace Service.ServiceAppointment
{
    public class AllTermsInADay
    {
        public static int MAX_SHIFTS_IN_DAY = 23;
        public List<Term> Term { get; set; }

        public AllTermsInADay() {
            Term = new List<Term>();

            DateTime startTerm = DateTime.Today.AddHours(7).AddMinutes(0);
            DateTime endTerm = startTerm.AddMinutes(30);
            AddTerms(startTerm, endTerm);
        }

        public AllTermsInADay(DateTime date)
        {
            Term = new List<Term>();

            DateTime startTerm = date.AddHours(7).AddMinutes(0);
            DateTime endTerm = startTerm.AddMinutes(30);
            AddTerms(startTerm, endTerm);
        }

        public void AddTerms(DateTime startTerm, DateTime endTerm)
        {
            Term.Add(new Term(startTerm, endTerm));
            for (int i = 0; i < MAX_SHIFTS_IN_DAY; i++)
            {
                startTerm = startTerm.AddMinutes(30);
                endTerm = endTerm.AddMinutes(30);
                Term.Add(new Term(startTerm, endTerm));
            }

        }
        public List<Term> getTermsForTimePeriod(DateTime startTerm, DateTime endTerm) {
            List<Term> terms = new List<Term>();

            while(startTerm < endTerm) { 
                terms.Add(new Term(startTerm, endTerm));
                startTerm = startTerm.AddMinutes(30);
                endTerm = endTerm.AddMinutes(30);
            }

            return terms;
        }

    }
}