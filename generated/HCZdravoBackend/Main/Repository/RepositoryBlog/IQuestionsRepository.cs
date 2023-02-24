// File:    IQuestionsRepository.cs
// Created: Wednesday, May 27, 2020 1:11:24 AM
// Purpose: Definition of Interface IQuestionsRepository

using System.Collections.Generic;

namespace Repository.RepositoryBlog
{
    public interface IQuestionsRepository : IRepository<Question>
    {
        List<Question> GetUnansweredQuestions();

        bool Create(Question obj);

        bool Delete(string id);

        bool Update(Question obj);

        Question Get(string id);

        List<Question> GetAll();

        Question GetQuestionByAnswer(string id);

        void SaveAll(List<Question> questions);
    }
}