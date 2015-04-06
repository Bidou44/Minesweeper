namespace MinesweeperLib
{
	using MinesweeperLib.Cells;

	public interface IGameCreator
	{
		Cell[,] CreateGame();
	}
}