﻿using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System.Numerics;

namespace TicTacToeContract
{
    public class TicTacToeContract : SmartContract
    {
        #region Models - Do not change here; Change in TicTacToe project, then copy here

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
            public string Id { get; protected set; }

            protected Player() { }

            public static Player NewPlayer(string id)
            {
                return new Player
                {
                    Id = id
                };
            }
        }

        public class TicTacToePlayer : Player
        {
            public LocationMarker Marker { get; private set; }
            public int TurnOrder { get; private set; }

            private TicTacToePlayer() { }

            public static TicTacToePlayer NewTicTacToePlayer(Player player, LocationMarker marker, int turnOrder)
            {
                return new TicTacToePlayer
                {
                    Id = player.Id,
                    Marker = marker,
                    TurnOrder = turnOrder
                };
            }
        }

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

        public class ContractResult
        {
            public bool OperationResult { get; private set; }
            public string Error { get; private set; }
            public TicTacToeGame Game { get; private set; }

            private ContractResult() { }

            public static ContractResult NewContractResult(bool operationResult, string error)
            {
                return new ContractResult
                {
                    OperationResult = operationResult,
                    Error = error
                };
            }

            public static ContractResult NewContractResult(bool operationResult, string error, TicTacToeGame game)
            {
                return new ContractResult
                {
                    OperationResult = operationResult,
                    Error = error,
                    Game = game
                };
            }
        }

        #endregion

        public static string Main(string operation, params object[] args)
        {
            string error = "null";
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "creategame")
                {
                    if (args.Length == 1)
                        return CreateGame((string)args[0]);

                    error = "Incorrect number of args (" + args.Length + ") for operation (" + operation + ")";
                }
                else if (operation == "joingame")
                {
                    if (args.Length == 1)
                        return JoinGame((string)args[1]);

                    error = "Incorrect number of args (" + args.Length + ") for operation (" + operation + ")";
                }
                else if (operation == "marklocation")
                {
                    if (args.Length == 4)
                        return MarkLocation((string)args[0], (string)args[1], (int)args[2], (int)args[3]);

                    error = "Incorrect number of args (" + args.Length + ") for operation (" + operation + ")";
                }
                else if (operation == "fetchgame")
                {
                    if (args.Length == 1)
                        return FetchGame((string)args[0]);

                    error = "Incorrect number of args (" + args.Length + ") for operation (" + operation + ")";
                }
                else
                {
                    error = "Invalid operation (" + operation + ")";
                }
            }

            return ContractResult.NewContractResult(false, error).Serialize().AsString();
        }

        #region Helpers

        private static string GetNextGameId()
        {
            var gameIdBytes = Storage.Get(Storage.CurrentContext, "GameId");
            BigInteger gameId;
            if (gameIdBytes == null || gameIdBytes.Length == 0)
            {
                gameId = 1;
            }
            else
            {
                gameId = gameIdBytes.AsBigInteger();
                gameId = gameId + 1;
            }

            Storage.Put(Storage.CurrentContext, "GameId", gameId);
            return gameId.AsByteArray().AsString();
        }

        private static void OpenGame(TicTacToeGame game)
        {
            Storage.Put(Storage.CurrentContext, "o-" + game.Id, game.Serialize());
        }

        private static void SaveGame(TicTacToeGame game)
        {
            Storage.Put(Storage.CurrentContext, game.Id, game.Serialize());
        }

        private static void CloseGame(TicTacToeGame game)
        {
            Storage.Delete(Storage.CurrentContext, "o-" + game.Id);
            SaveGame(game);
        }

        private static TicTacToeGame GetGame(string gameId)
        {
            var gameBytes = Storage.Get(Storage.CurrentContext, gameId);
            if (gameBytes == null || gameBytes.Length == 0)
                return null;

            return (TicTacToeGame)gameBytes.Deserialize();
        }

        private static Player CastPlayer(string playerJson)
        {
            if (playerJson == null || playerJson == "")
                return null;

            var playerBytes = playerJson.AsByteArray();
            if (playerBytes == null || playerBytes.Length == 0)
                return null;

            return (Player)playerBytes.Deserialize();
        }

        private static TicTacToeGame FindOpenGame()
        {
            var openGames = Storage.Find(Storage.CurrentContext, "o-");
            return (TicTacToeGame)openGames.Value.Deserialize();
        }

        #endregion

        #region Operations

        private static string CreateGame(string playerOneJson)
        {
            var playerOne = CastPlayer(playerOneJson);
            bool operationResult;
            string error;
            TicTacToeGame game;

            if (playerOne == null)
            {
                operationResult = false;
                error = "Invalid Player JSON (" + playerOneJson + ")";
                game = null;
            }
            else
            {
                operationResult = true;
                error = null;
                game = TicTacToeGame.NewTicTacToeGame(GetNextGameId(), playerOne);
                OpenGame(game);
            }

            return ContractResult.NewContractResult(operationResult, error, game).Serialize().AsString();
        }

        private static string JoinGame(string playerTwoJson)
        {
            var game = FindOpenGame();
            var playerTwo = CastPlayer(playerTwoJson);
            bool operationResult;
            string error;

            if (game == null)
            {
                operationResult = false;
                error = "No games available";
            }
            else if (playerTwo == null)
            {
                operationResult = false;
                error = "Invalid Player JSON (" + playerTwo + ")";
            }
            else
            {
                if(game.JoinGame(playerTwo))
                {
                    operationResult = true;
                    error = null;
                    CloseGame(game);
                }
                else
                {
                    operationResult = false;
                    error = "Game full (" + game.Id + ")";
                }
            }

            return ContractResult.NewContractResult(operationResult, error, game).Serialize().AsString();
        }

        private static string MarkLocation(string gameId, string playerId, int row, int column)
        {
            var game = GetGame(gameId);
            bool operationResult;
            string error;

            if (game == null)
            {
                operationResult = false;
                error = "Game not found (" + gameId + ")";
            }
            else if (game.CurrentPlayer.Id != playerId)
            {
                operationResult = false;
                error = "Not player's turn (" + playerId + ")";
            }
            else
            {
                operationResult = true;
                error = null;
                game.MarkLocation(row, column);
                SaveGame(game);
            }

            return ContractResult.NewContractResult(operationResult, error, game).Serialize().AsString();
        }

        private static string FetchGame(string gameId)
        {
            var game = GetGame(gameId);
            bool operationResult;
            string error;

            if (game == null)
            {
                operationResult = false;
                error = "Game not found (" + gameId + ")";
            }
            else
            {
                operationResult = true;
                error = null;
            }

            return ContractResult.NewContractResult(operationResult, error, game).Serialize().AsString();
        }

        #endregion
    }
}
