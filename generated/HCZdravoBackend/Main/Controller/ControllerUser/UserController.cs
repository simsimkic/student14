// File:    UserController.cs
// Created: Monday, May 18, 2020 2:48:46 PM
// Purpose: Definition of Class UserController

using Service.ServiceUser;

namespace Controller.ControllerUser
{
    public class UserController
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public Blog ShowBlog()
            => _userService.ShowBlog();

        public Account CreateAccount(string username, string password)
            => _userService.CreateAccount(username, password);


        public RegisteredUser SignUp(Account account, Person person)
            => _userService.CreateRegisteredUser(account, person);

        public RegisteredUser CreateRegisteredUserOfKnownPerson(string pin, Account account)
             => _userService.CreateRegisteredUserOfKnownPerson(pin, account);

        public Person GetKnownPerson(string pin)
            => _userService.GetKnownPerson(pin);

        public bool AddKnownPerson(Person person)
            => _userService.AddKnownPerson(person);

    }
}