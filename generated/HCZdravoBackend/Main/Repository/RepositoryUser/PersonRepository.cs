using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Main.Repository.RepositoryUser
{
    public class PersonRepository : IPersonRepository
    {
        private string _path = "person.json";

        public PersonRepository()
        {
            if (!File.Exists(_path))
            {
                SaveAll(new List<Person>());
            }
        }
        public bool Create(Person obj)
        {
            if (Get(obj.Pin) == null)
            {
                List<Person> people = GetAll();
                people.Add(obj);
                SaveAll(people);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            Person person = Get(id);
            if (person != null)
            {
                List<Person> people = GetAll();
                people.Remove(person);
                SaveAll(people);
                return true;
            }
            return false;
        }

        public bool Update(Person obj)
        {
            if (Get(obj.Pin) != null)
            {
                List<Person> people = GetAll();
                foreach (Person person in people)
                {
                    if (person.Pin.Equals(obj.Pin))
                    {
                        people[people.IndexOf(person)] = obj;
                        break;
                    }
                }
                SaveAll(people);
                return true;
            }
            return false;
        }

        public Person Get(string id)
        {
            List<Person> people = GetAll();
            foreach (Person person in people)
                if (person.Pin.Equals(id)) return person;
            return null;
        }

        public List<Person> GetAll()
        {
            string jsonString = File.Exists(_path) ? File.ReadAllText(_path) : "";
            if (!string.IsNullOrEmpty(jsonString)) return JsonConvert.DeserializeObject<List<Person>>(jsonString);
            return new List<Person>();
        }
        public void SaveAll(List<Person> secretaries)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            serializer.TypeNameHandling = TypeNameHandling.All;
            using (StreamWriter writer = new StreamWriter(_path))
            {
                using (JsonWriter jwriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jwriter, secretaries);
                }
            }
        }
    }
}
