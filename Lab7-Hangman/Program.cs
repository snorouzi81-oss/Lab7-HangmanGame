

namespace Lab7_Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HangmanGame hangmanGame = new HangmanGame();

            if (hangmanGame.HasWord())
            {
                Console.WriteLine("Game is ready");
                //bool isCorrect = hangmanGame.GuessLetter('H');
            }
            else
            {
                Console.WriteLine("No words available");
            }

            while (!hangmanGame.IsGameOver())
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    input = input.ToUpper();

                    // I use a switch statement to display a different message
                    // for each GuessResult.
                    GuessResult result = hangmanGame.GuessLetter(input[0]);
                    switch (result)
                    {
                        case GuessResult.Correct:
                            Console.WriteLine("Correct guess!");
                            break;

                        case GuessResult.Wrong:
                            Console.WriteLine("Wrong guess!");
                            break;

                        case GuessResult.AlreadyGuessed:
                            Console.WriteLine("You already guessed this letter.");
                            break;
                    }

                    // Display the current progress after each guess.
                    Console.WriteLine(hangmanGame.GetWordProgress());

                    // Check whether the player has won or lost
                    // and stop the game when it is over.
                    if (hangmanGame.IsWinner())
                    {
                        Console.WriteLine("You win!");
                        break;
                    }

                    if (hangmanGame.IsLoser())
                    {
                        Console.WriteLine("You lose!");
                        Console.WriteLine($"The word was: {hangmanGame.GetSecretWord()}");
                        break;
                    }

                }

            }
        }
    }
}
