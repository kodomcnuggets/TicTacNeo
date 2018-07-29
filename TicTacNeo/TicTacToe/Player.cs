using System;

namespace TicTacToe
{
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
}
