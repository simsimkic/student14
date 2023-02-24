// File:    StorageRepository.cs
// Created: Thursday, May 28, 2020 10:23:37 PM
// Purpose: Definition of Class StorageRepository

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Repository.RepositoryDean;

namespace Repository.RepositoryRoom
{
    public class StorageRepository : IStorageRepository
    {
        private string _path = "storage.json";
        private IItemRepository _itemRepo;
        private IDrugRepository _drugRepo;

        public StorageRepository(ItemRepository irepo, DrugRepository drepo)
        {
            this._itemRepo = irepo;
            this._drugRepo = drepo;
            if (!File.Exists(_path))
            {
                Room storage = new Room("st", "Skladište", true, RoomType.STORAGE);
                Create(storage);
            }
        }

        private void Write(Room obj)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, obj);
                }
            }
        }

        public bool Create(Room obj)
        {
            if(Get() == null)
            {
                Write(obj);
                return true;
            }
            return false;
        }

        public bool Delete()
        {
            Room storage = new Room("st");
            Write(storage);
            return true;
        }

        public bool Update(Room obj)
        {
            Room storage = Get();
            storage = obj;
            Write(storage);
            return true;
        }

        public Room Get()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString))
            {
                Room storage = JsonConvert.DeserializeObject<Room>(jsonString);
                List<Item> newItems = new List<Item>();
                foreach(Item item in storage.Items)
                {
                    Item it = this._itemRepo.GetAll().FirstOrDefault(x => x.Id.Equals(item.Id));
                    if(it != null)
                    {
                        newItems.Add(it);
                    }
                    else
                    {
                        it = this._drugRepo.GetAll().FirstOrDefault(x => x.Id.Equals(item.Id));
                        if (it == null) continue;
                        newItems.Add(it);
                    }
                }
                return storage;
            }
            return null;
        }
    }
}