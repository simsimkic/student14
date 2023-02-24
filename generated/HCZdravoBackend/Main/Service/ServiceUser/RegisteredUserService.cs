// File:    RegisteredUserService.cs
// Created: Monday, May 18, 2020 2:49:48 PM
// Purpose: Definition of Class RegisteredUserService

using Repository.RepositoryUser;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Service.ServiceUser
{
    public class RegisteredUserService
    {
        private IRegisteredUserRepository _iRegisteredUserRepository;
        private IFeedbackRepository _iFeedbackRepository;

        public RegisteredUserService(RegisteredUserRepository registeredUserRepository, FeedbackRepository feedbackRepository)
        {
            _iRegisteredUserRepository = registeredUserRepository;
            _iFeedbackRepository = feedbackRepository;
        }

        public RegisteredUser Login(Account account)
        {
            RegisteredUser registeredUser = _iRegisteredUserRepository.GetRegisteredUserByUsername(account.Username);
            return registeredUser.Account.Password.Equals(account.Password) ? registeredUser : null;
        }
        public RegisteredUser Get(string id)
            => _iRegisteredUserRepository.Get(id);

        public Feedback GetFeedback(string id)
            => _iFeedbackRepository.Get(id);
        public bool PostFeedback(Feedback feedback)
            => _iFeedbackRepository.Create(feedback);

        public RegisteredUser GetRegisteredUserByUsername(string username)
            => _iRegisteredUserRepository.GetRegisteredUserByUsername(username);

        public bool ChangePassword(string newPassword, RegisteredUser registeredUser)
        {
            registeredUser.Account.Password = newPassword;
            return _iRegisteredUserRepository.Update(registeredUser);
        }

        public List<RegisteredUser> GetAll()
            => _iRegisteredUserRepository.GetAll();

        public List<Feedback> GetFeedbacks()
            => _iFeedbackRepository.GetAll();
 
    }
}