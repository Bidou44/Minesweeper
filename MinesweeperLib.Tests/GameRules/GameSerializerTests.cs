namespace MinesweeperLib.Tests.GameRules
{
	using System.Collections.Generic;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules;
	using MinesweeperLib.GameRules.Cells;

	using Moq;

	[TestClass]
	public class GameSerializerTests
	{
		[TestMethod]
		public void Save()
		{
			// Arrange
			IBoard board = this.CreateBoard(new GameLevel(1, new Size(3, 2)));
			IGameSerializer gameSerializer = new GameSerializer();
			IGame game = new Game(board, gameSerializer);

			// Act
			string result = gameSerializer.Save(game);

			// Assert
			Assert.AreEqual("(0;0)-F-1|(0;1)-F-B|(1;0)-F-1|(1;1)-F-1|(2;0)-F-0|(2;1)-F-0", result);
		}

		private Board CreateBoard(GameLevel gameLevel)
		{
			Mock<IApplicationConfiguration> appConfig = new Mock<IApplicationConfiguration>();
			appConfig.Setup(b => b.MinGameSize).Returns(new Size(2, 2));
			appConfig.Setup(b => b.MaxGameSize).Returns(new Size(4, 4));

			IEnumerable<Coordinate> bombsCoordinates = new List<Coordinate>{new Coordinate(0, 1)};
			GameConfiguration gameConfiguration = new GameConfiguration(gameLevel);
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(bombsCoordinates);
			IGameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, appConfig.Object);
			Board board = new Board(gameCreator, gameConfiguration);
			return board;
		}
	}
}