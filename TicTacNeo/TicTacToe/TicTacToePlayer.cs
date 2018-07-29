namespace TicTacToe
{
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
}
