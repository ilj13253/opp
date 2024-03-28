using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popsik
{
   public interface IPersonR
    {
        Task<List<Person>> GetAll();
       Task<List<Departmets>> GetAllDepartments();
       Task<Person> GetById(int id);
        Task Create(Person p);
        Task Create(params Person[] p);
        Task Update(Person p);
        Task Update(params Person[] p);
        Task Delete(Person p);
       Task<int> Getcount();
       Task<List<Person>> GetPeopleAndDeparmetsByAll(int id);
    }
}