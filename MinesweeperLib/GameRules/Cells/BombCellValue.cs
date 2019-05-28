namespace MinesweeperLib.GameRules.Cells
{
	public class BombCellValue : CellValueBase
	{
		public BombCellValue()
		{
		}

		public override byte? NumberOfBombAround => null;

        public override string GetStateRepresentation()
		{
			return "B";
		}
	}
}