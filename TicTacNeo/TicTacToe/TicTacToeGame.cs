namespace TicTacToe
{
    public class TicTacToeGame
    {
        public string Id { get; private set; }
        public TicTacToePlayer[] Players { get; private set; }
        public GameBoard GameBoard { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public TicTacToePlayer CurrentPlayer { get { return Players[CurrentPlayerIndex]; } }
        public bool IsGameFull { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool IsGameDraw { get; private set; }

        private TicTacToeGame() { }

        public static TicTacToeGame NewTicTacToeGame(string gameId, Player playerOne)
        {
            return new TicTacToeGame
            {
                Id = gameId,
                Players = new TicTacToePlayer[2] { TicTacToePlayer.NewTicTacToePlayer(playerOne, LocationMarker.O, 0), null },
                GameBoard = GameBoard.NewGameBoard()
            };
        }

        public bool MarkLocation(int row, int column)
        {
            if (!IsGameFull || IsGameOver)
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

            CurrentPlayerIndex = (CurrentPlayer.TurnOrder + 1) % 2;
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

        public bool JoinGame(Player playerTwo)
        {
            if (IsGameFull)
                return false;

            Players[1] = TicTacToePlayer.NewTicTacToePlayer(playerTwo, LocationMarker.X, 1);
            IsGameFull = true;
            return true;
        }
    }
}
