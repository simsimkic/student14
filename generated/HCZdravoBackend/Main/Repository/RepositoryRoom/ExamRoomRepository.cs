// File:    ExamRoomRepository.cs
// Created: Saturday, May 23, 2020 8:02:41 AM
// Purpose: Definition of Class ExamRoomRepository

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Repository.RepositoryRoom
{
    public class ExamRoomRepository : IExamRoomRepository
    {
        private string _path = "examroom.json";

        public ExamRoomRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Room>());
            }
        }
        public bool Create(Room obj)
        {
            List<Room> rooms = GetAll();
            if (Get(obj.Id) == null)
            {
                rooms.Add(obj);
                SaveAll(rooms);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            Room room = Get(id);
            if (room != null)
            {
                List<Room> rooms = GetAll();
                rooms.Remove(room);
                SaveAll(rooms);
                return true;
            }
            return false;
        }

        public bool Update(Room obj)
        {
            if (Get(obj.Id) != null)
            {
                List<Room> rooms = GetAll();
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].Equals(obj)) rooms[i] = obj;
                }
                SaveAll(rooms);
                return true;
            }
            return false;
        }

        public Room Get(string id)
        {
            List<Room> rooms = GetAll();
            foreach (Room room in rooms)
                if (room.Id.Equals(id)) return room;
            return null;
        }

        public List<Room> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Room>>(jsonString);
            return new List<Room>();
        }
        public void SaveAll(List<Room> rooms)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, rooms);
                }
            }
        }

    }
}