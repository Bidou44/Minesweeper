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

		public GameState GameState
		{
			get { return this.game.GameState; }
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
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(bombCoordinates);
			IGameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, ApplicationConfiguration.Current);
			IBoard board = new Board(gameCreator, gameConfiguration);

			this.game = new Game(board);
		}
	}
}