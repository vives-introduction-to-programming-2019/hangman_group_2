using System;

namespace Hangman2
{
    class Program
    {
        // STEP 2 - THE SECRET WORD
        static string secret = "";

        // STEP 3 - Revealed Secret (= current user progress)
        static string revealedSecret = "";

        // STEP 5 - Previously guessed letters
        static string previouslyGuessedLetters = "";

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

        // STEP 4 - Requesting a letter from the user
        // Only valid letters and lower case
        static char RequestLetterFromUser()
        {
            char letter = ' ';
            do
            {
                Console.Write("Please enter your guess (letters only): ");
                string input = Console.ReadLine().ToLower();
                letter = Convert.ToChar(input);
            } while (!(letter >= 'a' && letter <= 'z'));

            return letter;
        }

        static void Main(string[] args)
        {
            Welcome();
            GenerateSecret();
            BuildInitialRevealedSecret();

            Console.WriteLine($"Current user progress: {revealedSecret}");

            char userGuess = RequestLetterFromUser();

            Console.WriteLine("Your guess: " + userGuess);

            previouslyGuessedLetters += $"{userGuess} ";
            Console.WriteLine($"You tried the following letters: {previouslyGuessedLetters}");
        }
    }
}
