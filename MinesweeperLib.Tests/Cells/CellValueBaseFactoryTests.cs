
namespace MinesweeperLib.Tests.Cells
{
	using System.Collections.Generic;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Cells;

	[TestClass]
	public class CellValueBaseFactoryTests
	{
		[TestMethod]
		public void CellIsEmptyCellValue()
		{
			HashSet<Coordinate> coordinates = new HashSet<Coordinate>();
			Coordinate current = new Coordinate();
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			Assert.IsTrue(cell is EmptyCellValue);
		}

		[TestMethod]
		public void CellIsBomb()
		{
			HashSet<Coordinate> coordinates = new HashSet<Coordinate> { new Coordinate() };
			Coordinate current = new Coordinate();
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			Assert.IsTrue(cell.IsBomb);
		}

		[TestMethod]
		public void CellHasOneBombAround()
		{
			HashSet<Coordinate> coordinates = new HashSet<Coordinate> { new Coordinate(1, 1) };
			Coordinate current = new Coordinate(0, 1);
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			Assert.AreEqual(1, cell.NumberOfBombAround);
		}

		[TestMethod]
		public void CellisCompletlySurrounded()
		{
			HashSet<Coordinate> coordinates = new HashSet<Coordinate>
				                                  {
					                                  new Coordinate(1, 0), new Coordinate(2, 0), new Coordinate(1, 1), new Coordinate(1, 2),
				                                    new Coordinate(3, 2), new Coordinate(3, 1), new Coordinate(2, 2), new Coordinate(3, 0)
				                                  };
			Coordinate current = new Coordinate(2, 1);
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(coordinates);
			CellValueBase cell = cellValueBaseFactory.CreateCell(current);

			Assert.AreEqual(8, cell.NumberOfBombAround);
		}
	}
}