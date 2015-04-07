namespace MinesweeperLib.Configurations
{
	using System;

	using MinesweeperLib.Common;
	using MinesweeperLib.Helpers;

	public class GameLevel
	{
		public GameLevel(int numberOfBombs, Size size)
		{
			if (numberOfBombs <= 0)
			{
				throw new ArgumentException("You should have at least one bomb", "numberOfBombs");
			}

			if (!size.AtLeast(new Size(1, 1)))
			{
				throw new ArgumentException("The game size should be at least 1x1", "size");
			}

			if (numberOfBombs > size.Width * size.Height)
			{
				throw new ArgumentException(String.Format("The game is not big enougth to put {0} bombs", NumberOfBombs));
			}

			this.NumberOfBombs = numberOfBombs;
			this.GameSize = size;
		}

		public static GameLevel Easy
		{
			get { return new GameLevel(10, new Size(10, 10)) { Name = "Easy" }; }
		}

		public static GameLevel Medium
		{
			get { return new GameLevel(50, new Size(20, 20)) { Name = "Medium"}; }
		}

		public static GameLevel Hard
		{
			get { return new GameLevel(100, new Size(25, 25)) { Name = "Hard" }; }
		}

		public int NumberOfBombs { get; private set; }

		public Size GameSize { get; set; }

		public string Name { get; set; }

	}
}