﻿namespace MinesweeperLib.GameRules
{
	using System;
	using System.Collections.Generic;

	using MinesweeperLib.Common;
	using MinesweeperLib.Configurations;
	using MinesweeperLib.GameRules.Cells;
	using MinesweeperLib.Helpers;

	public class Game : IGame
	{
		private int playedCells = 0;

		public Game(IBoard board, IGameSerializer gameSerializer)
		{
			this.Board = board;
			this.GameSerializer = gameSerializer;
			this.GameState = GameState.Playing;
		}

		public GameConfiguration GameConfiguration => this.Board.GameConfiguration;

        public GameState GameState { get; private set; }

		public IBoard Board { get; }

		public IGameSerializer GameSerializer { get; }

		public static IGame CreateGame(ApplicationConfiguration appConfig, GameConfiguration gameConfiguration, IEnumerable<Coordinate> bombCoordinates)
		{
			// Composition root
			ICellValueBaseFactory cellValueBaseFactory = new CellValueBaseFactory(bombCoordinates);
			IGameCreator gameCreator = new GameCreator(cellValueBaseFactory, gameConfiguration, appConfig);
			IBoard board = new Board(gameCreator, gameConfiguration);

			Game game = new Game(board, new GameSerializer());
			return game;
		}

		public void Play(Coordinate coord)
		{
			if (this.GameState == GameState.Playing)
			{
				Cell cell = this.Board[coord];
				if (!cell.IsPlayed)
				{
					this.Play(cell);
					this.CheckIfGameIsOver();
				}
			}
		}

		public void Save()
		{
			this.GameSerializer.Save(this);
		}

		private void Play(Cell cell)
		{
			this.SetPlayed(cell);
			if (cell.CellValue.IsBomb)
			{
				this.FinishGame(GameState.FinishedLost);
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

		private void CheckIfGameIsOver()
		{
			Size gameSize = this.GameConfiguration.Level.GameSize;
			if (this.playedCells >= gameSize.Width * gameSize.Height - this.GameConfiguration.Level.NumberOfBombs)
			{
				this.FinishGame(this.GameState == GameState.FinishedLost ? GameState.FinishedLost : GameState.FinishedWon);
			}
		}

		private void FinishGame(GameState gameState)
		{
			this.GameState = gameState;
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
			Cell neighborCell = this.Board[neighbor];
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
			for (int i = -2; i < this.Board.Size.Height; i++)
			{
				Console.WriteLine();
				if (i >= 0)
				{
					Console.Write(i + "║");				
				}

				for (int j = 0; j < this.Board.Size.Width; j++)
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
						Cell cell = this.Board[new Coordinate(j, i)];
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