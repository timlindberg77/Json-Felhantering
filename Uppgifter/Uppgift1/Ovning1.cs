using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Json_Felhantering.Uppgifter.Uppgift1
{
    public class Ovning1
    {
        public static void runOvning1()
        {
            User nemo = new User();
            try
            {
                Console.WriteLine("skriv namn!");
                nemo.name = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("nej");
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

            var json = JsonSerializer.Serialize(nemo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}
