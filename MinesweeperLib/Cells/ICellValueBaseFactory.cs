namespace MinesweeperLib.Cells
{
	public interface ICellValueBaseFactory
	{
		CellValueBase CreateCell(Coordinate coordinate);
	}
}