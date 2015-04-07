namespace MinesweeperLib.GameRules
{
	using System;
	using System.Linq;

	using MinesweeperLib.Common;
	using MinesweeperLib.GameRules.Cells;

	public class GameSerializer : IGameSerializer
	{
		private const char CellSeparator = '|';

		private const char DataSeparator = '-';

		public string Save(IGame game)
		{
			string gameString = string.Join(CellSeparator.ToString(), game.Board.Select(this.Encode));
			return gameString;
		}

		private string Encode(Cell cell)
		{
			Coordinate coordinate = cell.Coordinate;
			bool isPlayed = cell.IsPlayed;
			string value = cell.CellValue.GetStateRepresentation();

			string cellString = string.Format("{1}{0}{2}{0}{3}", DataSeparator, coordinate, isPlayed ? "T" : "F", value);
			return cellString;
		}

		public IGame Load(string game)
		{
			throw new NotImplementedException();
		}
	}
}