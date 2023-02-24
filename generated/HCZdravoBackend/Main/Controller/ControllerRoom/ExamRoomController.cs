// File:    ExamRoomController.cs
// Created: Thursday, May 28, 2020 10:31:24 AM
// Purpose: Definition of Class ExamRoomController

using System;
using System.Collections.Generic;
using Repository.RepositoryRoom;
using Service.ServiceRoom;

namespace Controller.ControllerRoom
{
    public class ExamRoomController : IRoomController<Examination>
    {
        public ExamRoomService examRoomService;

        public ExamRoomController(ExamRoomService serv)
        {
            examRoomService = serv;
        }
        public Room GetExamRoomById(string examRoomId)
            => examRoomService.GetExamRoomById(examRoomId);
        public bool AddRoom(Room room)
            => examRoomService.AddExamRoom(room);
        public bool EditExamFromRoom(string examRoomId, Examination exam)
            => examRoomService.EditExamFromRoom(examRoomId, exam);

        public bool AddToRoom(string examRoomId, Examination exam)
            => examRoomService.AddExamToRoom(examRoomId, exam);

        public bool RemoveFromRoom(string examRoomId, Examination exam)
            => examRoomService.RemoveExamFromRoom(examRoomId, exam);

        public bool AddItem(string itemId, Item item)
            => examRoomService.AddItemToExamRoom(itemId, item);

        public int RemoveItem(string itemId, Item item)
            => examRoomService.RemoveItemFromExamRoom(itemId, item);

        public List<Item> GetItems(string examRoomId)
            => examRoomService.GetItemsFromExamRoom(examRoomId);

        public Room Get(string id)
        {
            return this.examRoomService.GetExamRoomById(id);
        }

        public List<Room> GetAll()
        {
            return this.examRoomService.GetAll();
        }

    }
}