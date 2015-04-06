namespace MinesweeperLib.Cells
{
	public class EmptyCellValue : CellValueBase
	{
		public EmptyCellValue()
		{	
		}

		public override int? NumberOfBombAround
		{
			get { return null; }
		}
	}
}