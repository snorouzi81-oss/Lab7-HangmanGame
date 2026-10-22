using System;
// With help from ChatGPT, I learned that an enum
// can represent different results of a letter guess.
public enum GuessResult
{
    Correct,
    Wrong,
    AlreadyGuessed
}