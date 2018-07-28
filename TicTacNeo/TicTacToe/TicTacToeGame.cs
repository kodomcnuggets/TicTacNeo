using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public Guid Id { get; private set; }
        public Player[] Players { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public bool IsGameOver { get; private set; }

        public TicTacToeGame()
        {
            Id = new Guid();
            Players = new Player[2] { new Player(LocationMarker.O, 0), new Player(LocationMarker.X, 1) };
            CurrentPlayer = Players[0];
            GameBoard = new GameBoard();
        }

        public bool MarkLocation(int row, int column)
        {
            if (IsGameOver)
                return false;

            if (!GameBoard.MarkLocation(row, column, CurrentPlayer.Marker))
                return false;

            if (GameBoard.IsWinner(CurrentPlayer.Marker))
            {
                IsGameOver = true;
                return true;
            }

            if (!GameBoard.IsALocationEmpty())
            {
                IsGameOver = true;
                return true;
            }

            CurrentPlayer = Players[(CurrentPlayer.TurnOrder + 1) % 2];
            return true;
        }

        public string PrintBoard()
        {
            return GameBoard.PrintBoard();
        }
    }
}
