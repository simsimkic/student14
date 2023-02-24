// File:    OperationRoomController.cs
// Created: Thursday, May 28, 2020 10:31:24 AM
// Purpose: Definition of Class OperationRoomController

using System;
using System.Collections.Generic;
using Service.ServiceRoom;

namespace Controller.ControllerRoom
{
    public class OperationRoomController : IRoomController<Operation>
    {
        private OperatingRoomService _operatingRoomService;

        public OperationRoomController(OperatingRoomService roomService)
        {
            _operatingRoomService = roomService;
        }

        public bool AddRoom(Room room)
        {
            return this._operatingRoomService.AddRoom(room);
        }

        public bool AddToRoom(string id, Operation obj)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFromRoom(string id, Operation obj)
        {
            throw new NotImplementedException();
        }

        public bool AddItem(string id, Item item)
        {
            return this._operatingRoomService.AddItemToOperationRoom(id, item);
        }

        public int RemoveItem(string id, Item item)
        {
            return this._operatingRoomService.RemoveItemFromOperationRoom(id, item);
        }

        public List<Item> GetItems(string id)
        {
            return this._operatingRoomService.GetItemsFromOperationRoom(id);
        }

        public List<Room> GetAll()
            => _operatingRoomService.GetAllOperationRoom();

        public Room Get(string id)
        {
            return this._operatingRoomService.GetOperatingRoomById(id);
        }

    }
}