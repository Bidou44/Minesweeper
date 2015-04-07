namespace MinesweeperLib.GameRules
{
	public interface IGameSerializer
	{
		string Save(IGame game);

		IGame Load(string game);
	}
}