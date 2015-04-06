namespace MinesweeperLib.Cells
{
	public class BombCellValue : CellValueBase
	{
		public BombCellValue()
		{
		}

		public override int? NumberOfBombAround
		{
			get { return null; }
		}
	}
}