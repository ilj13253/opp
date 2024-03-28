using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popsik
{
   public class PersonRep : IPersonR
    {
        readonly string conn = "Data Source=LAPTOP-O676FMEF;Initial Catalog=Progromist;Integrated Security=True";
        public async Task Create(Person p)
        {
            using (var db = new SqlConnection(conn))
            {
                await db.ExecuteAsync("INSERT INTO Persons (Fullname, Age) VALUES (@Name, @Age)", p);
            }
        }

        public async Task Create(params Person[] p)
        {
            using (var db = new SqlConnection(conn))
            {
                await db.ExecuteAsync("INSERT INTO Persons (FullName, Age) VALUES (@Name, @Age)", p);
            }
        }

        public async Task Delete(Person p)
        {
            using (var db = new SqlConnection(conn))
            {
                await db.ExecuteAsync("DELETE FROM Persons WHERE Id = @Id", p);
            }
        }

        public async Task<List<Person>> GetAll()
        {
            using (var db = new SqlConnection(conn))
            {
                return (await db.QueryAsync<Person>("SELECT * FROM Persons")).ToList();
            }
        }

        public async Task<Person> GetById(int id)
        {
            using (var db = new SqlConnection(conn))
            {
                return await db.QueryFirstOrDefaultAsync<Person>("SELECT * FROM Persons WHERE Id = @Id",new { Id=id });
            }
        }

        public async Task<int> Getcount()
        {
            using (var db = new SqlConnection(conn))
            {
                return await db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Persons");
            }
        }

        public async Task<List<Departmets>> GetAllDepartments()
        {
            using (var db = new SqlConnection(conn))
            {
                return (await db.QueryAsync<Departmets>("SELECT * FROM Departments")).ToList();
            }
        }

        public async Task<List<Person>> GetPeopleAndDeparmetsByAll(int id)
        {
            using (var db = new SqlConnection(conn))
            {
                var query = @"SELECT p.* FROM Persons p
                              INNER JOIN Departments d ON p.DepartmentId = d.Id
                              WHERE d.Id = @Id";
                return (await db.QueryAsync<Person>(query, new { Id = id })).ToList();
            }
        }

        public async Task Update(Person p)
        {
            using (var db = new SqlConnection(conn))
            {
                await db.ExecuteAsync("UPDATE Persons SET FullName = @Name, Age = @Age WHERE Id = @Id", p);
            }
        }

        public async Task Update(params Person[] p)
        {
            using (var db = new SqlConnection(conn))
            {
                foreach (var person in p)
                {
                    await db.ExecuteAsync("UPDATE Persons SET FullName = @Name, Age = @Age WHERE Id = @Id", person);
                }
            }
        }
    }
}
/*
Реализовать оставшиеся методы Асинхронно    


        Task<List<Person>> GetAllAsync();
List<Department> GetAllDepartments();
List<Department> GetDepartmentsAndPeople();
Person GetById(int id);
void Create(Person person);
void Create(params Person[] person);
void Update(Person person);
void Update(params Person[] person);
void Delete(Person person);
int GetCount();

List<Person> GetPeopleByDepartmentIdByAll(int id);
*/