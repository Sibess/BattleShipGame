using BattleShipGame;
using System;

namespace BattleShip
{
	public class Program
	{
		static void Main(string[] args)
		{
			Grid gm = new Grid();
			string[,] playBoard = gm.PlayGrid();
			gm.DisplayGrid(playBoard);
		}
	}
}

