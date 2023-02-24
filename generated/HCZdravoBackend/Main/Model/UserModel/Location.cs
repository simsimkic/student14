public class Location
{
    public State State { get; set; }
    public City City { get; set; }
    public Address Address { get; set; }

    public Location() {  }

    public Location(State state, City city, Address address)
    {
        State = state;
        City = city;
        Address = address;
    }

}

