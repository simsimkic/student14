// File:    RegisteredUserController.cs
// Created: Monday, May 18, 2020 2:48:46 PM
// Purpose: Definition of Class RegisteredUserController

using Service.ServiceUser;
using System;
using System.Collections.Generic;

namespace Controller.ControllerUser
{
    public class RegisteredUserController
    {
        private RegisteredUserService registeredUserService;

        public RegisteredUserController(RegisteredUserService registeredUserService)
        {
            this.registeredUserService = registeredUserService;
        }

        public RegisteredUser Login(Account account)
            => registeredUserService.Login(account);
        public bool PostFeedback(Feedback feedback)
            => registeredUserService.PostFeedback(feedback);
        public Feedback GetFeedback(string id)
            => registeredUserService.GetFeedback(id);
        public bool ChangePassword(string newPassword, RegisteredUser registeredUser)
            => registeredUserService.ChangePassword(newPassword, registeredUser);

        public RegisteredUser GetRegisteredUserByUsername(string username)
            => registeredUserService.GetRegisteredUserByUsername(username);

        public List<RegisteredUser> GetAll()
            => registeredUserService.GetAll();

        public List<Feedback> GetFeedbacks()
            => registeredUserService.GetFeedbacks();
        public RegisteredUser Get(string id)
            => registeredUserService.Get(id);

    }
}