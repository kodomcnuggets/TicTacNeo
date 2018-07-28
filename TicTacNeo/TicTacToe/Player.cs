using System;

namespace TicTacToe
{
    public class Player
    {
        public Guid Id { get; private set; }
        public LocationMarker Marker { get; private set; }
        public int Index { get; private set; }

        public Player(LocationMarker marker, short index)
        {
            Id = Guid.NewGuid();
            Marker = marker;
            Index = index;
        }

        public string ToJson()
        {
            return "{"
                + " \"Id\": \"" + Id.ToString() + "\""
                + ", \"Marker\": " + ((short)Marker).ToString()
                + ", \"Index\": " + Index.ToString()
                + " }";
        }
    }
}
