// File:    Drug.cs
// Created: Monday, June 01, 2020 4:57:22 PM
// Purpose: Definition of Class Drug



public class Drug : Item
{
    public string DrugProducer { get; set; }
    public bool Approved { get; set; }
    public Drug() : base()
    {
        this.Approved = false;
    }

    public Drug(string id) : base(id) 
    {
    }
    public Drug(string drugProducer,string id, int count, string name) : base(id,count,name)
    {
        DrugProducer = drugProducer;
    }

    public override string ToString()
    {
        return Id + " " + Count + " " + Name + " " + (Approved ? "ODOBREN" : "NIJE ODOBREN");
    }
}
