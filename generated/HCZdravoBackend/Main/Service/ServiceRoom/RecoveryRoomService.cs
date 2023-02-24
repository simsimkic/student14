// File:    RecoveryRoomService.cs
// Created: Wednesday, May 20, 2020 6:32:33 PM
// Purpose: Definition of Class RecoveryRoomService

using Repository.RepositoryRoom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.ServiceRoom
{
    public class RecoveryRoomService
    {
        private IRecoveryRepository _recoveryRoomRepo;

        public RecoveryRoomService(RecoveryRoomRepository repo)
        {
            this._recoveryRoomRepo = repo;
        }

        public bool ContainsItem(string roomId, string itemId)
        {
            Room room = _recoveryRoomRepo.Get(roomId);
            if (room == null) return false;
            Item item = room.Items.FirstOrDefault(x => x.Id.Equals(itemId));
            if (item == null) return false;
            return true;
        }

        public bool AddRoom(Room room)
        {
            return this._recoveryRoomRepo.Create(room);
        }
        public Person AddPatientToRoom(string recoveryRoomId, Person patient)
        {
            throw new NotImplementedException();
        }

        public Person RemovePatientFromRecoveryRoom(string recoveryRoomId, Person patient)
        {
            throw new NotImplementedException();
        }

        public void AddBedToRecoveryRoom(string recoveryRoomId)
        {
            throw new NotImplementedException();
        }

        public void removeBedToRecoveryRoom(string recoveryRoomId)
        {
            throw new NotImplementedException();
        }

        public Room GetRecoveryRoomById(string recoveryRoomId)
        {
            return this._recoveryRoomRepo.Get(recoveryRoomId);
        }

        public List<Room> GetAll()
        {
            return this._recoveryRoomRepo.GetAll();
        }

        public bool AddItemToRecoveryRoom(string recoveryRoomId, Item item)
        {
            Room room = this._recoveryRoomRepo.Get(recoveryRoomId);
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
            return this._recoveryRoomRepo.Update(room);
        }

        public List<Item> GetItemsFromRecoveryRoom(string recoveryRoomId)
        {
            return this._recoveryRoomRepo.Get(recoveryRoomId).Items;
        }

        public int RemoveItemFromRecoveryRoom(string recoveryRoomId, Item item)
        {
            Room room = this._recoveryRoomRepo.Get(recoveryRoomId);
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
            Result = this._recoveryRoomRepo.Update(room) ? Result : -1;
            return Result;
        }

        public bool SetRecoveryRoomItem(string recoveryRoomId, Item item)
        {
            Room room = this._recoveryRoomRepo.Get(recoveryRoomId);
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (item == null) return false;
            it = item;
            return this._recoveryRoomRepo.Update(room);
        }


    }
}