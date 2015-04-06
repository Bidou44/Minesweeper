namespace MinesweeperLib.Cells
{
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

		public Coordinate Coordinate { get; private set; }

		public CellValueBase CellValue { get; private set; }

		public bool IsPlayed { get; internal set; }
	}
}