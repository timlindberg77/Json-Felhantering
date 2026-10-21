using Json_Felhantering.Uppgifter.Uppgift1;
using System.Text.Json;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Json_Felhantering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2.Läs och visa JSON - filen
            //Läs in filen du skapade i förra övningen och skriv ut innehållet i konsolen.
            // 💡 Tips: använd JsonSerializer.Deserialize<T>().
            string json = File.ReadAllText("user.json");
            List<User> users = JsonSerializer.Deserialize<List<User>>(json);
            
            foreach (User U in users)
            {
                Console.WriteLine($"{U.name} {U.age}"   );
            }
        }
    }
}
