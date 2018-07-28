using System;
using System.Linq;

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

        public bool IsALocationEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == LocationMarker.Empty)
                        return true;
                }
            }

            return false;
        }
    }
}
