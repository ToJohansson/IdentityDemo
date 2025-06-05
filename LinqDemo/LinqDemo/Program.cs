// See https://aka.ms/new-console-template for more information
using LinqDemo;

Person[] people = [
    new Person() {Id = 156, Name = "Tobias", Age = 34},
    new Person() { Id = 234, Name = "Klara", Age = 35},
    new Person() { Id = 123, Name = "Barbro", Age = 4},
    new Person() { Id = 10, Name = "Wiggo", Age = 1},
    ];

Workplace[] workplace = [
    new Workplace() {CompanyId = 56, Name="Ikea"},
    new Workplace() {CompanyId = 15, Name="Lexicon"},
    new Workplace() {CompanyId = 16, Name="Ica"}
    ];

var q1 = people
    .Where(p => p.Age > 30)
    .OrderBy(p => p.Name)
    .ThenBy(p => p.Age)
    .Select(p => p.Name);

foreach (var p in q1)
{
    Console.WriteLine($"{p}");
}