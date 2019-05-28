namespace MinesweeperLib.Tests.GameRules.Cells
{
	using System.Collections.Generic;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Common;
	using MinesweeperLib.GameRules.Cells;

	[TestClass]
	public class CellValueBaseFactoryTests
	{
		[TestMethod]
		public void CellIsEmptyCellValue()
		{
			// Arrange
			HashSet<Coordinate> coordinates = new HashSet<Coordinate>();
			Coordinate current = new Coordinate();
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);

			// Act
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			// Assert
			Assert.IsTrue(cell is EmptyCellValue);
		}

		[TestMethod]
		public void CellIsBomb()
		{
			// Arrange
			HashSet<Coordinate> coordinates = new HashSet<Coordinate> { new Coordinate() };
			Coordinate current = new Coordinate();
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);

			// Act
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			// Assert
			Assert.IsTrue(cell.IsBomb);
		}

		[TestMethod]
		public void CellHasOneBombAround()
		{
			// Arrange
			List<Coordinate> coordinates = new List<Coordinate> { new Coordinate(1, 1) };
			Coordinate current = new Coordinate(0, 1);
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);

			// Act
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			// Assert
			Assert.AreEqual((byte)1, cell.NumberOfBombAround);
		}

		[TestMethod]
		public void CellisCompletlySurrounded()
		{
			// Arrange
			HashSet<Coordinate> coordinates = new HashSet<Coordinate>
				                                  {
					                                  new Coordinate(1, 0), new Coordinate(2, 0), new Coordinate(1, 1), new Coordinate(1, 2),
                                                      new Coordinate(3, 2), new Coordinate(3, 1), new Coordinate(2, 2), new Coordinate(3, 0)
				                                  };
			Coordinate current = new Coordinate(2, 1);
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);

			// Act
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			// Assert
			Assert.AreEqual((byte)8, cell.NumberOfBombAround);
		}
	}
}