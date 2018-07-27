using System;

namespace TicTacToe
{
    public class GameBoard
    {
        private LocationMarker[,] Board { get; set; }

        public GameBoard()
        {
            Board = new LocationMarker[3, 3]
            {
                { LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty },
                { LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty },
                { LocationMarker.Empty, LocationMarker.Empty, LocationMarker.Empty }
            };
        }

        public bool MarkLocation(int row, int column, LocationMarker playerMarker)
        {
            if (row > 2 || column > 2 || playerMarker == LocationMarker.Empty)
                return false;

            if (Board[row, column] != LocationMarker.Empty)
                return false;

            Board[row, column] = playerMarker;
            return true;
        }

        public string PrintBoard()
        {
            return "   |   |   " + Environment.NewLine
                + " " + PrintHelper.GetDisplayText(Board[0, 0]) + " | " + PrintHelper.GetDisplayText(Board[0, 1]) + " | " + PrintHelper.GetDisplayText(Board[0, 2]) + " " + Environment.NewLine
                + "___|___|___" + Environment.NewLine
                + "   |   |   " + Environment.NewLine
                + " " + PrintHelper.GetDisplayText(Board[1, 0]) + " | " + PrintHelper.GetDisplayText(Board[1, 1]) + " | " + PrintHelper.GetDisplayText(Board[1, 2]) + " " + Environment.NewLine
                + "___|___|___" + Environment.NewLine
                + "   |   |   " + Environment.NewLine
                + " " + PrintHelper.GetDisplayText(Board[2, 0]) + " | " + PrintHelper.GetDisplayText(Board[2, 1]) + " | " + PrintHelper.GetDisplayText(Board[2, 2]) + " " + Environment.NewLine
                + "   |   |   " + Environment.NewLine;
        }

        public bool IsWinner(LocationMarker playerMarker)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Board[i, 0] == playerMarker && Board[i, 1] == playerMarker && Board[i, 2] == playerMarker)
                {
                    return true;
                }
            }
            for(int i = 0; i< 2; i++)
            {
                if (Board[0, i] == playerMarker && Board[1, i] == playerMarker && Board[2, i] == playerMarker)
                {
                    return true;
                }
            }
            if(Board[0, 0] == playerMarker && Board[1, 1] == playerMarker && Board[2, 2] == playerMarker)
            {
                return true;
            }
            else
                return false;
        }
    }
}
