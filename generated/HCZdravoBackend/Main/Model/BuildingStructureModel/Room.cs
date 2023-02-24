// File:    Room.cs
// Created: Monday, June 01, 2020 4:43:54 PM
// Purpose: Definition of Class Room

using System;
using System.Collections.Generic;
using System.Linq;

public class Room
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Boolean Available { get; set; }
    public RoomType RoomType { get; set; }
    
    public List<Item> Items { get; set; }

    public Room() { }

    public Room(string id) 
    { 
        Id = id;
        Name = null;
        Available = false;
        RoomType = RoomType.EXAMROOM;
        this.Items = new List<Item>();
    }
    public Room(string id, string name, bool available, RoomType roomType)
    {
        Id = id;
        Name = name;
        Available = available;
        RoomType = roomType;
        this.Items = new List<Item>();
    }

    public override string ToString()
    {
        return Id + " " + Name + " " + RoomType.ToString();
    }

    public override bool Equals(object obj)
    {
        return obj is Room room &&
               Id == room.Id;
    }

}
