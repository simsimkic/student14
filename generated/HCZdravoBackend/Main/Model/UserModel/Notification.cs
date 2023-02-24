// File:    Notification.cs
// Created: Monday, June 01, 2020 5:44:22 PM
// Purpose: Definition of Class Notification



using System;

public class Notification : Content
{
    public RegisteredUser RegisteredUser { get; set; }
    public NotificationType IsEmergencyAppointment { get; set; }
    public Notification() { }
    public Notification(string id) : base(id) 
    {
        RegisteredUser = null;
        IsEmergencyAppointment = NotificationType.NONE;
    }
    public Notification(RegisteredUser registeredUser, string id, string text, DateTime date) : base(id, text, date)
    {
        RegisteredUser = new RegisteredUser(registeredUser.Pin);
        IsEmergencyAppointment = NotificationType.NONE;
    }

    public Notification(string regUserPin, string id, string text, DateTime date, NotificationType isEmergency) : base(id, text, date)
    {
        RegisteredUser = new RegisteredUser(regUserPin);
        IsEmergencyAppointment = isEmergency;
    }

    public override bool Equals(object obj)
    {
        return obj is Notification notification &&
               base.Equals(obj) &&
               Id == notification.Id;
    }
}
