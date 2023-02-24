// File:    IExamRoomRepository.cs
// Created: Wednesday, May 27, 2020 1:52:59 AM
// Purpose: Definition of Interface IExamRoomRepository

using System.Collections.Generic;

namespace Repository.RepositoryRoom
{
    public interface IExamRoomRepository : IRepository<Room>
    {
        bool Create(Room obj);

        bool Delete(string id);

        bool Update(Room obj);

        Room Get(string id);

        List<Room> GetAll();

    }
}