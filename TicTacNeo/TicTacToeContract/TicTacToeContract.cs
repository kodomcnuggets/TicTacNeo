using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace TicTacToeContract
{
    public class TicTacToeContract : SmartContract
    {
        #region DO NOT CHANGE HERE; CHANGE IN TicTacToe PROJECT AND COPY HERE
        public enum LocationMarker
        {
            Empty,
            O,
            X
        }

        public class GameBoard
        {
            public LocationMarker[] Board { get; protected set; }

            protected GameBoard() { }

            public static GameBoard NewGameBoard()
            {
                return new GameBoard()
                {
                    Board = new LocationMarker[9] { LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty }
                };
            }

            public bool MarkLocation(int row, int column, LocationMarker playerMarker)
            {
                if (row > 2 || column > 2 || playerMarker == LocationMarker.Empty)
                    return false;

                var index = row * 3 + column;
                if (Board[index] != LocationMarker.Empty)
                    return false;

                Board[index] = playerMarker;
                return true;
            }

            public bool IsWinner(LocationMarker playerMarker)
            {
                for (int i = 0; i < 2; i++)
                {
                    var rowOffset = i * 3;
                    if (Board[rowOffset] == playerMarker && Board[rowOffset + 1] == playerMarker && Board[rowOffset + 2] == playerMarker)
                        return true;

                    if (Board[i] == playerMarker && Board[3 + i] == playerMarker && Board[6 + i] == playerMarker)
                        return true;
                }

                if (Board[0] == playerMarker && Board[4] == playerMarker && Board[8] == playerMarker)
                    return true;

                if (Board[6] == playerMarker && Board[4] == playerMarker && Board[2] == playerMarker)
                    return true;

                return false;
            }

            public bool IsALocationEmpty()
            {
                for (int i = 0; i < 9; i++)
                {
                    if (Board[i] == LocationMarker.Empty)
                        return true;
                }

                return false;
            }
        }

        public class Player
        {
            public int Id { get; protected set; }
            public LocationMarker Marker { get; protected set; }
            public int Index { get; protected set; }

            protected Player() { }

            public static Player NewPlayer(int id, LocationMarker marker, short index)
            {
                return new Player
                {
                    Id = id,
                    Marker = marker,
                    Index = index,
                };
            }
        }

        public class TicTacToeGame
        {
            public int Id { get; protected set; }
            public Player[] Players { get; protected set; }
            public GameBoard GameBoard { get; protected set; }
            public int CurrentPlayerIndex { get; protected set; }
            public Player CurrentPlayer { get { return Players[CurrentPlayerIndex]; } }
            public bool IsGameOver { get; protected set; }
            public bool IsGameDraw { get; protected set; }

            protected TicTacToeGame() { }

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
        #endregion

        public static string Main(string operation, params object[] args)
        {
            string error = "null";
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "create")
                {
                    if (args.Length == 0)
                        return CreateGame();

                    error = "Incorrect number of args (" + args.Length + ") for operation (" + operation + ")";
                }

                if (operation == "fetch")
                {
                    if (args.Length == 1)
                        return FetchGame((string)args[0]);

                    error = "Incorrect number of args (" + args.Length + ") for operation (" + operation + ")";
                }

                error = "Invalid operation (" + operation + ")";
            }

            return "{ \"ContractResult\": false, \"Errors\": " + error + " }";
        }

        private static string CreateGame()
        {
            var game = TicTacToeGame.NewTicTacToeGame(1);
            SaveGame(game);
            return "{ \"ContractResult\": true, \"Errors\": null, \"Game\": \"" + game.Serialize().AsString() + "\" }";
        }

        private static string SaveGame(TicTacToeGame game)
        {
            Storage.Put(Storage.CurrentContext, game.Id + "", game.Serialize());
            return "{ \"ContractResult\": true, \"Error\": null }";
        }

        private static string FetchGame(string gameId)
        {
            var gameBytes = Storage.Get(Storage.CurrentContext, gameId);
            var gameJson = gameBytes.AsString();
            string contractResult;
            string error;
            if (gameJson == null || gameJson == "")
            {
                contractResult = "false";
                error = "Game not found (" + gameId + ")";
            }
            else
            {
                contractResult = "true";
                error = "null";
            }
            return "{ \"ContractResult\": " + contractResult + ", \"Errors\": " + error + ", \"Game\": \"" + gameJson + "\" }";
        }
    }
}
