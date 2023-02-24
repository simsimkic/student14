
public class Rating
{
    public string Id { get; set; }
    public RatingValue Rate { get; set; }
    public string Text { get; set; }
    public Doctor Doctor { get; set; }
    public RegisteredPatient RegisteredPatient { get; set; }
    public Rating() { }
    public Rating(string id)
    {
        Id = id;
        Rate = RatingValue.one;
        Text = null;
        Doctor = null;
        RegisteredPatient = null;
    }

    public Rating(string id,RatingValue rate, string text, Doctor doctor, RegisteredPatient registeredPatient)
    {
        Id = id;
        Rate = rate;
        Text = text;
        Doctor = new Doctor(doctor.Pin);
        RegisteredPatient = new RegisteredPatient(registeredPatient.Pin);
    }

    public override bool Equals(object obj)
    {
        return obj is Rating rating &&
               Id == rating.Id;
    }

}
