using System;

namespace JWT.Generate
{
    class Program
    {
        static void Main(string[] args)
        {
            var jwtToken = Convert.ToBase64String(new System.Security.Cryptography.HMACSHA256().Key);
            Console.WriteLine(jwtToken);
            Console.ReadLine();
        }
    }
}
