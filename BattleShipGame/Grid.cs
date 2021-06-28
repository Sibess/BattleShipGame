using System;

namespace BattleShipGame
{
  public class Grid
    {
		public void DisplayGrid(string[,] array) //displaying grid 
		{
			string inOneLine;
			int uBound0 = array.GetUpperBound(0);
			int uBound1 = array.GetUpperBound(1);
			for (int i = 0; i <= uBound0; i++)
			{
				for (int j = 0; j <= uBound1; j++)
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

			int uBound0 = board.GetUpperBound(0);
			int uBound1 = board.GetUpperBound(1);

			for (int i = 0; i <= uBound0; i++)
			{
				for (int j = 0; j <= uBound1; j++)
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
	}
}
