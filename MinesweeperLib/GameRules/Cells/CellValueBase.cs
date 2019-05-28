namespace MinesweeperLib.GameRules.Cells
{
	public abstract class CellValueBase
	{	
		protected CellValueBase()
		{
		}

		public abstract byte? NumberOfBombAround { get; }

		public bool IsBomb => this is BombCellValue;

        public abstract string GetStateRepresentation();
	}
}