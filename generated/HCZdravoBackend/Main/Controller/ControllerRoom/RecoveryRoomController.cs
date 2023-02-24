// File:    RecoveryRoomController.cs
// Created: Thursday, May 28, 2020 10:31:24 AM
// Purpose: Definition of Class RecoveryRoomController

using System;
using System.Collections.Generic;
using Service.ServiceRoom;

namespace Controller.ControllerRoom
{
    public class RecoveryRoomController : IRoomController<Person>
    {
        private RecoveryRoomService _recoveryRoomService;

        public RecoveryRoomController(RecoveryRoomService rserv)
        {
            _recoveryRoomService = rserv;
        }

        public bool AddRoom(Room room)
        {
            return this._recoveryRoomService.AddRoom(room);
        }
        public void AddBedToRecoveryRoom(string id)
        {
            throw new NotImplementedException();
        }

        public void removeBedToRecoveryRoom(string id)
        {
            throw new NotImplementedException();
        }

        public bool AddToRoom(string id, Person obj)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromRoom(string id, Person obj)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(string id, Item item)
        {
            return this._recoveryRoomService.AddItemToRecoveryRoom(id, item);
        }

        public int RemoveItem(string id, Item item)
        {
            return this._recoveryRoomService.RemoveItemFromRecoveryRoom(id, item);
        }

        public List<Item> GetItems(string id)
        {
            return this._recoveryRoomService.GetItemsFromRecoveryRoom(id);
        }

        public Room Get(string id)
        {
            return this._recoveryRoomService.GetRecoveryRoomById(id);
        }

        public List<Room> GetAll()
        {
            return this._recoveryRoomService.GetAll();
        }

    }
}