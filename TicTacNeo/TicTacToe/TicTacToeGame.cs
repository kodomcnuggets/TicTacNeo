using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int Id { get; private set; }
        public Player[] Players { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public Player CurrentPlayer { get { return Players[CurrentPlayerIndex]; } }
        public bool IsGameOver { get; private set; }
        public bool IsGameDraw { get; private set; }

        private TicTacToeGame() { }

        public static TicTacToeGame NewTicTacToeGame(int id)
        {
            return new TicTacToeGame
            {
                Id = id,
                Players = new Player[2] { Player.NewPlayer(1, LocationMarker.O, 0), Player.NewPlayer(2, LocationMarker.X, 1) },
                CurrentPlayerIndex = 0,
                GameBoard = GameBoard.NewGameBoard()
            };
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

        public bool Update(TicTacToeGame updateGame)
        {
            if (Id != updateGame.Id)
                return false;

            Players = updateGame.Players;
            CurrentPlayerIndex = updateGame.CurrentPlayerIndex;
            GameBoard = updateGame.GameBoard;
            IsGameOver = updateGame.IsGameOver;
            IsGameDraw = updateGame.IsGameDraw;

            return true;
        }
    }
}
