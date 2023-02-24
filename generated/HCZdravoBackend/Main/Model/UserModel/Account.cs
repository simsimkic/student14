// File:    Account.cs
// Created: Monday, June 01, 2020 5:07:39 PM
// Purpose: Definition of Class Account

public class Account
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Account() 
    {
        Username = null;
        Password = null;
    }

    public Account(string username, string password)
    {
        Username = username;
        Password = password;
    }

}
