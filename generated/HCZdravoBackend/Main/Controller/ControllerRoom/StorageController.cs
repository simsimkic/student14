// File:    StorageController.cs
// Created: Thursday, May 28, 2020 10:31:24 AM
// Purpose: Definition of Class StorageController

using Service.ServiceRoom;
using System;
using System.Collections.Generic;

namespace Controller.ControllerRoom
{
    public class StorageController
    {
        private StorageService _storageService;

        public StorageController(StorageService sserv)
        {
            this._storageService = sserv;
        }

        public bool AddItem(Item obj)
        {
            return this._storageService.AddItem(obj);
        }

        public int RemoveItem(Item obj)
        {
            return this._storageService.RemoveItem(obj);
        }

        public Item GetItem(string id)
        {
            return this._storageService.GetItem(id);
        }

        public List<Item> GetItems()
        {
            return this._storageService.GetAllItems();
        }

        public Room Get()
        {
            return this._storageService.Get();
        }

    }
}