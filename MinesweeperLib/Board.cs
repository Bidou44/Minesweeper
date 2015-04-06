namespace MinesweeperLib
{
	using System;

	using MinesweeperLib.Cells;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.Helpers;

	public class Board : IBoard
	{
		private readonly IGameCreator gameCreator;

		private Cell[,] cells = null;

		public Board(IGameCreator gameCreator, GameConfiguration gameConfiguration)
		{
			this.gameCreator = gameCreator;
			this.GameConfiguration = gameConfiguration;

			this.Initialize();
		}

		public Cell this[int xCoord, int yCoord]
		{
			get
			{
				if (xCoord.NotInInterval(0, this.Size.Width) || yCoord.NotInInterval(0, this.Size.Height))
				{
					throw new ArgumentException("This cell is outside the game");
				}

				return this.cells[xCoord, yCoord];
			}
		}

		public Cell this[Coordinate coord]
		{
			get { return this[coord.XCoord, coord.YCoord]; }
		}

		public GameConfiguration GameConfiguration { get; private set; }

		public Size Size { get; private set; }

		private void Initialize()
		{
			this.cells = this.gameCreator.CreateGame();
			this.Size = new Size(this.cells.GetLength(0), this.cells.GetLength(1));
		}
	}
}