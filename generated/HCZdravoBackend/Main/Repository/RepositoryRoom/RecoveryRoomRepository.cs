// File:    RecoveryRoomRepository.cs
// Created: Tuesday, May 19, 2020 9:52:08 AM
// Purpose: Definition of Class RecoveryRoomRepository

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Repository.RepositoryRoom
{
    public class RecoveryRoomRepository : IRecoveryRepository
    {
        private string _path = "recoveryroom.json";

        public RecoveryRoomRepository()
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
                foreach (Room room in rooms)
                {
                    if (room.Id.Equals(obj.Id))
                    {
                        rooms[rooms.IndexOf(room)] = obj;
                        SaveAll(rooms);
                        return true;
                    }
                }
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