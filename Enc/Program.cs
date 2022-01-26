using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter fileName");
            var fileName = Console.ReadLine();
            Console.WriteLine("Enter password");
            var password = Console.ReadLine();
            Console.WriteLine("1 - Encrypt, 2 - Decrypt");
            var i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                var file = File.ReadAllText(fileName);
                var enc = Encryption.Encrypt(file, password);
                File.WriteAllBytes(fileName, enc);
            }
            if (i == 2)
            {
                var file = File.ReadAllBytes(fileName);
                var enc = Encryption.Decrypt(file, password);
                File.WriteAllText(fileName, enc);
            }
        }
    }
}
