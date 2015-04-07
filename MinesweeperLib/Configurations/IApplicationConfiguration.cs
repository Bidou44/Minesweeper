namespace MinesweeperLib.Configurations
{
	using MinesweeperLib.Common;

	public interface IApplicationConfiguration
	{
		Size MinGameSize { get; }

		Size MaxGameSize { get; }
	}
}