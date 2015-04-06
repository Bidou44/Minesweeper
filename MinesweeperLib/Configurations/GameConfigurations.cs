namespace MinesweeperLib.Configurations
{
	public class GameConfiguration
	{
		public GameConfiguration(GameLevel level)
		{
			this.Level = level;
		}

		public GameLevel Level { get; set; }
	}
}