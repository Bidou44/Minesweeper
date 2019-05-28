namespace MinesweeperLib.Common
{
	using System;

	public struct Coordinate
	{
        public Coordinate(int xCoord, int yCoord)
		{
			this.XCoord = xCoord;
			this.YCoord = yCoord;
		}

		public Coordinate Empty => new Coordinate(0, 0);

        public int XCoord { get; }

        public int YCoord { get; }

        public Coordinate Add(int x, int y)
		{
			return new Coordinate(this.XCoord + x, this.YCoord + y);
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
				return (this.YCoord * 397) ^ this.XCoord;
			}
		}

		public override string ToString()
		{
			return $"({this.XCoord};{this.YCoord})";
		}
	}
}