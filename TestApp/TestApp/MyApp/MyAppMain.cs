using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.MyApp.Database;
using TestApp.MyApp.Models;


namespace TestApp.MyApp
{
    class MyAppMain
    {
        public static void Run()
        {

            Console.WriteLine("App is starting...");
            Console.WriteLine("Initialize Database");

            MyDatabase.Instance.InitializeDatabase();
            Console.WriteLine("Creating fake people for fake database");
            foreach (var person in MyDatabase.Instance.GetPersons())
            {
                Console.WriteLine(person.ToString());
                Thread.Sleep(125);
            }
            Console.WriteLine("Database initialized");
            Console.WriteLine("App is running...");
            Thread.Sleep(1200);

            // run the app
            while (true)
            {
                Console.Clear();

                Menu();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        GetListOfPersons();
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        break;
                    case "1":
                        GetPersonByID();
                        break;
                    case "2":
                        AddPerson();
                        break;
                    case "3":
                        UpdatePerson();
                        break;
                    case "4":
                        DeletePerson();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        private static void GetListOfPersons()
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("- List of people -");
                var persons = MyDatabase.Instance.GetPersons();
                foreach (var person in persons)
                {
                    Console.WriteLine(person.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeletePerson()
        {
            try

            {
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("- Delete Person -");
                    Console.WriteLine("Enter the id of the person you want to delete:");
                    string idToDelete = Console.ReadLine();
                    if (int.TryParse(idToDelete, out int id))
                    {

                        if (MyDatabase.Instance.DeletePerson(id))
                        {
                            Console.WriteLine("Person deleted successfully");
                            Console.WriteLine("Press enter to go back.");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Person not found");
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdatePerson()
        {
            try
            {
                GetListOfPersons();
                Console.WriteLine("");
                Console.WriteLine("- Update Person -");
                while (true)
                {
                    Console.WriteLine("Enter the id of the person you want to update:");
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out int id))
                    {
                        var person = MyDatabase.Instance.GetPersonById(id);
                        if (person != null)
                        {
                            while (true)
                            {

                                string firstName;
                                do
                                {
                                    Console.WriteLine("Update the person's first name:");
                                    firstName = Console.ReadLine().Trim();
                                } while (string.IsNullOrEmpty(firstName));
                                person.FirstName = firstName;

                                string lastName;
                                do
                                {
                                    Console.WriteLine("Update lastname:");
                                    lastName = Console.ReadLine().Trim();
                                } while (string.IsNullOrEmpty(lastName));
                                person.LastName = lastName;

                                Console.WriteLine("Update the person's age.");
                                string strAge = Console.ReadLine();

                                if (int.TryParse(strAge, out int age))
                                {
                                    person.Age = age;

                                    if (MyDatabase.Instance.UpdatePerson(person))
                                    {
                                        Console.WriteLine("Person updated successfully");
                                        Console.WriteLine("Press enter to go back.");
                                        Console.ReadLine();
                                        return;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please enter a valid age.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Person not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddPerson()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\n- Add a new Person -");

                    string firstName;
                    do
                    {
                        Console.WriteLine("Enter the person's first name:");
                        firstName = Console.ReadLine().Trim();
                    } while (string.IsNullOrEmpty(firstName));

                    string lastName;
                    do
                    {
                        Console.WriteLine("Enter lastname:");
                        lastName = Console.ReadLine().Trim();
                    } while (string.IsNullOrEmpty(lastName));

                    Console.WriteLine("Enter the person's age.");
                    string strAge = Console.ReadLine();

                    if (int.TryParse(strAge, out int age))
                    {
                        MyDatabase.Instance.AddPerson(firstName, lastName, age);
                        Console.WriteLine("Person added successfully");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please enter a valid age.");
                    }
                }

                Console.WriteLine("Press enter to go back.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        private static void GetPersonByID()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("- Get person by Id -");
                Console.WriteLine("Enter a person's id to get details or type 'exit' to quit");
                var input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                if (int.TryParse(input, out int id))
                {
                    var person = MyDatabase.Instance.GetPersonById(id);
                    if (person != null)
                    {
                        Console.WriteLine(person.ToString());
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();

                    }
                    else
                    {
                        Console.WriteLine("Person not found");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }

        }
        private static void Menu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("0. Get all persons");
            Console.WriteLine("1. Get person by id");
            Console.WriteLine("2. Add person");
            Console.WriteLine("3. Update person");
            Console.WriteLine("4. Delete person");
            Console.WriteLine("5. Exit");
        }
    }
}
