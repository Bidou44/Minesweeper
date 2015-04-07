namespace MinesweeperLib.GameRules
{
	using System.Collections.Generic;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules.Cells;

	public interface IBoard : IEnumerable<Cell>
	{
		Cell this[Coordinate coord] { get; }

		GameConfiguration GameConfiguration { get; }

		Size Size { get; }
	}
}