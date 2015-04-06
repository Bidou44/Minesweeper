namespace MinesweeperLib.Configurations
{
	public class ApplicationConfiguration : IApplicationConfiguration
	{
		private static ApplicationConfiguration applicationConfiguration = null;

		private ApplicationConfiguration()
		{
		}

		// Caution: This singleton is not thread safe
		public static ApplicationConfiguration Current
		{
			get { return applicationConfiguration ?? (applicationConfiguration = new ApplicationConfiguration()); }
		}

		public Size MinGameSize
		{
			get { return new Size(10, 10); }
		}

		public Size MaxGameSize
		{
			get { return new Size(100, 100); }
		}
	}
}