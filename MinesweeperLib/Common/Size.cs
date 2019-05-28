namespace MinesweeperLib.Common
{
	using System;

	public struct Size
	{
		private readonly int width;
		private readonly int height;

		public Size(int width, int height)
		{
			if (width < 0)
			{
				throw new ArgumentException("The width must be a positive number", nameof(width));
			}

			if (height < 0)
			{
				throw new ArgumentException("The height must be a positive number", nameof(height));
			}

			this.width = width;
			this.height = height;
		}

		public int Width => this.width;

        public int Height => this.height;

        public override string ToString()
		{
			return $"{this.width}x{this.height}";
		}
	}
}