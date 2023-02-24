// File:    UserService.cs
// Created: Monday, May 18, 2020 2:49:48 PM
// Purpose: Definition of Class UserService

using Main.Repository.RepositoryUser;
using Repository.RepositoryBlog;
using Repository.RepositoryMedicalDocumentation;
using Repository.RepositoryUser;
using System;

namespace Service.ServiceUser
{
    public class UserService
    {
        private IRegisteredUserRepository _iRegisteredUserRepository;
        private IBlogArticleRepository _iBlogArticleRepository;
        private IQuestionsRepository _iQuestionsRepository;
        private IPersonRepository _iPersonRepository;

        public UserService(RegisteredUserRepository registeredUserRepository, BlogArticlesRepository blogArticlesRepository, QuestionsRepository questionsRepository, PersonRepository personRepository)
        {
            _iRegisteredUserRepository = registeredUserRepository;
            _iBlogArticleRepository = blogArticlesRepository;
            _iQuestionsRepository = questionsRepository;
            _iPersonRepository = personRepository;
        }
        public Blog ShowBlog()
        {
            Blog blog = new Blog();
            blog.BlogArticles = _iBlogArticleRepository.GetAll();
            QandA qandA = new QandA(_iQuestionsRepository.GetAll());
            blog.QandA = qandA;
            return blog;
        }
        
        public Account CreateAccount(string username, string password)
        {
            if (_iRegisteredUserRepository.GetRegisteredUserByUsername(username) == null)
            {
                Account account = new Account(username, password);
                return account;
            }
            return null;
        }

        public RegisteredUser CreateRegisteredUser(Account account, Person person)
        {
            RegisteredUser newRegisteredUser = new RegisteredUser(account, person);
            _iRegisteredUserRepository.Create(newRegisteredUser);
            return newRegisteredUser;
        }

        public RegisteredUser CreateRegisteredUserOfKnownPerson(string pin, Account acc)
        {
            Person person = _iPersonRepository.Get(pin);
            Account account = CreateAccount(acc.Username, acc.Password);
            if (person != null && account != null)
            {
                _iPersonRepository.Delete(pin);
                return CreateRegisteredUser(account, person);
            }
            return null;
        }

        public Person GetKnownPerson(string pin)
            => _iPersonRepository.Get(pin);

        public bool AddKnownPerson(Person person)
            => _iPersonRepository.Create(person);
    }
}