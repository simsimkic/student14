// File:    QuestionService.cs
// Created: Wednesday, May 20, 2020 10:44:29 PM
// Purpose: Definition of Class QuestionService

using Repository.RepositoryBlog;
using System;
using System.Collections.Generic;

namespace Service.ServiceBlog
{
    public class QuestionService
    {
        private IQuestionsRepository _iQuestionsRepository;
        public QuestionService(QuestionsRepository questionsRepository)
        {
            _iQuestionsRepository = questionsRepository;
        }


        public bool AskQuestion(Question question)
            => _iQuestionsRepository.Create(question);

        public Answer AnswerQuestion(Question question, Content answerContent, Doctor author)
        {
            Answer answer = new Answer(author, answerContent);
            question.Answer = answer;
            question.Answered = true;
            _iQuestionsRepository.Update(question);
            return answer;
        }

        public List<Question> GetUnansweredQuestions()
            => _iQuestionsRepository.GetUnansweredQuestions();

        public List<Question> GetAllQuestions()
            => _iQuestionsRepository.GetAll();

        public Question GetQuestionById(string id)
            => _iQuestionsRepository.Get(id);

        public bool RemoveQuestionById(string id)
            => _iQuestionsRepository.Delete(id);

        public bool EditQuestion(Question question)
            => _iQuestionsRepository.Update(question);

        public bool EditAnswer(Answer answer)
        {
            Question question = _iQuestionsRepository.GetQuestionByAnswer(answer.Id);
            question.Answer = answer;
            return _iQuestionsRepository.Update(question);

        }

        public bool RemoveAnswer(string answerId)
        {
            Question question = _iQuestionsRepository.GetQuestionByAnswer(answerId);
            question.Answer = null;
            return _iQuestionsRepository.Update(question);
        }


    }
}