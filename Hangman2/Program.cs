using System;

namespace Hangman2
{
    class Program
    {
        // STEP 1 - Show user welcome message
        static void Welcome()
        {
            Console.WriteLine("Welcome to hangman.");
            Console.WriteLine("Generating secret word to guess");
            Console.WriteLine("The gallows are waiting for you");
        }

        static void Main(string[] args)
        {
            Welcome();
        }
    }
}
