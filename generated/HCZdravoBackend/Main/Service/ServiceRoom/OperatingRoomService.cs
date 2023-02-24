// File:    OperatingRoomService.cs
// Created: Wednesday, May 20, 2020 6:32:33 PM
// Purpose: Definition of Class OperatingRoomService

using System;
using System.Collections.Generic;
using System.Linq;
using Repository.RepositoryRoom;

namespace Service.ServiceRoom
{
    public class OperatingRoomService
    {
        private IOperationRoomRepository _operatingRoomRepo;


        public OperatingRoomService(OperationRoomRepository roomRepository)
        {
            _operatingRoomRepo = roomRepository;
        }

        public bool AddRoom(Room room)
        {
            return this._operatingRoomRepo.Create(room);
        }

        public bool ContainsItem(string roomId, string itemId)
        {
            Room room = _operatingRoomRepo.Get(roomId);
            if (room == null) return false;
            Item item = room.Items.FirstOrDefault(x => x.Id.Equals(itemId));
            if (item == null) return false;
            return true;
        }
        public bool AddOperationToRoom(string operatingRoomId, Operation operation)
        {
            throw new NotImplementedException();
        }

        public Operation removeOperationToRoom(string operatingRoomId, Operation operation)
        {
            throw new NotImplementedException();
        }

        public Operation EditOperationFromRoom(string operationRoomId, Operation operation)
        {
            throw new NotImplementedException();
        }

        public Room GetOperatingRoomById(string operatingRoomId)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllOperationRoom()
            => _operatingRoomRepo.GetAll();

        public bool AddItemToOperationRoom(string operationRoomId, Item item)
        {
            Room room = this._operatingRoomRepo.Get(operationRoomId);
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (it == null)
            {
                room.Items.Add(item);
            }
            else
            {
                it.Count += item.Count;
            }
            return this._operatingRoomRepo.Update(room);
        }

        public List<Item> GetItemsFromOperationRoom(string operationRoomId)
        {
            return this._operatingRoomRepo.Get(operationRoomId).Items;
        }

        public int RemoveItemFromOperationRoom(string operationRoomId, Item item)
        {
            Room room = this._operatingRoomRepo.Get(operationRoomId);
            int Result = -1;
            if (room == null) return -1;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (it == null) return -1;
            if (it.Count - item.Count <= 0)
            {
                room.Items.Remove(it);
                Result = it.Count;
            }
            else
            {
                it.Count -= item.Count;
                Result = item.Count;
            }
            Result = this._operatingRoomRepo.Update(room) ? Result : -1;
            return Result;
        }

        public bool SetOperationRoomItem(string operationRoomId, Item item)
        {
            Room room = this._operatingRoomRepo.Get(operationRoomId);
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (item == null) return false;
            it = item;
            return this._operatingRoomRepo.Update(room);
        }


    }
}