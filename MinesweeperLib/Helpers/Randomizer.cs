namespace MinesweeperLib.Helpers
{
	using System;
	using System.Collections.Generic;

	public static class Randomizer
	{
		private static readonly Random Random = new Random();

		public static IEnumerable<Coordinate> GetRandomCoordinates(Size gameSize, int numberOfCoordinate)
		{
			int numberOfCells = gameSize.Width * gameSize.Height;
			if (numberOfCoordinate > numberOfCells)
			{
				throw new ArgumentException("The game is too small", "numberOfCoordinate");
			}

			HashSet<Coordinate> coordinates = new HashSet<Coordinate>();
			while (coordinates.Count < numberOfCoordinate)
			{
				int xCoord = Random.Next(0, gameSize.Width);
				int yCoord = Random.Next(0, gameSize.Height);
				Coordinate coord = new Coordinate(xCoord, yCoord);
				if (!coordinates.Contains(coord))
				{
					coordinates.Add(coord);
				}
			}

			return coordinates;
		}
	}
}