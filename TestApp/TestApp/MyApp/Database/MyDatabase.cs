using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.MyApp.Models;

namespace TestApp.MyApp.Database
{
    class MyDatabase
    {
        private static readonly MyDatabase _instance = new MyDatabase();
        private List<Person> persons = new List<Person>();
        private int personId = 0;

        // Private constructor to prevent direct instantiation
        private MyDatabase()
        {
        }

        // Public static property to provide access to the instance
        public static MyDatabase Instance
        {
            get
            {
                return _instance;
            }
        }

        public void InitializeDatabase()
        {
            if (persons.Count > 0)
            {
                return;
            }
            persons.Add(new Person(1, "John", "Doe", 25));
            persons.Add(new Person(2, "Jane", "Doe", 30));
            persons.Add(new Person(3, "Alice", "Smith", 35));
            persons.Add(new Person(4, "Bob", "Smith", 40));
            persons.Add(new Person(5, "Charlie", "Brown", 45));
            persons.Add(new Person(6, "Daisy", "Johnson", 50));
            persons.Add(new Person(7, "Eve", "Brown", 55));
            persons.Add(new Person(8, "Frank", "Johnson", 60));
            persons.Add(new Person(9, "Grace", "Lee", 65));
            persons.Add(new Person(10, "Henry", "Lee", 70));
            persons.Add(new Person(11, "Ivy", "White", 75));
            persons.Add(new Person(12, "Jack", "White", 80));
            persons.Add(new Person(13, "Kelly", "Green", 85));
            persons.Add(new Person(14, "Larry", "Green", 90));
            persons.Add(new Person(15, "Molly", "Black", 95));
            personId = 15;
        }

        public List<Person> GetPersons()
        {
            return persons;
        }

        public Person GetPersonById(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        public void AddPerson(String firstName, string lastName, int age)
        {
            personId++;
            Person person = new Person(personId, firstName, lastName, age);
            persons.Add(person);
        }

        public bool UpdatePerson(Person person)
        {
            var existingPerson = persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.Age = person.Age;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePerson(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                persons.Remove(person);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
