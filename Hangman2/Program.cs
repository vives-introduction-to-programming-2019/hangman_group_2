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

        // STEP 6 - Number of wrong guesses left
        static int remainingTries = 5;

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
            string[] secrets = System.IO.File.ReadAllLines(@"words.txt");
            //{
            //    "Hello World",
            //    "Immutable",
            //    "Scope Resolution Operator",
            //    "Dude"
            //};

            Random generator = new Random();
            int index = generator.Next(secrets.Length);

            secret = secrets[index].ToLower();
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
                letter = Convert.ToChar(input[0]);
            } while (!(letter >= 'a' && letter <= 'z'));

            return letter;
        }

        // STEP 6 - Processing the user letter
        static void ProcessUserLetter(char letter)
        {
            // Check if already tried
            if (previouslyGuessedLetters.Contains(letter))
            {
                Console.WriteLine("You already tried that letter");
            }
            else
            {
                previouslyGuessedLetters += $"{letter} ";
                if (secret.Contains(letter))
                {
                    Console.WriteLine("You guessed correct!");

                    string newRevealedSecret = "";
                    for (int i = 0; i < secret.Length; i++)
                    {
                        if (secret[i] == letter)
                        {
                            newRevealedSecret += $"{letter} ";
                        }
                        else
                        {
                            newRevealedSecret += $"{revealedSecret[2*i]} ";
                        }
                    }

                    revealedSecret = newRevealedSecret;
                }
                else
                {
                    Console.WriteLine("Wrong guess. Getting closer to the gallows");
                    remainingTries--;
                }
            }
        }

        static void GameLoop()
        {
            do
            {
                Console.WriteLine($"Current user progress: {revealedSecret}");
                Console.WriteLine($"You tried the following letters: {previouslyGuessedLetters}");
                Console.WriteLine($"You have {remainingTries} wrong guesses left");
                char userGuess = RequestLetterFromUser();

                Console.WriteLine("Your guess: " + userGuess);

                ProcessUserLetter(userGuess);
            } while (revealedSecret.Contains("_") && remainingTries > 0);
        }

        static void DetermineWinLoss()
        {
            if (remainingTries > 0)
            {
                Console.WriteLine("\nCongratz! You have won this fabulous game!");
            } else
            {
                Console.WriteLine("\nTo the gallows with you.");
            }
        }

        static void Main(string[] args)
        {
            Welcome();
            GenerateSecret();
            BuildInitialRevealedSecret();
            GameLoop();
            DetermineWinLoss();
        }
    }
}
