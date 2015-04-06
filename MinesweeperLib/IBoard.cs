namespace MinesweeperLib
{
	using MinesweeperLib.Cells;
	using MinesweeperLib.Configurations;

	public interface IBoard
	{
		Cell this[Coordinate coord] { get; }

		GameConfiguration GameConfiguration { get; }

		Size Size { get; }
	}
}