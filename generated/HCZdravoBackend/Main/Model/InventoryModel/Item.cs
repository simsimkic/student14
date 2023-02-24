// File:    Item.cs
// Created: Monday, June 01, 2020 4:57:22 PM
// Purpose: Definition of Class Item



public class Item
{

    public string Id { get; set; }
    public int Count { get; set; }
    public string Name { get; set; }

    public Item() { }
    public Item(string id) 
    {
        Id = id;
        Count = 0;
        Name = null;
    }
    public Item(string id, int count, string name)
    {
        Id = id;
        Count = count;
        Name = name;
    }

    public Item(Item item)
    {
        this.Id = item.Id;
        this.Count = item.Count;
        this.Name = item.Name;
    }

    public override string ToString()
    {
        return this.Id + " " + this.Count.ToString() + " " + this.Name;
    }

}
