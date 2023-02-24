// File:    ItemRepository.cs
// Created: Thursday, May 28, 2020 10:32:09 AM
// Purpose: Definition of Class ItemRepository

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository.RepositoryDean
{
    public class ItemRepository : IItemRepository
    {
        private string _path = "items.json";

        public ItemRepository()
        {
            if(!File.Exists(_path))
            {
                SaveAll(new List<Item>());
            }
        }

        private void SaveAll(List<Item> Items)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, Items);
                }
            }
        }
        public bool Create(Item obj)
        {
            List<Item> Items = GetAll();
            if(!Items.Contains(obj))
            {
                Items.Add(obj);
                SaveAll(Items);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            List<Item> Items = GetAll();
            Item item = Items.FirstOrDefault(x => x.Id.Equals(id));
            if(item != null)
            {
                Items.Remove(item);
                SaveAll(Items);
                return true;
            }
            return false;
        }

        public bool Update(Item obj)
        {
            List<Item> Items = GetAll();
            Item item = Items.FirstOrDefault(x => x.Id.Equals(obj.Id));
            if(item != null)
            {
                item = obj;
                SaveAll(Items);
                return true;
            }
            return false;
        }

        public Item Get(string id)
        {
            List<Item> Items = GetAll();
            return Items.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<Item> GetAll()
        {
            string json = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if(!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<List<Item>>(json);
            }
            return new List<Item>();
        }
    }
}