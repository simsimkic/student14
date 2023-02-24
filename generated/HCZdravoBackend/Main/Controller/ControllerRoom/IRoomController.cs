// File:    IRoomController.cs
// Created: Thursday, May 28, 2020 10:31:24 AM
// Purpose: Definition of Interface IRoomController

using System;
using System.Collections.Generic;

namespace Controller.ControllerRoom
{
    public interface IRoomController<T>
    {
        bool AddToRoom(string id, T obj);

        bool RemoveFromRoom(string id, T obj);

        bool AddItem(string id, Item item);

        int RemoveItem(string id, Item item);

        List<Item> GetItems(string id);

        Room Get(string id);
        List<Room> GetAll();

    }
}