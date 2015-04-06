namespace MinesweeperLib.Cells
{
	using System.Collections.Generic;

	using MinesweeperLib.Helpers;

	public class CellValueBaseFactory : ICellValueBaseFactory
	{
		private readonly HashSet<Coordinate> bombCoordinates = null;

		public CellValueBaseFactory(IEnumerable<Coordinate> bombCoordinates)
		{
			this.bombCoordinates = new HashSet<Coordinate>(bombCoordinates);
		}

		public CellValueBase CreateCell(Coordinate coordinate)
		{
			if (bombCoordinates.Contains(coordinate))
			{
				return new BombCellValue();
			}

			byte numberOfBombAround = 0;
			foreach (Coordinate coord in coordinate.GetAllNeighbors())
			{
				if (bombCoordinates.Contains(coord))
				{
					numberOfBombAround++;
				}
			}

			return numberOfBombAround == 0 ? (CellValueBase)new EmptyCellValue() : new CellValue(numberOfBombAround);
		}
	}
}