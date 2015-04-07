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
	public class GameCreatorTests
	{
		[TestMethod]
		public void CreateGame()
		{
			// Arrange
			Mock<IApplicationConfiguration> config = new Mock<IApplicationConfiguration>();
			config.Setup(b => b.MinGameSize).Returns(new Size(2, 2));
			config.Setup(b => b.MaxGameSize).Returns(new Size(4, 4));

			GameConfiguration gameConfiguration = new GameConfiguration(new GameLevel(4, new Size(3, 3)) { Name = "My custom level" });
			List<Coordinate> bombs = new List<Coordinate>() { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 2), new Coordinate(2, 2) };
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(bombs);
			GameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, config.Object);

			// Act
			Cell[,] cells = gameCreator.CreateGame();

			// Assert
			List<Cell> allCells = cells.Cast<Cell>().ToList();
			Assert.AreEqual(bombs.Count(), allCells.Count(b => b.CellValue.IsBomb));
			Assert.AreEqual(2, cells[0, 2].CellValue.NumberOfBombAround.Value);
			Assert.AreEqual(2, cells[1, 0].CellValue.NumberOfBombAround.Value);
			Assert.AreEqual(4, cells[1, 1].CellValue.NumberOfBombAround.Value);
			Assert.AreEqual(2, cells[2, 1].CellValue.NumberOfBombAround.Value);
			Assert.IsFalse(cells[2, 0].CellValue.NumberOfBombAround.HasValue);
		}
	}
}