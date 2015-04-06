namespace MinesweeperLib.Cells
{
	using System;

	public class CellValue : CellValueBase
	{
		public CellValue(byte numberOfBombAround)
		{
			if (numberOfBombAround > 8)
			{
				throw new ArgumentException("Value must be between 0 and 8", "numberOfBombAround");
			}

			this.NumberOfBombAround = numberOfBombAround;
		}
	}
}