namespace MinesweeperLib.Configurations
{
	public class GameLevel
	{
		public Size GameSize { get; set; }

		public int NumberOfBombs { get; set; }

		public string Name { get; set; }

		public static GameLevel Easy
		{
			get { return new GameLevel() { GameSize = new Size(10, 10), Name = "Easy", NumberOfBombs = 10 }; }
		}

		public static GameLevel Medium
		{
			get { return new GameLevel() { GameSize = new Size(20, 20), Name = "Medium", NumberOfBombs = 50 }; }
		}

		public static GameLevel Hard
		{
			get { return new GameLevel() { GameSize = new Size(25, 25), Name = "Hard", NumberOfBombs = 100 }; }
		}
	}
}