namespace MinesweeperLib
{
	using System;

	public struct Coordinate
	{
		private readonly int xCoord;
		private readonly int yCoord;

		public Coordinate(int xCoord, int yCoord)
		{
			this.xCoord = xCoord;
			this.yCoord = yCoord;
		}

		public Coordinate Empty
		{
			get { return new Coordinate(0, 0); }
		}

		public int XCoord
		{
			get { return this.xCoord; }
		}

		public int YCoord
		{
			get { return this.yCoord; }
		}

		public Coordinate Add(int x, int y)
		{
			return new Coordinate(this.xCoord + x, this.yCoord + y);
		}

		public static bool operator ==(Coordinate left, Coordinate right)
		{
			return left.XCoord == right.XCoord && left.YCoord == right.YCoord;
		}

		public static bool operator !=(Coordinate left, Coordinate right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Coordinate))
			{
				return false;
			}

			Coordinate comp = (Coordinate)obj;
			return comp.XCoord == this.XCoord && comp.YCoord == this.YCoord;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (this.yCoord * 397) ^ this.xCoord;
			}
		}

		public override string ToString()
		{
			return String.Format("({0};{1})", this.xCoord, this.yCoord);
		}
	}
}