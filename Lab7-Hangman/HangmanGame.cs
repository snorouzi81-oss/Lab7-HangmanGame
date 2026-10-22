using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7_Hangman
{
    internal class HangmanGame
    {
        private List<string> _words = new List<string> { "APPLE", "HOUSE", "COMPUTER" };
        private string _secretWord = "";
        private int _wrongGuesses = 0;
        private int _maxWrongGuesses = 6;
        private List<char> _guessedLetters = new List<char>();
        private Random _random = new Random();
        public HangmanGame()
        {
            if (_words.Count == 0)
            {
                return;
            }
            else
            {
                _secretWord = _words[_random.Next(0, _words.Count)];
            }

        }

        // I changed the return type from bool to GuessResult
        // so the program can distinguish between three outcomes.
        public GuessResult GuessLetter(char letter)
        {
            letter = char.ToUpper(letter);

            // A repeated guess should not count as a wrong guess.
            if (_guessedLetters.Contains(letter))
            {
                return GuessResult.AlreadyGuessed;
            }

            _guessedLetters.Add(letter);

            if (_secretWord.Contains(letter))
            {
                return GuessResult.Correct;
            }
            else
            {
                _wrongGuesses++;
                return GuessResult.Wrong;
            }

        }
        public bool IsGameOver()
        {
            if (IsWinner() || _wrongGuesses == _maxWrongGuesses)
            {
                return true;
            }
            return false;
        }
        public bool IsWinner()
        {
            foreach (var letter in _secretWord)
            {
                if (!_guessedLetters.Contains(letter))
                {
                    return false;
                }

            }

            return true;

        }
        public bool HasWord()
        {
            return _secretWord.Length > 0;
        }


        // This method checks the game logic and returns a bool.
        // The user-facing message is displayed in Program.
        public bool IsLoser()
        {
            return IsGameOver() && !IsWinner();
        }


        // ChatGPT helped me understand how to use a loop
        // and Contains() to display guessed letters and underscores.
        public string GetWordProgress()
        {
            string progress = "";
            for (int i = 0; i < _secretWord.Length; i++)
            {
                if (_guessedLetters.Contains(_secretWord[i]))
                {
                    progress += _secretWord[i];
                }
                else
                {
                    progress += '_';
                }

            }
            return progress;
        }

        public string GetSecretWord()
        {
            return _secretWord;
        }
    }
}