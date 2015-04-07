namespace MinesweeperLib.Tests.GameRules
{
	using System;
	using System.Collections.Generic;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules;
	using MinesweeperLib.GameRules.Cells;
	using MinesweeperLib.Helpers;

	[TestClass]
	public class BoardTests
	{
		[TestMethod]
		public void BoardSize_InsideBoard()
		{
			// Arrange & Act
			Board board = this.CreateBoard(GameLevel.Easy);

			// Assert
			Assert.AreEqual(10, board.Size.Width);
			Assert.AreEqual(10, board.Size.Height);
		}

		[TestMethod]
		public void BoardSize_MaxValue()
		{
			// Arrange
			Board board = this.CreateBoard(GameLevel.Medium);

			// Act
			Cell value = board[board.Size.Width - 1, board.Size.Height - 1];

			// Assert
			Assert.IsNotNull(value);
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void BoardSize_OutsideBoard()
		{
			// Arrange
			Board board = this.CreateBoard(GameLevel.Hard);

			// Act
			Cell value = board[board.Size.Width, board.Size.Height];
		}

		private Board CreateBoard(GameLevel gameLevel)
		{
			IEnumerable<Coordinate> bombsCoordinates = Randomizer.GetRandomCoordinates(gameLevel.GameSize, gameLevel.NumberOfBombs);
			GameConfiguration gameConfiguration = new GameConfiguration(gameLevel);
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(bombsCoordinates);
			IGameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, ApplicationConfiguration.Current);
			Board board = new Board(gameCreator, gameConfiguration);
			return board;
		}
	}
}