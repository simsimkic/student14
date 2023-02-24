using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace Main.Repository.RepositoryUser
{
    public interface IPersonRepository : IRepository<Person>
    {
        bool Create(Person obj);

        bool Delete(string id);

        Person Get(string id);

        List<Person> GetAll();
        bool Update(Person obj);
    }
}
