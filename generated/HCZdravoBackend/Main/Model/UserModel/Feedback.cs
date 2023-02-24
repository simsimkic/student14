using System;

public class Feedback : Content
{
    public RegisteredUser RegisteredUser { get; set; }
    public Feedback() { }
    public Feedback(string id) : base(id) 
    {
        RegisteredUser = null;
    }
    public Feedback(RegisteredUser registeredUser,string id, string text, DateTime dateOfCreation):base(id,text,dateOfCreation)
    {
        RegisteredUser = new RegisteredUser(registeredUser.Pin);
    }

    public override bool Equals(object obj)
    {
        return obj is Feedback feedback &&
               base.Equals(obj) &&
               Id == feedback.Id;
    }
}
