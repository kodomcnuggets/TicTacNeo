using System;

namespace TicTacToe
{
    public class Player
    {
        public Guid Id { get; private set; }
        public LocationMarker Marker { get; private set; }
        public short TurnOrder { get; private set; }

        public Player(LocationMarker marker, short turnOrder)
        {
            Id = new Guid();
            Marker = marker;
            TurnOrder = turnOrder;
        }
    }
}
