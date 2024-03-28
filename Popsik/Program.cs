using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace Popsik
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var personRep = new PersonRep();

            // Создаем несколько объектов Person для добавления в базу данных
            var person1 = new Person {Name = "Joh35n", Age = 34 };
            var person2 = new Person { Name = "Alic66e", Age = 29 };
           // var d2 = new Departmets {Name="uuu",Couty=2};
            // Добавляем объекты Person в базу данных
            await personRep.Create(person1);
            await personRep.Create(person2);
            // Получаем всех людей из базы данных и выводим их информацию
            var allPersons = await personRep.GetAll();
            Console.WriteLine("All Persons:");
            foreach (var person in allPersons)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Age: {person.Age}");
            }

            // Получаем количество записей в таблице Persons
            var count = await personRep.Getcount();
            Console.WriteLine($"Total Persons Count: {count}");

            // Обновляем информацию о первом человеке
            person1.Age = 35;
            await personRep.Update(person1);

            // Удаляем второго человека из базы данных
            await personRep.Delete(person2);

            // Получаем все отделы и выводим информацию о них
            var allDepartments = await personRep.GetAllDepartments();
            Console.WriteLine("All Departments:");
            foreach (var department in allDepartments)
            {
                Console.WriteLine($"ID: {department.Id}, Name: {department.Name}");
            }

            // Получаем людей и их отделы по заданному идентификатору отдела
            var peopleAndDepartments = await personRep.GetPeopleAndDeparmetsByAll(1);
            Console.WriteLine("People in Department 1:");
            foreach (var person in peopleAndDepartments)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Age: {person.Age}");
            }
        }
    }
}
