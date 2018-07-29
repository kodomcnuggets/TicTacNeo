namespace TicTacToe
{
    public class Player
    {
        public int Id { get; protected set; }

        protected Player() { }

        public static Player NewPlayer(int id)
        {
            return new Player
            {
                Id = id
            };
        }
    }
}
