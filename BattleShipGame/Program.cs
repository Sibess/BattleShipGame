using BattleShipGame;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BattleShipGame
{
    public class Program
    {
        //Maximize Console window size
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            DisplayWelcomeMenu();

            while (true)
            {
                Grid grid = new Grid();
                string[,] Board = grid.PlaceShips();                //actual board
                string[,] playBoard = grid.PlayGrid();                   //what the user sees
                string[,] playBoardBadGuess = grid.PlayGridBadGuesses(); //grid of X's     
                string[,] myBoard = grid.PlaceShips(); //my Board with boats on it

                //These are needed to keep track of guesses and if a boat was sunk
                int B = 0;
                int C = 0;
                int S = 0;
                int R = 0;
                int D = 0;
                int wrongGuesses = 0;
                int rightGuesses = 0;
                int computerRightGuesses = 0;
                int loopTimes = 55;
                int wrongGuessMatch = 51;

                //game starting
                for (int i = 1; i <= loopTimes; i++)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("MY BOARD:");
                        grid.DisplayGrid(myBoard);
                        Console.WriteLine("COMPUTER'S BOARD:");
                        grid.DisplayGrid(playBoard);

                        //computer attacking logic starts here
                        Random r = new Random();
                        int randomIndex = r.Next(1, 10);
                        int randomIndex2 = r.Next(1, 10);

                        //these are needed later for similar random values but in "do-while" loop
                        int doRandomIndex = 0;
                        int doRandomIndex2 = 0;

                        if (myBoard[randomIndex, randomIndex2] == " * " && !myBoard[randomIndex, randomIndex2].Equals(" B ") && !myBoard[randomIndex, randomIndex2].Equals(" C ") && !myBoard[randomIndex, randomIndex2].Equals(" R ") && !myBoard[randomIndex, randomIndex2].Equals(" D ") && !myBoard[randomIndex, randomIndex2].Equals(" S ") && !myBoard[randomIndex, randomIndex2].Equals(" X "))
                        {
                            myBoard[randomIndex, randomIndex2] = playBoardBadGuess[randomIndex, randomIndex2];  //miss
                        }

                        else if (myBoard[randomIndex, randomIndex2] == " H ") //if element already hit  - hit a boat
                        {
                            do
                            {
                                doRandomIndex = r.Next(1, 10);
                                doRandomIndex2 = r.Next(1, 10);
                            } 

                            while (myBoard[doRandomIndex, doRandomIndex2] == " * " || myBoard[doRandomIndex, doRandomIndex2] == " X " || myBoard[doRandomIndex, doRandomIndex2] == " H "); //loop until boat is found
                            myBoard[doRandomIndex, doRandomIndex2] = " H "; //hit a boat
                            computerRightGuesses++;

                        }

                        else if (myBoard[randomIndex, randomIndex2] == " X ") //if element already hit - hit a boat
                        {
                            do
                            {
                                doRandomIndex = r.Next(1, 10);
                                doRandomIndex2 = r.Next(1, 10);
                            } 

                            while (myBoard[doRandomIndex, doRandomIndex2] == " * " || myBoard[doRandomIndex, doRandomIndex2] == " X " || myBoard[doRandomIndex, doRandomIndex2] == " H "); //loop until boat is found
                            myBoard[doRandomIndex, doRandomIndex2] = " H "; //hit a boat
                            computerRightGuesses++;
                        }

                        else
                        {
                            myBoard[randomIndex, randomIndex2] = " H "; // hit a boat if boat element was randomly generated
                            computerRightGuesses++;
                        }

                        if (computerRightGuesses == 17) //if computer won
                        {
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(("YOU LOST!"));
                            Console.WriteLine("COMPUTER WON");
                            Console.WriteLine("Press Enter to Play Again");
                            Console.ReadLine();
                            break;
                        }

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
                        if (guess.Length < 2 || guess.Length > 3)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Your response must be a letter and a number (e.g. A1). Press Enter To Try again.");
                            Console.ReadLine();
                            continue;
                        }

                        string guessLet = guess.Substring(0, 1); //A
                        string guessNum = guess.Substring(1); //1

                        string letToNum = PossibleGuesses[guessLet]; //1
                        int letToNum1 = int.Parse(letToNum);
                        int guessNum1 = int.Parse(guessNum);

                        playBoard[letToNum1, guessNum1] = Board[letToNum1, guessNum1]; //assign the user board the value from the actual board

                        if (playBoard[letToNum1, guessNum1] == " * ") //if it's a *, they missed
                        {
                            wrongGuesses++; //add to wrongGuesses count
                            playBoard[letToNum1, guessNum1] = playBoardBadGuess[letToNum1, guessNum1]; //change value to an X
                            Board[letToNum1, guessNum1] = " X "; // change value manually for board with ships so we can valiidate already shot targets

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

                        else if (playBoard[letToNum1, guessNum1] == " X " || playBoard[letToNum1, guessNum1] == " H ") // already shot target validation
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("You have already shot this target");
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

                            playBoard[letToNum1, guessNum1] = Board[letToNum1, guessNum1] = " H "; // change value manually for board with ships so we can valiidate already shot targets
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
                        Console.WriteLine("Your response must be a letter (between A-J) and a number (between 1-10). Press Enter To Try again.");
                        Console.ReadLine();
                    }

                }
            }
        }

        public static void DisplayWelcomeMenu()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            string wecomeMessage = ("                                 WELCOME TO THE BATTLESHIP!                                 ");
            Console.SetCursorPosition((Console.WindowWidth - wecomeMessage.Length) / 2, Console.CursorTop);
            Console.WriteLine(wecomeMessage);
            Console.WriteLine("");
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hello {name}! Let's start playing ;)");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Glossary: \r\n B - Battleship \r\n S - Submarine, \r\n C - Carrier, \r\n R - Cruiser,\r\n D - Destroyer, \r\n X - Miss, \r\n H - Hit.");
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
            {"H", "8" },
            {"I", "9" },
            {"J", "10" }
        };
    }
}