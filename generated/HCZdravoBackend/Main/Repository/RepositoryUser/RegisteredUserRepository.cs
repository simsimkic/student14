// File:    RegisteredUserRepository.cs
// Created: Monday, May 18, 2020 7:31:35 PM
// Purpose: Definition of Class RegisteredUserRepository

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Repository.RepositoryUser
{
    public class RegisteredUserRepository : IRegisteredUserRepository
    {
        private string _path = "registeredUsers.json";
        public RegisteredUserRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<RegisteredUser>());
            }
        }
        public bool Create(RegisteredUser obj)
        {
            List<RegisteredUser> registeredUsers = GetAll();
            if (Get(obj.Pin) == null)
            {
                registeredUsers.Add(obj);
                SaveAll(registeredUsers);
                return true;
            }
            return false;
            
        }

        public bool Update(RegisteredUser obj)
        {
            List<RegisteredUser> registeredUsers = GetAll();
            RegisteredUser foundRegisteredUser = Get(obj.Pin);
            if (foundRegisteredUser != null)
            {
                for (int i = 0; i < registeredUsers.Count; i++)
                {
                    if (registeredUsers[i].Pin.Equals(obj.Pin)) registeredUsers[i] = obj;
                }
                SaveAll(registeredUsers);
                return true;
            }
            return false;
        }

        public RegisteredUser Get(string id)
        {
            List<RegisteredUser> registeredUsers = GetAll();
            foreach (RegisteredUser registeredUser in registeredUsers)
            {
                if (registeredUser.Pin.Equals(id)) return registeredUser;
            }
            return null;
        }

        public RegisteredUser GetRegisteredUserByUsername(string username)
        {
            foreach(RegisteredUser registeredUser in GetAll())
            {
                if (registeredUser.Account.Username.Equals(username)) return registeredUser;
            }
            return null;
        }

        public bool Delete(string id)
        {
            List<RegisteredUser> registeredUsers = GetAll();
            RegisteredUser registeredUser = Get(id);
            if (registeredUser != null)
            {
                registeredUsers.Remove(registeredUser);
                SaveAll(registeredUsers);
                return true;
            }
            return false;
        }

        public List<RegisteredUser> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<RegisteredUser>>(jsonString);
            return new List<RegisteredUser>();
        }
        public void SaveAll(List<RegisteredUser> registeredUsers)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, registeredUsers);
                }
            }
        }
    }
}