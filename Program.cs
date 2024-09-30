using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text.Json;

namespace JSONSerializer;

class Program
{
    static void Main(string[] args)
    {
        try
        {
        
        
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
            var person = new Person
            {
                Name = NameInput,
                Age = AgeInputInt,
                City = CityInput
                
            };
            Console.WriteLine($"Name: {person.Name}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"City: {person.City}");

            string json = JsonSerializer.Serialize(person, new JsonSerializerOptions {WriteIndented = true});

            string filePath = "Person.json";
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
