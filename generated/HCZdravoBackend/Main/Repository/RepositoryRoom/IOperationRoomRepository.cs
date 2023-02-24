// File:    IOperationRoomRepository.cs
// Created: Wednesday, May 27, 2020 1:53:54 AM
// Purpose: Definition of Interface IOperationRoomRepository

using Repository;
using System.Collections.Generic;

    public interface IOperationRoomRepository : IRepository<Room>
    {
        bool Create(Room obj);

        bool Delete(string id);

        bool Update(Room obj);

    Room Get(string id);

        List<Room> GetAll();
    }
