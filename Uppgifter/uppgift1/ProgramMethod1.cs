using System;
using System.Collections.Generic;
using System.Text;

namespace Json_Felhantering.Uppgifter.uppgift1
{
    public class ProgramMethod1
    {
        public static void Ovning1()
        {
            //1.Skriv text till en JSON-fil
            //Be användaren skriva sitt namn och ålder, och spara det i en JSON-fil(user.json).
            // 💡 Tips: använd JsonSerializer.Serialize() och File.WriteAllText().
            User nemo = new User();
            try
            {
                Console.WriteLine("skriv namn!");
                nemo.name = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("ålder");
                nemo.age = int.Parse(Console.ReadLine());
            }

            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            static string GetProjectDirectory()
            {
                var dir = new DirectoryInfo(AppContext.BaseDirectory);
                while (dir != null && dir.GetFiles("*.csproj").Length == 0)
                    dir = dir.Parent;

                return dir?.FullName
                    ?? throw new DirectoryNotFoundException("Couldn't locate the project folder (.csproj).");
            }

            var path = Path.Combine(GetProjectDirectory(), "user.json");
            var jsonData = System.Text.Json.JsonSerializer.Serialize(nemo);
            System.IO.File.WriteAllText("user.json", jsonData);
        }
    }
}
