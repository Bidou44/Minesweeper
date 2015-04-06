namespace MinesweeperLib
{
	using System.Collections.Generic;

	using MinesweeperLib.Cells;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.Helpers;

	// Facade to hide the construction of the game
	public class Minesweeper
	{
		private Game game = null;

		public Minesweeper(GameConfiguration gameConfiguration)
		{
			this.Initialize(gameConfiguration);
		}

		public bool IsFinished
		{
			get { return this.game.IsFinished; }
		}

		public bool IsWinner
		{
			get { return this.game.IsWinner; }
		}

		public void Play(Coordinate coord)
		{
			this.game.Play(coord);
		}

		public void Dump()
		{
			this.game.Dump();
		}

		private void Initialize(GameConfiguration gameConfiguration)
		{
			// Composition root
			IEnumerable<Coordinate> bombCoordinates = Randomizer.GetRandomCoordinates(gameConfiguration.Level.GameSize, gameConfiguration.Level.NumberOfBombs);
			CellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(bombCoordinates);
			GameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, ApplicationConfiguration.Current);
			IBoard board = new Board(gameCreator, gameConfiguration);
			this.game = new Game(board);
		}
	}
}