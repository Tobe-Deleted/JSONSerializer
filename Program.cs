using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSONSerializer;

class Program
{
    static void Main(string[] args)
    {
        try
        {
        
            string filePath = "Person.json";
            List<Person> people = new List<Person>();
            if(File.Exists(filePath))
            {
                string existingJSON = File.ReadAllText(filePath);
                Console.WriteLine($"Existing JSON: {existingJSON}"); // Debug line
                if(!String.IsNullOrWhiteSpace(existingJSON))
                {
                    people = JsonSerializer.Deserialize<List<Person>>(existingJSON) ?? new List<Person>();
                }
            }
        
            Console.WriteLine("Hello, you!");

            Console.WriteLine("What is your name?");
            string? NameInput = Console.ReadLine();
            
            
            Console.WriteLine("How old are you?");
            /*int AgeInput = Convert.ToInt32(Console.ReadLine());
            int Age = AgeInput;*/
            string? AgeInputString = Console.ReadLine();
            int AgeInputInt;
            while(!int.TryParse(AgeInputString, out AgeInputInt))
            {
                Console.WriteLine("Age input has to be a number");
                AgeInputString = Console.ReadLine();
            }
            
            Console.WriteLine("What City are you from?");
            string? CityInput = Console.ReadLine();
            var newPerson = new Person
            {
                Name = NameInput,
                Age = AgeInputInt,
                City = CityInput
                
            };
            people.Add(newPerson);
            
            Console.WriteLine($"Name: {newPerson.Name}");
            Console.WriteLine($"Age: {newPerson.Age}");
            Console.WriteLine($"City: {newPerson.City}");

            string json = JsonSerializer.Serialize(people, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(filePath, json);

            Console.WriteLine("data written to json");
        }
            
        catch(IOException exception)
        {
            Console.WriteLine($"Cannot write to Person.json; {exception.Message}");
        }
        
        catch(Exception exception)
        {
            Console.WriteLine($"{exception.Message}");
        }
        
        
    }
}
