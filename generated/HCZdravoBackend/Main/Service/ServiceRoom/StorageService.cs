// File:    StorageService.cs
// Created: Thursday, May 28, 2020 10:18:41 PM
// Purpose: Definition of Class StorageService

using Repository.RepositoryRoom;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Service.ServiceRoom
{
    public class StorageService
    {
        private IStorageRepository _storageRepo;

        public StorageService(StorageRepository repo)
        {
            this._storageRepo = repo;
        }

        public bool ContainsItem(string itemId)
        {
            Room room = this._storageRepo.Get();
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(itemId));
            if (it == null) return false;
            return true;
        }

        public bool AddItem(Item item)
        {
            Room room = this._storageRepo.Get();
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if(it == null)
            {
                room.Items.Add(item);
            }
            else
            {
                it.Count += item.Count;
            }
            return this._storageRepo.Update(room);
        }

        public int RemoveItem(Item item)
        {
            Room room = this._storageRepo.Get();
            int Result = -1;
            if (room == null) return -1;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (it == null) return -1;
            if(it.Count - item.Count <= 0)
            {
                room.Items.Remove(it);
                Result = it.Count;
            }
            else
            {
                it.Count -= item.Count;
                Result = item.Count;
            }
            Result = this._storageRepo.Update(room) ? Result : -1;
            return Result;
        }

        public bool SetItem(Item item)
        {
            Room room = this._storageRepo.Get();
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (it == null) return false;
            it = item;
            return this._storageRepo.Update(room);
        }

        public Item GetItem(string id)
        {
            Room room = this._storageRepo.Get();
            if (room == null) return null;
            return room.Items.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Item> GetAllItems()
        {
            Room room = this._storageRepo.Get();
            if (room == null) return null;
            return room.Items;
        }

        public Room Get()
        {
            return this._storageRepo.Get();
        }


    }
}