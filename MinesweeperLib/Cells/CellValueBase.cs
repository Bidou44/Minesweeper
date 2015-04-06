namespace MinesweeperLib.Cells
{
	public abstract class CellValueBase
	{	
		protected CellValueBase()
		{
			this.NumberOfBombAround = null;
		}

		public int? NumberOfBombAround { get; protected set; }

		public bool IsBomb
		{
			get { return this is BombCellValue; }
		}
	}
}