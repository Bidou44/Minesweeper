namespace MinesweeperLib.GameRules
{
	using MinesweeperLib.Common;

	public interface IGame
	{
		IBoard Board { get; }

		GameState GameState { get; }

		void Play(Coordinate coord);

		void Dump();
	}
}