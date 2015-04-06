namespace MinesweeperLib.Cells
{
	using System;

	public class CellValue : CellValueBase
	{
		private readonly byte numberOfBombAround = 0;

		public CellValue(byte numberOfBombAround)
		{
			if (numberOfBombAround > 8)
			{
				throw new ArgumentException("Value must be between 0 and 8", "numberOfBombAround");
			}

			this.numberOfBombAround = numberOfBombAround;
		}

		public override int? NumberOfBombAround
		{
			get { return this.numberOfBombAround; }
		}
	}
}