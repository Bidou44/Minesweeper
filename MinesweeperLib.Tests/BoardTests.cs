namespace MinesweeperLib.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Cells;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.Helpers;

	[TestClass]
	public class BoardTests
	{
		[TestMethod]
		public void BoardSize_InsideBoard()
		{
			Board board = this.CreateBoard(GameLevel.Easy);
			Assert.AreEqual(10, board.Size.Width);
			Assert.AreEqual(10, board.Size.Height);
		}

		[TestMethod]
		public void BoardSize_MaxValue()
		{
			Board board = this.CreateBoard(GameLevel.Medium);
			Cell value = board[board.Size.Width - 1, board.Size.Height - 1];
			Assert.IsNotNull(value);
		}

		[ExpectedException(typeof(ArgumentException))]
		[TestMethod]
		public void BoardSize_OutsideBoard()
		{
			Board board = this.CreateBoard(GameLevel.Hard);
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