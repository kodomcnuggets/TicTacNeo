using System;

namespace TicTacToe
{
    public class TicTacToePrinter
    {
        private TicTacToeGame Game { get; set; }

        public TicTacToePrinter(TicTacToeGame game)
        {
            Game = game;
        }

        public static string GetPrintText(LocationMarker marker)
        {
            switch (marker)
            {
                case LocationMarker.Empty:
                    return " ";
                case LocationMarker.O:
                    return "O";
                case LocationMarker.X:
                    return "X";
                default:
                    return string.Empty;
            }
        }

        public string PrintBoard()
        {
            return "   |   |   " + Environment.NewLine
                + " " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[0]) + " | " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[1]) + " | " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[2]) + " " + Environment.NewLine
                + "___|___|___" + Environment.NewLine
                + "   |   |   " + Environment.NewLine
                + " " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[3]) + " | " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[4]) + " | " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[5]) + " " + Environment.NewLine
                + "___|___|___" + Environment.NewLine
                + "   |   |   " + Environment.NewLine
                + " " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[6]) + " | " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[7]) + " | " + TicTacToePrinter.GetPrintText(Game.GameBoard.Board[8]) + " " + Environment.NewLine
                + "   |   |   " + Environment.NewLine;
        }

        public string PrintWinner()
        {
            return !Game.IsGameOver || Game.IsGameDraw ? "NA" : TicTacToePrinter.GetPrintText(Game.CurrentPlayer.Marker);
        }
    }
}
