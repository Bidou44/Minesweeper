namespace MinesweeperLib
{
	using System;

	public struct Size
	{
		private readonly int width;
		private readonly int height;

		public Size(int width, int height)
		{
			if (width < 0 || height < 0)
			{
				throw new ArgumentException();
			}

			this.width = width;
			this.height = height;
		}

		public int Width
		{
			get { return this.width; }
		}

		public int Height
		{
			get { return this.height; }
		}

		public override string ToString()
		{
			return String.Format("{0}x{1}", this.width, this.height);
		}
	}
}