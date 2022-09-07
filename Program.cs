using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;

namespace Hangman
{
internal class Program
    {
        private static void printHangman(int wrong)
        {
           //Hvergang der bliver tastet forkert.
            if(wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if(wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" o  |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" o    |");
                Console.WriteLine(" |    |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" o    |");
                Console.WriteLine("/|    |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" o    |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("      |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" o    |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/     |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" o    |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("   ===");
            }
        }
        private static int printWord(List<char>guessedLetters, string randomWord)
        {
            //her bliver indtastningen tjekket. 
            int counter = 0;
            int rightLetters = 0;
            Console.WriteLine("\r\n");
            foreach (char c in randomWord)
            {
                if(guessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    rightLetters++;
                }
                else
                {
                    Console.Write(" ");
                }
                counter++;
            }
            return rightLetters;
        }
        private static void printLines(string randomWord)
        {
            Console.Write("\r");
            foreach(char c in randomWord)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til Hangman :)");
            Console.WriteLine("--------------------------------");

            Random random = new Random();
            List<string> wordictionary = new List<string> { "blomster", "hus", "bil", "Programmering", "Computer", "kodning", "diamant", };
            int index = random.Next(wordictionary.Count);
            string randomWord = wordictionary[index];

            foreach (char x in randomWord)
            {
                Console.WriteLine("_ ");
            }
            int lengthofwordtoguess = randomWord.Length;
            int amountoftimeswrong = 0;
            List<char> currentlettersguessed = new List<char>();
            int currentletterRight = 0;

            while(amountoftimeswrong != 6 && currentletterRight != lengthofwordtoguess)
            {
                Console.Write("\nBogstaver valgt indtil videre: ");
                foreach(char letter in currentlettersguessed)
                {
                    Console.Write(letter + " ");
                }
                Console.Write("\nTast et bogstav: ");
                char letterguessed = Console.ReadLine()[0];
                if(currentlettersguessed.Contains(letterguessed))
                {
                    Console.Write("\r\nDu har allerede valgt dette bogstav.");
                    printHangman(amountoftimeswrong);
                    currentletterRight = printWord(currentlettersguessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    bool right = false;
                    for(int i = 0; i <randomWord.Length; i++) { if(letterguessed == randomWord[i]) { right = true; } }

                    if(right)
                    {
                        printHangman(amountoftimeswrong);
                        currentlettersguessed.Add(letterguessed);
                        currentletterRight = printWord(currentlettersguessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                    else
                    {
                        amountoftimeswrong++;
                        currentlettersguessed.Add(letterguessed);
                        printHangman(amountoftimeswrong);
                        currentletterRight = printWord(currentlettersguessed, randomWord);
                        Console.Write("\r\n");
                        printLines(randomWord);
                    }
                }
            }
            Console.WriteLine("\r\nGame over! Tak for deltagelsen");
        }
    }


}