namespace TicTacToe
{
    public class GameBoard
    {
        public LocationMarker[] Board { get; private set; }

        private GameBoard() { }

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
}
