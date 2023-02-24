// File:    QuestionController.cs
// Created: Sunday, May 24, 2020 9:46:09 PM
// Purpose: Definition of Class QuestionController

using Controller.ControllerAppointment;
using Service.ServiceBlog;
using System;
using System.Collections.Generic;

namespace Controller.ControllerBlog
{
    public class QuestionController
    {
        private QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        public bool AskQuestion(Question question)
            => _questionService.AskQuestion(question);


        public Answer AnswerQuestion(Question question, Content answerContent, Doctor doctor)
            => _questionService.AnswerQuestion(question, answerContent, doctor);
        

        public List<Question> GetUnansweredQuestions()
            => _questionService.GetUnansweredQuestions();
        

        public List<Question> GetAllQuestions()
            => _questionService.GetAllQuestions();
        

        public Question GetQuestionById(string id)
            => _questionService.GetQuestionById(id);
        

        public bool RemoveQuestionById(string id)
            => _questionService.RemoveQuestionById(id);
        

        public bool EditQuestion(Question question)
            => _questionService.EditQuestion(question);
        

        public bool EditAnswer(Answer answer)
            => _questionService.EditAnswer(answer);
        

        public bool RemoveAnswer(string answerId)
            => _questionService.RemoveAnswer(answerId);

    }
}