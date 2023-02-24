// File:    Allergy.cs
// Created: Monday, June 01, 2020 5:00:35 PM
// Purpose: Definition of Class Allergy



public class Allergy
{
    public string Name { get; set; }
    public string Id { get; set; }

    public Allergy() { }
    public Allergy(string id)
    {
        Id = id;
        Name = null;
    }
    public Allergy(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
