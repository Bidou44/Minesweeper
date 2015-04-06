namespace MinesweeperLib.Tests
{
	using System.Collections.Generic;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Cells;
	using MinesweeperLib.Configurations;

	using Moq;

	[TestClass]
	public class GameTests
	{
		[TestMethod]
		public void Initialize()
		{
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			IBoard board = GetGameCreator(gameConfiguration);
			Game game = new Game(board);

			Assert.AreEqual(game.GameConfiguration, gameConfiguration);
			Assert.IsFalse(game.IsFinished);
			Assert.IsFalse(game.IsWinner);
		}

		[TestMethod]
		public void PlayOnBomb()
		{
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			IBoard board = GetGameCreator(gameConfiguration);
			Game game = new Game(board);

			game.Play(Bombs.FirstOrDefault());

			Assert.IsFalse(game.IsWinner);
			Assert.IsTrue(game.IsFinished);
		}

		[TestMethod]
		public void VerifyNeighbor()
		{
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			IBoard board = GetGameCreator(gameConfiguration);

			Game game = new Game(board);
			Coordinate play = new Coordinate(0, 0);
			game.Play(play);

			Assert.IsFalse(game.IsWinner);
			Assert.IsFalse(game.IsFinished);
			Assert.AreEqual(3, game.Board[play].CellValue.NumberOfBombAround.Value);
		}

		[TestMethod]
		public void WinGame()
		{
			Mock<IApplicationConfiguration> config = new Mock<IApplicationConfiguration>();
			config.Setup(b => b.MinGameSize).Returns(new Size(2, 2));
			config.Setup(b => b.MaxGameSize).Returns(new Size(4, 4));

			GameConfiguration gameConfiguration = new GameConfiguration(new GameLevel() { GameSize = new Size(2, 2), NumberOfBombs = 3, Name = "Custom Level" });
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(Bombs);
			GameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, config.Object);
			IBoard board = new Board(gameCreator, gameConfiguration);

			Game game = new Game(board);
			Coordinate play = new Coordinate(0, 0);
			game.Play(play);

			Assert.IsTrue(game.IsWinner);
			Assert.IsTrue(game.IsFinished);
			Assert.AreEqual(3, game.Board[play].CellValue.NumberOfBombAround.Value);
		}

		private IBoard GetGameCreator(GameConfiguration gameConfiguration)
		{
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(Bombs);
			GameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, ApplicationConfiguration.Current);
			IBoard board = new Board(gameCreator, gameConfiguration);
			return board;
		}

		private static IEnumerable<Coordinate> Bombs
		{
			get
			{
				return new List<Coordinate> { new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(1, 0) };
			}
		}
	}
}