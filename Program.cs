using System;
using System.Net.Http.Headers;
using System.Text;

namespace Base64_Encoding_Decoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Encoding Basic Authentication credentials
            Console.WriteLine("UserName: ");
            string UserName = Console.ReadLine();
            Console.WriteLine("Password: ");
            string Password = Console.ReadLine();

            var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
            var clientAuthrizationHeader = new AuthenticationHeaderValue("Basic",
                                                          Convert.ToBase64String(byteArray));

            Console.WriteLine("\n\n" + "Encode: " + clientAuthrizationHeader + "\n\n");

            //Decoding Basic Authentication credentials
            var authHeader = clientAuthrizationHeader;
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);

            var userName = credentials[0];
            var password = credentials[1];

            Console.WriteLine("\n\n" + "Decode: " + "\n\n" + "UserName: " + userName + "\n" + "Password: " + password);
            Console.ReadKey();
        }
    }
}
