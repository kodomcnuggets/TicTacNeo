using System;

namespace TicTacToe
{
    public class Player
    {
        public Guid Id { get; private set; }
        public LocationMarker Marker { get; private set; }
        public short Index { get; private set; }

        public Player(LocationMarker marker, short index)
        {
            Id = new Guid();
            Marker = marker;
            Index = index;
        }
    }
}
