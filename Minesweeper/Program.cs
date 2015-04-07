namespace Minesweeper
{
	using System;

	using MinesweeperLib;
	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules;

	public class Program
	{
		public static void Main(string[] args)
		{
			Start();
			Console.Read();
		}

		private static void Start()
		{
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			Minesweeper minesweeper = new Minesweeper(gameConfiguration);

			string input = null;
			while (input == null || input.Trim().ToLower() == "r")
			{
				if (input != null)
				{
					Console.Clear();
					minesweeper = new Minesweeper(gameConfiguration);
				}

				while (minesweeper.GameState == GameState.Playing)
				{
					Console.WriteLine("Please enter next move, for example: 4;3");
					string line = Console.ReadLine();
					try
					{
						Coordinate nextMove = ExtractCoordinate(line);
						minesweeper.Play(nextMove);
						minesweeper.Dump();
					}
					catch (ArgumentException e)
					{
						Console.WriteLine("Invalid move, try again");
					}
					catch (Exception e)
					{
						Console.WriteLine("Sorry, an error occured");
					}

					Console.WriteLine();
					Console.WriteLine();
				}

				Console.WriteLine("Game finished, you " + (minesweeper.GameState == GameState.FinishedWon ? "win!" : "loose!"));
				Console.WriteLine("Hit 'R' or 'r' to restart, any other key to exit");
				
				input = Console.ReadLine();
			}
		}

		private static Coordinate ExtractCoordinate(string input)
		{
			string[] coords = input.Split(';', ',');
			if (coords.Length == 2)
			{
				int xCoord = 0;
				if (Int32.TryParse(coords[0].Trim(), out xCoord))
				{
					int yCoord = 0;
					if (Int32.TryParse(coords[1].Trim(), out yCoord))
					{
						Coordinate coord = new Coordinate(xCoord, yCoord);
						return coord;
					}
				}
			}

			throw new ArgumentException("Invalid coordinate", "input");
		}
	}
}