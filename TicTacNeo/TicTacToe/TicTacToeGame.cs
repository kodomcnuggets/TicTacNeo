using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public Guid Id { get; private set; }
        public Player[] Players { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public Player CurrentPlayer { get { return Players[CurrentPlayerIndex]; } }
        public bool IsGameOver { get; private set; }
        public bool IsGameDraw { get; private set; }

        public TicTacToeGame()
        {
            Id = Guid.NewGuid();
            Players = new Player[2] { new Player(LocationMarker.O, 0), new Player(LocationMarker.X, 1) };
            CurrentPlayerIndex = 0;
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
                IsGameDraw = true;
                return true;
            }

            CurrentPlayerIndex = (CurrentPlayer.Index + 1) % 2;
            return true;
        }

        public string PrintBoard()
        {
            return GameBoard.PrintBoard();
        }

        public string ToJson()
        {
            return "{"
                + " \"Id\": \"" + Id.ToString() + "\""
                + ", \"Players\": [ " + Players[0].ToJson() + ", " + Players[1].ToJson() + " ]"
                + ", \"GameBoard\": " + GameBoard.ToJson()
                + ", \"CurrentPlayerIndex\": " + CurrentPlayerIndex.ToString()
                + ", \"IsGameOver\": " + IsGameOver.ToString()
                + ", \"IsGameDraw\": " + IsGameDraw.ToString()
                + " }";
        }
    }
}
