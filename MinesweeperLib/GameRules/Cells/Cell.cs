namespace MinesweeperLib.GameRules.Cells
{
	using MinesweeperLib.Common;

	public class Cell
	{
		public Cell(Coordinate coordinate, CellValueBase cellValue)
		{
			this.Coordinate = coordinate;
			this.CellValue = cellValue;
			this.IsPlayed = false;
		}

		public Cell(int xCoord, int yCoord, CellValueBase cellValue): this(new Coordinate(xCoord, yCoord), cellValue)
		{
		}

		public Coordinate Coordinate { get; }

		public CellValueBase CellValue { get; }

		public bool IsPlayed { get; internal set; }
	}
}