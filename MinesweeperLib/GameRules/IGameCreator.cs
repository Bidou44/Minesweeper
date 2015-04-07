namespace MinesweeperLib.GameRules
{
	using MinesweeperLib.GameRules.Cells;

	public interface IGameCreator
	{
		Cell[,] CreateGame();
	}
}