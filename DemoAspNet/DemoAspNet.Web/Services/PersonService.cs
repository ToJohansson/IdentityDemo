using DemoAspNet.Web.Models;

namespace DemoAspNet.Web.Services;

public class PersonService
{
    List<Person> people = [
        new Person {Id = 1, Name = "Klara"},
        new Person {Id = 2, Name = "Tobias"},
        new Person {Id = 3, Name = "Wiggo"},
        new Person {Id = 4, Name = "Barbro"},
        ];

    public Person[] GetAllPeople() => people
        .OrderBy(x => x.Id)
        .ToArray();

    public Person? GetPersonById(int id) => people
        .SingleOrDefault(p => p.Id == id);

    public void CreatePerson(int id, string name)
    {
        if (GetPersonById(id) != null)
        {
            throw new ArgumentException($"A person with id: {id} already exists");
        }

        var person = new Person
        {
            Id = id,
            Name = name
        };

        people.Add(person);
    }

    public void DeletePersonByID(int id)
    {
        var person = people.SingleOrDefault(p => p.Id == id);
        if (person == null)
        {
            throw new ArgumentException($"ID: {id} does not exists");
        }
        people.Remove(person);
    }

}
