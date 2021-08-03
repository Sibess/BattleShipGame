using System;
using System.Collections.Generic;

namespace BattleShipGame
{
    public class Grid
    {
        public void DisplayGrid(string[,] array) //displaying grid 
        {
            string inOneLine;
            int upperBound0 = array.GetUpperBound(0);
            int upperBound1 = array.GetUpperBound(1);
            for (int i = 0; i <= upperBound0; i++)
            {
                for (int j = 0; j <= upperBound1; j++)
                {
                    inOneLine = array[i, j];
                    Console.Write(string.Format("{0} ", inOneLine));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public string[,] PlayGrid() //constructing grid
        {
            int rows = 11;
            int columns = 11;

            string[,] board = new string[rows, columns];

            int upperBound0 = board.GetUpperBound(0);
            int upperBound1 = board.GetUpperBound(1);

            for (int i = 0; i <= upperBound0; i++)
            {
                for (int j = 0; j <= upperBound1; j++)
                {
                    board[i, j] = " * ";
                }
            }
            board[0, 0] = "   ";
            board[0, 1] = " 1 ";
            board[0, 2] = " 2 ";
            board[0, 3] = " 3 ";
            board[0, 4] = " 4 ";
            board[0, 5] = " 5 ";
            board[0, 6] = " 6 ";
            board[0, 7] = " 7 ";
            board[0, 8] = " 8 ";
            board[0, 9] = " 9 ";
            board[0, 10] = " 10 ";
            board[1, 0] = " A ";
            board[2, 0] = " B ";
            board[3, 0] = " C ";
            board[4, 0] = " D ";
            board[5, 0] = " E ";
            board[6, 0] = " F ";
            board[7, 0] = " G ";
            board[8, 0] = " H ";
            board[9, 0] = " I ";
            board[10, 0] = " J ";

            return board;
        }

        public string[,] PlayGridBadGuesses()
        {
            int rows = 11;
            int columns = 11;

            string[,] board = new string[rows, columns];  // 2 Dimensional Array

            int upperBound0 = board.GetUpperBound(0);
            int upperBound1 = board.GetUpperBound(1);
            for (int i = 0; i <= upperBound0; i++)
            {
                for (int j = 0; j <= upperBound1; j++)
                {
                    board[i, j] = " X ";
                }
            }

            board[0, 0] = "   ";
            board[0, 1] = " 1 ";
            board[0, 2] = " 2 ";
            board[0, 3] = " 3 ";
            board[0, 4] = " 4 ";
            board[0, 5] = " 5 ";
            board[0, 6] = " 6 ";
            board[0, 7] = " 7 ";
            board[0, 8] = " 8 ";
            board[0, 9] = " 9 ";
            board[0, 10] = " 10 ";
            board[1, 0] = " A ";
            board[2, 0] = " B ";
            board[3, 0] = " C ";
            board[4, 0] = " D ";
            board[5, 0] = " E ";
            board[6, 0] = " F ";
            board[7, 0] = " G ";
            board[8, 0] = " H ";
            board[9, 0] = " I ";
            board[10, 0] = " J ";

            return board;
        }

        public string[,] PlaceShips()
        {
            int rows = 11;
            int columns = 11;

            string[,] board = new string[rows, columns];  // 2 Dimensional Array

            int upperBound0 = board.GetUpperBound(0);
            int upperBound1 = board.GetUpperBound(1);
            for (int i = 0; i <= upperBound0; i++)
            {
                for (int j = 0; j <= upperBound1; j++)
                {
                    board[i, j] = " * ";
                }
            }

            board[0, 0] = "   ";
            board[0, 1] = " 1 ";
            board[0, 2] = " 2 ";
            board[0, 3] = " 3 ";
            board[0, 4] = " 4 ";
            board[0, 5] = " 5 ";
            board[0, 6] = " 6 ";
            board[0, 7] = " 7 ";
            board[0, 8] = " 8 ";
            board[0, 9] = " 9 ";
            board[0, 10] = " 10 ";
            board[1, 0] = " A ";
            board[2, 0] = " B ";
            board[3, 0] = " C ";
            board[4, 0] = " D ";
            board[5, 0] = " E ";
            board[6, 0] = " F ";
            board[7, 0] = " G ";
            board[8, 0] = " H ";
            board[9, 0] = " I ";
            board[10, 0] = " J ";

            List<Ship> ships = new List<Ship>() //list of ships (5)
            {
            new Carrier(),
            new BattleShip(),
            new Cruiser(),
            new Submarine(),
            new Destroyer(),
            };

            Random randomObject = new Random();
            foreach (Ship s in ships)
            {
                string shipChar = s.Label(); //hold the value of the ship - e.g. D, B, C...

                int i1 = randomObject.Next(s.MinimumHorizontalIndex(), s.MaximumHorizontalIndex());  //generate random numbers in 2D array for starting point
                int i2 = randomObject.Next(s.MinimumVerticalIndex(), s.MaximumVerticalIndex());

                int i1save = i1; //save starting point
                int i2save = i2;
                bool orientation = RandomOrientation(); //horizontal(true) or vertical(false)

                if (orientation)
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        if (board[i1, i2] == " * ") //check starting point - if *, move on
                        {
                            i2++; //add one to the columns
                            if (board[i1, i2] == " * ") //check if *
                            {
                                continue; //if *, continue with the loop
                            }
                            else
                            {
                                i1 = randomObject.Next(s.MinimumHorizontalIndex(), s.MaximumHorizontalIndex());  //if not *, generate new starting point
                                i2 = randomObject.Next(s.MinimumVerticalIndex(), s.MaximumVerticalIndex());
                                i1save = i1; //resave starting point
                                i2save = i2;
                                x = 0; //start the loop over
                                continue; //continue with loop
                            }
                        }
                        else
                        {
                            i1 = randomObject.Next(s.MinimumHorizontalIndex(), s.MaximumHorizontalIndex()); //if starting point not *, generate new starting point
                            i2 = randomObject.Next(s.MinimumVerticalIndex(), s.MaximumVerticalIndex());
                            i1save = i1; //resave starting point
                            i2save = i2;
                            x = 0; //start the loop over
                            continue; //continue with loop
                        }
                    }
                }
                else
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        if (board[i1, i2] == " * ") //check starting point - if *, move on
                        {
                            i1++; //add one to the columns
                            if (board[i1, i2] == " * ") //check if *
                            {
                                continue; //if *, continue with the loop
                            }
                            else
                            {
                                i1 = randomObject.Next(s.MinimumHorizontalIndex(), s.MaximumHorizontalIndex());   //if not *, generate new starting point
                                i2 = randomObject.Next(s.MinimumVerticalIndex(), s.MaximumVerticalIndex());
                                i1save = i1; //resave starting point
                                i2save = i2;
                                x = 0; //start the loop over
                                continue; //continue with loop
                            }
                        }
                        else
                        {
                            i1 = randomObject.Next(s.MinimumHorizontalIndex(), s.MaximumHorizontalIndex());  //if starting point not *, generate new starting point
                            i2 = randomObject.Next(s.MinimumVerticalIndex(), s.MaximumVerticalIndex());
                            i1save = i1; //resave starting point
                            i2save = i2;
                            x = 0; //start the loop over
                            continue; //continue with loop
                        }
                    }

                }

                board[i1save, i2save] = shipChar; //all cells have been checked now, use the saved starting point and assign value

                if (orientation)
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        i2save++;
                        board[i1save, i2save] = shipChar;
                    }
                }
                else
                {
                    for (int x = 1; x < s.LengthOfShip(); x++) //loop through for length of ship
                    {
                        i1save++;
                        board[i1save, i2save] = shipChar;
                    }
                }
            }
            return board;
        }

        public bool RandomOrientation()
        {
            Random randomObject = new Random();
            int i3 = randomObject.Next(0, 2);
            if (i3 == 1)
            {
                return true; //HORIZONTAL
            }
            return false; //VERTICAL
        }
    }
}
