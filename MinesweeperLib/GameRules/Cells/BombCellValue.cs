namespace MinesweeperLib.GameRules.Cells
{
	public class BombCellValue : CellValueBase
	{
		public BombCellValue()
		{
		}

		public override byte? NumberOfBombAround
		{
			get { return null; }
		}

		public override string GetStateRepresentation()
		{
			return "B";
		}
	}
}