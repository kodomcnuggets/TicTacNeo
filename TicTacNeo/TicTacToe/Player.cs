namespace TicTacToe
{
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
}
