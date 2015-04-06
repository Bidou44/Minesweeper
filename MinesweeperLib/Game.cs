namespace MinesweeperLib
{
	using System;

	using MinesweeperLib.Cells;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.Helpers;

	public class Game
	{
		private readonly IBoard board = null;

		private bool? isWinner = null;
		private int playedCells = 0;

		public Game(IBoard board)
		{
			this.board = board;
		}

		public bool IsFinished { get; private set; }

		public bool IsWinner { get { return this.isWinner == true; } }

		public GameConfiguration GameConfiguration
		{
			get { return this.board.GameConfiguration; }
		}

		public void Play(Coordinate coord)
		{
			if (!this.IsFinished)
			{
				Cell cell = this.board[coord];
				if (!cell.IsPlayed)
				{
					this.Play(cell);

					Size gameSize = this.GameConfiguration.Level.GameSize;
					if (this.playedCells >= gameSize.Width * gameSize.Height - this.GameConfiguration.Level.NumberOfBombs)
					{
						this.FinishGame(isWinner != false);
					}
				}
			}
		}

		internal IBoard Board
		{
			get { return this.board; }
		}

		private void FinishGame(bool hasWin)
		{
			this.IsFinished = true;
			this.isWinner = hasWin;
		}

		private void Play(Cell cell)
		{
			this.SetPlayed(cell);
			if (cell.CellValue.IsBomb)
			{
				this.FinishGame(false);
			}
			else
			{
				if (!cell.CellValue.NumberOfBombAround.HasValue)
				{
					foreach (Coordinate neighbor in cell.Coordinate.GetAllNeighbors())
					{
						if (this.GameConfiguration.Level.GameSize.Contains(neighbor))
						{
							this.CheckNeighbor(neighbor);
						}
					}
				}
			}
		}

		private void SetPlayed(Cell cell)
		{
			if (!cell.IsPlayed)
			{
				cell.IsPlayed = true;
				this.playedCells++;
			}
		}

		private void CheckNeighbor(Coordinate neighbor)
		{
			Cell neighborCell = this.board[neighbor];
			if (!neighborCell.CellValue.IsBomb)
			{
				if (neighborCell.CellValue.NumberOfBombAround.HasValue)
				{
					this.SetPlayed(neighborCell);
				}
				else
				{
					this.Play(neighbor); // Indirectly recurse
				}
			}
		}

		#region Dump

		public void Dump()
		{
			for (int i = -2; i < this.board.Size.Height; i++)
			{
				Console.WriteLine();
				if (i >= 0)
				{
					Console.Write(i + "║");				
				}

				for (int j = 0; j < this.board.Size.Width; j++)
				{
					if (i == -2)
					{
						Console.Write((j == 0 ? ("  " + j) : j.ToString()));
					}
					else if (i == -1)
					{
						Console.Write(j == 0 ? ("  " + "═") : "═");
					}
					else
					{
						Cell cell = this.board[new Coordinate(j, i)];
						CellValueBase cellValue = cell.CellValue;
						string symbol = !cell.IsPlayed ? "░" : (cellValue.IsBomb ? "B" : (cellValue.NumberOfBombAround.HasValue ? cellValue.NumberOfBombAround.ToString() : " "));
						Console.Write(symbol);
					}
				}
			}
		}

		#endregion
	}
}