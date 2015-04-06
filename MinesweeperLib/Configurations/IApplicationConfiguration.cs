namespace MinesweeperLib.Configurations
{
	public interface IApplicationConfiguration
	{
		Size MinGameSize { get; }

		Size MaxGameSize { get; }
	}
}