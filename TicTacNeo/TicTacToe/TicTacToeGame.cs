﻿namespace TicTacToe
{
    public class TicTacToeGame
    {
        public Player[] Players { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public TicTacToeGame()
        {
            Players = new Player[2] { new Player(LocationMarker.O, 0), new Player(LocationMarker.X, 1) };
            CurrentPlayer = Players[0];
            GameBoard = new GameBoard();
        }

        public bool MarkLocation(int row, int column)
        {
            if (!GameBoard.MarkLocation(row, column, CurrentPlayer.Marker))
                return false;

            CurrentPlayer = Players[(CurrentPlayer.Index + 1) % 2];
            return true;
        }

        public string PrintBoard()
        {
            return GameBoard.PrintBoard();
        }
    }
}
