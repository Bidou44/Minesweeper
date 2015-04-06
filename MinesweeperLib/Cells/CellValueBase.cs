namespace MinesweeperLib.Cells
{
	public abstract class CellValueBase
	{	
		protected CellValueBase()
		{
		}

		public abstract int? NumberOfBombAround { get; }

		public bool IsBomb
		{
			get { return this is BombCellValue; }
		}
	}
}