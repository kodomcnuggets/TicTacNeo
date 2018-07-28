using System;

namespace ConsoleInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new TicTacToe.TicTacToeGame();
            Console.WriteLine(game.PrintBoard());

            game.MarkLocation(0, 0);
            Console.WriteLine(game.PrintBoard());

            game.MarkLocation(0, 1);
            Console.WriteLine(game.PrintBoard());

            game.MarkLocation(2, 1);
            Console.WriteLine(game.PrintBoard());

            game.MarkLocation(2, 2);
            Console.WriteLine(game.PrintBoard());

            Console.ReadLine();
        }
    }
}
