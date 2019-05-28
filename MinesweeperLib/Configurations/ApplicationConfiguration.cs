namespace MinesweeperLib.Configurations
{
	using MinesweeperLib.Common;

	public class ApplicationConfiguration : IApplicationConfiguration
	{
		private static ApplicationConfiguration applicationConfiguration = null;

		private ApplicationConfiguration()
		{
		}

		// Caution: This singleton is not thread safe
		public static ApplicationConfiguration Current => applicationConfiguration ?? (applicationConfiguration = new ApplicationConfiguration());

        public Size MinGameSize => new Size(10, 10);

        public Size MaxGameSize => new Size(100, 100);
    }
}