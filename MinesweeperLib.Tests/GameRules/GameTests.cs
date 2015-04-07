namespace MinesweeperLib.Tests.GameRules
{
	using System.Collections.Generic;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules;
	using MinesweeperLib.GameRules.Cells;

	using Moq;

	[TestClass]
	public class GameTests
	{
		[TestMethod]
		public void Initialize()
		{
			// Arrange
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			IBoard board = GetGameCreator(gameConfiguration);

			// Act
			Game game = new Game(board, new GameSerializer());

			// Assert
			Assert.AreEqual(game.GameConfiguration, gameConfiguration);
			Assert.AreEqual(game.GameState, GameState.Playing);
		}

		[TestMethod]
		public void PlayOnBomb()
		{
			// Arrange
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			IBoard board = GetGameCreator(gameConfiguration);
			Game game = new Game(board, new GameSerializer());
			Coordinate bombCoordinate = Bombs.FirstOrDefault();

			// Act
			game.Play(bombCoordinate);

			// Assert
			Assert.AreEqual(game.GameState, GameState.FinishedLost);
		}

		[TestMethod]
		public void VerifyNeighbor()
		{
			// Arrange
			GameConfiguration gameConfiguration = new GameConfiguration(GameLevel.Easy);
			IBoard board = GetGameCreator(gameConfiguration);
			Game game = new Game(board, new GameSerializer());
			Coordinate play = new Coordinate(0, 0);

			// Act
			game.Play(play);

			// Asssert
			Assert.AreEqual(game.GameState, GameState.Playing);
			Assert.AreEqual(3, game.Board[play].CellValue.NumberOfBombAround.Value);
		}

		[TestMethod]
		public void WinGame()
		{
			// Arrange
			Mock<IApplicationConfiguration> config = new Mock<IApplicationConfiguration>();
			config.Setup(b => b.MinGameSize).Returns(new Size(2, 2));
			config.Setup(b => b.MaxGameSize).Returns(new Size(4, 4));

			GameConfiguration gameConfiguration = new GameConfiguration(new GameLevel(3, new Size(2, 2)) { Name = "Custom Level" });
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(Bombs);
			GameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, config.Object);
			IBoard board = new Board(gameCreator, gameConfiguration);
			Game game = new Game(board, new GameSerializer());
			Coordinate play = new Coordinate(0, 0);

			// Act
			game.Play(play);

			// Assert
			Assert.AreEqual(game.GameState, GameState.FinishedWon);
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
			get { return new List<Coordinate> { new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(1, 0) }; }
		}
	}
}