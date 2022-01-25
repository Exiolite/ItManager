using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileName = Console.ReadLine();
            var bytes = File.ReadAllBytes($"{fileName}.im");
        }
    }
}
