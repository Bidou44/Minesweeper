namespace MinesweeperLib.GameRules.Cells
{
	public class EmptyCellValue : CellValueBase
	{
		public EmptyCellValue()
		{	
		}

		public override byte? NumberOfBombAround => null;

        public override string GetStateRepresentation()
		{
			return "0";
		}
	}
}