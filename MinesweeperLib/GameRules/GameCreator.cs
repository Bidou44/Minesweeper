namespace MinesweeperLib.GameRules
{
	using System;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules.Cells;
	using MinesweeperLib.Helpers;

	public class GameCreator : IGameCreator
	{
		private Cell[,] cells = null;

		private readonly ICellValueBaseFactory cellValueBaseFactory = null;

		private readonly GameConfiguration gameConfiguration = null;

		public GameCreator(ICellValueBaseFactory cellValueBaseFactory, GameConfiguration gameConfiguration, IApplicationConfiguration appConfig)
		{
			Size minGameSize = appConfig.MinGameSize;
			Size maxGameSize = appConfig.MaxGameSize;

			if (gameConfiguration.Level.GameSize.IsNotBetween(minGameSize, maxGameSize))
			{
				string message = string.Format("The game size must be between {0} and {1}", minGameSize, maxGameSize);
				throw new ArgumentException(message);
			}

			this.cellValueBaseFactory = cellValueBaseFactory;
			this.gameConfiguration = gameConfiguration;

			this.Initialize();
		}

		public Cell[,] CreateGame()
		{
			Size gameSize = this.gameConfiguration.Level.GameSize;

			for (int i = 0; i < gameSize.Width; i++)
			{
				for (int j = 0; j < gameSize.Height; j++)
				{
					Coordinate current = new Coordinate(i, j);
					CellValueBase cellValue = this.cellValueBaseFactory.CreateCell(current);
					Cell cell = new Cell(current, cellValue);

					this.cells[i, j] = cell;
				}
			}

			return cells;
		}

		private void Initialize()
		{
			this.cells = new Cell[this.gameConfiguration.Level.GameSize.Width, this.gameConfiguration.Level.GameSize.Height];
		}
	}
}