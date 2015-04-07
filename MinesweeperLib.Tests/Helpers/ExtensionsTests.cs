namespace MinesweeperLib.Tests.Helpers
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using MinesweeperLib.Common;
	using MinesweeperLib.Helpers;

	[TestClass]
	public class ExtensionsTests
	{
		[TestMethod]
		public void IntInsideInterval()
		{
			Assert.IsTrue(5.InInterval(0, 10));
		}

		[TestMethod]
		public void IntOutsideInterval()
		{
			Assert.IsTrue((-10).NotInInterval(-20, -12));
		}

		[TestMethod]
		public void IntInsideIntervalBounds()
		{
			Assert.IsTrue(2.InInterval(2, 3));
		}

		[TestMethod]
		public void IntOutsideIntervalBounds()
		{
			Assert.IsTrue(3.NotInInterval(2, 3));
		}

		[TestMethod]
		public void CoordinateInside()
		{
			Assert.IsTrue(new Size(3, 5).Contains(new Coordinate(2, 3)));
		}

		[TestMethod]
		public void CoordinateOutside()
		{
			Assert.IsFalse(new Size(2, 5).Contains(new Coordinate(2, 6)));
		}

		[TestMethod]
		public void CoordinateInsideBorder()
		{
			Assert.IsFalse(new Size(2, 5).Contains(new Coordinate(0, 5)));
		}

		[TestMethod]
		public void IsBetween()
		{
			Assert.IsTrue(new Size(2, 5).IsBetween(new Size(0, 2), new Size(5, 5)));
		}

		[TestMethod]
		public void IsNotBetween()
		{
			Assert.IsTrue(new Size(2, 5).IsNotBetween(new Size(1, 1), new Size(2, 4)));
		}
	}
}