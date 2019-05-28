namespace MinesweeperLib
{
	using System.Collections.Generic;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules;
	using MinesweeperLib.Helpers;

	// Facade to hide the construction of the game
	public class Minesweeper
	{
		private readonly GameConfiguration gameConfiguration = null;

		private IGame game = null;

		public Minesweeper(GameConfiguration gameConfiguration)
		{
			this.gameConfiguration = gameConfiguration;

			this.Initialize();
		}

		public GameState GameState => this.game.GameState;

        public void Play(Coordinate coord)
		{
			this.game.Play(coord);
		}

		public void Dump()
		{
			this.game.Dump();
		}

		private void Initialize()
		{
			GameLevel level = this.gameConfiguration.Level;
			IEnumerable<Coordinate> bombCoordinates = Randomizer.GetRandomCoordinates(level.GameSize, level.NumberOfBombs);

			this.game = Game.CreateGame(ApplicationConfiguration.Current, this.gameConfiguration, bombCoordinates);
		}
	}
}