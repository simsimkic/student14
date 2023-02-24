// File:    ExamRoomService.cs
// Created: Wednesday, May 20, 2020 6:32:33 PM
// Purpose: Definition of Class ExamRoomService

using System;
using System.Linq;
using System.Collections.Generic;
using Repository.RepositoryAppointment;
using Repository.RepositoryDean;
using Repository.RepositoryRoom;

namespace Service.ServiceRoom
{
    public class ExamRoomService
    {
        private IExamRoomRepository _examRoomRepo;

        public bool ContainsItem(string roomId, string itemId)
        {
            Room room = _examRoomRepo.Get(roomId);
            if (room == null) return false;
            Item item = room.Items.FirstOrDefault(x => x.Id.Equals(itemId));
            if (item == null) return false;
            return true;
        }

        public ExamRoomService(ExamRoomRepository repo)
        {
            this._examRoomRepo = repo;
        }
        public bool AddExamToRoom(string examRoomId, Examination exam)
        {
            throw new NotImplementedException();
        }

        public bool RemoveExamFromRoom(string examRoomId, Examination exam)
        {
            throw new NotImplementedException();
        }

        public bool EditExamFromRoom(string examRoomId, Examination exam)
        {
            throw new NotImplementedException();
        }
        public Room GetExamRoomById(string examRoomId)
            => _examRoomRepo.Get(examRoomId);

        public bool AddExamRoom(Room room)
            => _examRoomRepo.Create(room);

        public bool AddItemToExamRoom(string examRoomId, Item item)
        {
            Room room = this._examRoomRepo.Get(examRoomId);
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
            return this._examRoomRepo.Update(room);
        }

        public List<Item> GetItemsFromExamRoom(string examRoomId)
        {
            return this._examRoomRepo.Get(examRoomId).Items;
        }
        
        public int RemoveItemFromExamRoom(string examRoomId, Item item)
        {
            Room room = this._examRoomRepo.Get(examRoomId);
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
            Result = this._examRoomRepo.Update(room) ? Result : -1;
            return Result;
        }

        public bool SetExamRoomItem(string examRoomId, Item item)
        {
            Room room = this._examRoomRepo.Get(examRoomId);
            if (room == null) return false;
            Item it = room.Items.FirstOrDefault(x => x.Id.Equals(item.Id));
            if (item == null) return false;
            it = item;
            return this._examRoomRepo.Update(room);
        }

        public List<Room> GetAll()
        {
            return this._examRoomRepo.GetAll();
        }

    }
}