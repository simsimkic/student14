// File:    ItemServices.cs
// Created: Thursday, May 21, 2020 4:54:12 PM
// Purpose: Definition of Class ItemServices

using Repository.RepositoryDean;
using Service.ServiceRoom;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Service.ServiceDean
{
    public class ItemServices : IInventoryServices<Item>
    {

        private RecoveryRoomService _recoveryRoomService;
        private OperatingRoomService _operatingRoomService;
        private ExamRoomService _examRoomService;
        private StorageService _storageService;
        private IItemRepository _ItemRepository;

        public ItemServices(RecoveryRoomService rec, OperatingRoomService op, ExamRoomService ex, StorageService sto, ItemRepository rep)
        {
            this._recoveryRoomService = rec;
            this._operatingRoomService = op;
            this._examRoomService = ex;
            this._storageService = sto;
            this._ItemRepository = rep;
        }

        public void Move(Room fromRoom, Room toRoom, Item item)
        {
            // NOTE(Jovan): U slucaju da u polaznoj sobi nema dovoljno item-a
            Item movingItem = new Item(item);
            int Moved = item.Count;

            switch(fromRoom.RoomType)
            {
                case RoomType.EXAMROOM:
                    {
                        if (!this._examRoomService.ContainsItem(fromRoom.Id, item.Id)) return;
                        Moved = this._examRoomService.RemoveItemFromExamRoom(fromRoom.Id, item);
                    } break;
                case RoomType.OPERATINGROOM:
                    {
                        if (!this._operatingRoomService.ContainsItem(fromRoom.Id, item.Id)) return;
                        Moved = this._operatingRoomService.RemoveItemFromOperationRoom(fromRoom.Id, item);
                    }break;
                case RoomType.RECOVERYROOM:
                    {
                        if (!this._recoveryRoomService.ContainsItem(fromRoom.Id, item.Id)) return;
                        Moved = this._recoveryRoomService.RemoveItemFromRecoveryRoom(fromRoom.Id, item);
                    } break;
                case RoomType.STORAGE:
                    {
                        if (!this._storageService.ContainsItem(item.Id)) return;
                        Moved = this._storageService.RemoveItem(item);
                    } break;
            }
            if (Moved == -1) return;
            movingItem.Count = Moved;

            switch(toRoom.RoomType)
            {
                case RoomType.EXAMROOM:
                    {
                        this._examRoomService.AddItemToExamRoom(toRoom.Id, movingItem);
                    }
                    break;
                case RoomType.OPERATINGROOM:
                    {
                        this._operatingRoomService.AddItemToOperationRoom(toRoom.Id, movingItem);
                    }
                    break;
                case RoomType.RECOVERYROOM:
                    {
                        this._recoveryRoomService.AddItemToRecoveryRoom(toRoom.Id, movingItem);
                    }
                    break;
                case RoomType.STORAGE:
                    {
                        this._storageService.AddItem(movingItem);
                    }
                    break;
            }
        }

        public bool Add(Item obj)
        {
            return this._ItemRepository.Create(obj);
        }

        public bool Set(Item obj)
        {
            return this._ItemRepository.Update(obj);
        }

        public List<Item> GetAll()
        {
            return this._ItemRepository.GetAll();
        }

        public Item Get(string id)
        {
            return this._ItemRepository.Get(id);
        }

        public bool Remove(string id)
        {
            return this._ItemRepository.Delete(id);
        }


    }
}