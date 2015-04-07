namespace MinesweeperLib.Helpers
{
	using System;
	using System.Collections.Generic;

	using MinesweeperLib.Common;

	public static class Extensions
	{
		public static bool InInterval<T>(this T value, T lowerBoundInclusive, T upperBoundExclusive) where T : IComparable
		{
			return value.CompareTo(lowerBoundInclusive) >= 0 && value.CompareTo(upperBoundExclusive) < 0;
		}

		public static bool NotInInterval<T>(this T value, T lowerBoundInclusive, T upperBoundExclusive) where T : IComparable
		{
			return !value.InInterval(lowerBoundInclusive, upperBoundExclusive);
		}

		public static bool Contains(this Size size, Coordinate coord)
		{
			return coord.XCoord >= 0 && coord.XCoord < size.Width && coord.YCoord >= 0 && coord.YCoord < size.Height;
		}

		public static bool IsBetween(this Size size, Size minSize, Size maxSize)
		{
			return size.Width >= minSize.Width && size.Width <= maxSize.Width && size.Height >= minSize.Height && size.Height <= maxSize.Height;
		}

		public static bool IsNotBetween(this Size size, Size minSize, Size maxSize)
		{
			return !size.IsBetween(minSize, maxSize);
		}

		public static bool AtLeast(this Size size, Size minSize)
		{
			return size.Width >= minSize.Width && size.Height >= minSize.Height;
		}

		public static IEnumerable<Coordinate> GetAllNeighbors(this Coordinate coordinate)
		{
			for (int i = -1; i < 2; i++)
			{
				for (int j = -1; j < 2; j++)
				{
					Coordinate coord = coordinate.Add(i, j);
					if (coord != coordinate)
					{
						yield return coord;
					}
				}
			}
		}
	}
}