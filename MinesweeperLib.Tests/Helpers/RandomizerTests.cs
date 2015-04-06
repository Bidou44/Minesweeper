
namespace MinesweeperLib.Tests.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Helpers;

	[TestClass]
	public class RandomizerTests
	{
		[TestMethod]
		public void NoCoordinate()
		{
			IEnumerable<Coordinate> coordinates = Randomizer.GetRandomCoordinates(new Size(0, 0), 0);
			Assert.IsTrue(!coordinates.Any());
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void OutOfBoundCoordinate()
		{
			IEnumerable<Coordinate> coordinates = Randomizer.GetRandomCoordinates(new Size(1, 2), 3);
		}

		[TestMethod]
		public void AllFilled()
		{
			IEnumerable<Coordinate> coordinates = Randomizer.GetRandomCoordinates(new Size(10, 10), 100);
			Assert.IsTrue(coordinates.Count() == 100);

			foreach (Coordinate coordinate in coordinates)
			{
				IEnumerable<Coordinate> matches = coordinates.Where(c => c == coordinate);
				Assert.AreEqual(1, matches.Count());
			}
		}
	}
}