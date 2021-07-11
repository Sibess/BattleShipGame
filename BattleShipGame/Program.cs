using BattleShipGame;
using System;
using System.Collections.Generic;


namespace BattleShip
{
    public class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcomeMenu();

            while (true)
            {
                Grid grid = new Grid();
                string[,] Board = grid.PlaceShips();                //actual board
                string[,] playBoard = grid.PlayGrid();                   //what the user sees
                string[,] playBoardBadGuess = grid.PlayGridBadGuesses(); //grid of X's

                //These are needed to keep track of guesses and if a boat was sunk
                int B = 0;
                int C = 0;
                int S = 0;
                int R = 0;
                int D = 0;
                int wrongGuesses = 0;
                int rightGuesses = 0;
                int loopTimes = 30;
                int wrongGuessMatch = 14;
               
               //game starting
                for (int i = 1; i <= loopTimes; i++)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        grid.DisplayGrid(playBoard); //display the board for user
                        if ((wrongGuessMatch - 1) - wrongGuesses > 0)
                        {
                            Console.WriteLine($"You have {(wrongGuessMatch - 1) - wrongGuesses} wrong guesses left. Use them wisely!");
                        }
                        else
                        {
                            Console.WriteLine("DON'T MESS UP! You have 0 wrong guesses left!");
                        }
                        Console.WriteLine();
                        Console.WriteLine("GUESS: ");

                        string guess = Console.ReadLine().ToUpper(); //e.g. A1
                        if (guess.Length != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Your response must be a letter and a number (e.g. A1). Press Enter To Try again.");
                            Console.ReadLine();
                            continue;
                        }

                        string guessLet = guess.Substring(0, 1); //A
                        string guessNum = guess.Substring(1, 1); //1


                        string letToNum = PossibleGuesses[guessLet]; //1
                        int letToNum1 = int.Parse(letToNum);
                        int guessNum1 = int.Parse(guessNum);
                        playBoard[letToNum1, guessNum1] = Board[letToNum1, guessNum1]; //assign the user board the value from the actual board
                        if (playBoard[letToNum1, guessNum1] == " * ") //if it's a *, they missed
                        {
                            wrongGuesses++; //add to wrongGuesses count
                            playBoard[letToNum1, guessNum1] = playBoardBadGuess[letToNum1, guessNum1]; //change value to an X
                            if (wrongGuesses == wrongGuessMatch) 
                            {
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(("You Lose!"));
                                Console.WriteLine("Press Enter to see where all the ships were hiding.");
                                Console.ReadLine();
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;

                                grid.DisplayGrid(Board);
                                Console.WriteLine("Press enter to play again!");
                                Console.ReadLine();
                                break;
                            }
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("You Missed!");
                            Console.WriteLine("Press Enter to Guess Again. ");
                        }
                        else //if actual board is NOT a *
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;

                            switch (playBoard[letToNum1, guessNum1]) //add 1 to the assigned variable so we can keep track of when the ship is sunk
                            {
                                case " B ":
                                    B++;
                                    break;
                                case " S ":
                                    S++;
                                    break;
                                case " R ":
                                    R++;
                                    break;
                                case " D ":
                                    D++;
                                    break;
                                case " C ":
                                    C++;
                                    break;
                            }
                            rightGuesses++; //add one to rightguesses - it only takes 17 to win
                            if (rightGuesses == 17)
                            {
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Blue;

                                Console.WriteLine(("YOU WIN!"));
                                Console.WriteLine("CONGRATS ON BEATING THE COMPUTER!");
                                Console.WriteLine("Press Enter to Play Again");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                if (B == 4)
                                {
                                    Console.WriteLine("You sank my BattleShip!!");
                                    B--; //take one away from variable so it only shows that one time
                                }
                                else if (S == 3)
                                {
                                    Console.WriteLine(("You sank my Submarine!!"));
                                    S--;
                                }
                                else if (R == 3)
                                {
                                    Console.WriteLine(("You sank my Cruiser!!"));
                                    R--;
                                }
                                else if (D == 2)
                                {
                                    Console.WriteLine(("You sank my Destroyer!!"));
                                    D--;
                                }
                                else if (C == 5)
                                {
                                    Console.WriteLine(("You sank my Carrier!!"));
                                    C--;
                                }
                                else
                                {
                                    Console.WriteLine(("You Hit Me!"));
                                }
                            }
                            Console.WriteLine("Press Enter to Guess Again. ");
                        }
                        Console.ReadLine();
                    }

                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Your response must be a letter (between A-H) and a number (between 1-8). Press Enter To Try again.");
                        Console.ReadLine();
                    }
                }
            }
        }

        public static void DisplayWelcomeMenu()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                 Welcome to the Battleship game!                                 ");
            Console.WriteLine("");
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hello {name}! Let's start playing ;)");
            Console.WriteLine("");
            Console.WriteLine("Note: if you hit one of the ships you will see a corresponding letter (e.g Submarine - 'S', Carrier - 'C', exception Cruiser - 'R'). If you missed you will see 'X'.");
            Console.WriteLine("");
        }

        private static Dictionary<string, string> PossibleGuesses = new Dictionary<string, string>()
        {
            {"A", "1" },
            {"B", "2" },
            {"C", "3" },
            {"D", "4" },
            {"E", "5" },
            {"F", "6" },
            {"G", "7" },
            {"H", "8" }
        };
    } 
}




            
	


