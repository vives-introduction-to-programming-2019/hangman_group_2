using System;

namespace Hangman2
{
    class Program
    {
        // STEP 2 - THE SECRET WORD
        static string secret = "";

        // STEP 3 - Revealed Secret (= current user progress)
        static string revealedSecret = "";

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

        // STEP 3 - Build the initial revealed secret
        // hello world => _ _ _ _ _   _ _ _ _ _
        static void BuildInitialRevealedSecret()
        {
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == ' ')
                {
                    revealedSecret += "  ";
                }
                else
                {
                    revealedSecret += "_ ";
                }
            }
        }

        static void Main(string[] args)
        {
            Welcome();
            GenerateSecret();
            BuildInitialRevealedSecret();

            Console.WriteLine($"Current user progress: {revealedSecret}");
        }
    }
}
