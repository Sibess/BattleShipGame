using BattleShipGame;
using System;

namespace BattleShip
{
	public class Program
	{
		static void Main(string[] args)
		{
			Grid grid = new Grid();
			string[,] playBoard = grid.PlayGrid();
			grid.DisplayGrid(playBoard);
		}
	}
}

