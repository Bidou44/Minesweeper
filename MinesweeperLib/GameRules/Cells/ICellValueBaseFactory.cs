namespace MinesweeperLib.GameRules.Cells
{
	using MinesweeperLib.Common;

	public interface ICellValueBaseFactory
	{
		CellValueBase CreateCell(Coordinate coordinate);
	}
}