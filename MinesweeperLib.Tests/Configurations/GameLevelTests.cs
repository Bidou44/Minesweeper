namespace MinesweeperLib.Tests.Configurations
{
	using System;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;

	[TestClass]
	public class GameLevelTests
	{
		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void BombIsNegativ()
		{
			new GameLevel(-1, new Size(1, 1));
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void GameIsTooSmall()
		{
			new GameLevel(-1, new Size(0, 1));
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void GameIsTooSmallForBombs()
		{
			new GameLevel(5, new Size(2, 2));
		}

		[TestMethod]
		public void GameIsValid()
		{
			new GameLevel(9, new Size(3, 3));
		}
	}
}