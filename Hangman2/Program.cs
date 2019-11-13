using System;

namespace Hangman2
{
    class Program
    {
        // STEP 2 - THE SECRET WORD
        static string secret = "";

        // STEP 1 - Show user welcome message
        static void Welcome()
        {
            Console.WriteLine("Welcome to hangman.");
            Console.WriteLine("Generating secret word to guess");
            Console.WriteLine("The gallows are waiting for you");
        }

        // STEP 2 - Generate secret word
        static void GenerateSecret()
        {
            secret = "Hello World".ToLower();
        }

        static void Main(string[] args)
        {
            Welcome();
            GenerateSecret();
        }
    }
}
