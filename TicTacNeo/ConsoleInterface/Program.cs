using System;

namespace ConsoleInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new TicTacToe.TicTacToeGame();
            Console.WriteLine(game.PrintBoard());
            Console.WriteLine(game.ToJson());
            Console.ReadLine();

            game.MarkLocation(0, 0);
            Console.WriteLine(game.PrintBoard());
            Console.WriteLine(game.ToJson());
            Console.ReadLine();

            game.MarkLocation(0, 1);
            Console.WriteLine(game.PrintBoard());
            Console.WriteLine(game.ToJson());
            Console.ReadLine();

            game.MarkLocation(1, 0);
            Console.WriteLine(game.PrintBoard());
            Console.WriteLine(game.ToJson());
            Console.ReadLine();

            game.MarkLocation(2, 1);
            Console.WriteLine(game.PrintBoard());
            Console.WriteLine(game.ToJson());
            Console.ReadLine();

            game.MarkLocation(2, 0);
            Console.WriteLine(game.PrintBoard());
            Console.WriteLine(game.ToJson());
            Console.ReadLine();

            Console.WriteLine("Is game over?: " + game.IsGameOver);
            Console.WriteLine("Winner: " + (game.IsGameDraw ? "NA" : TicTacToe.PrintHelper.GetDisplayText(game.CurrentPlayer.Marker)));
            Console.WriteLine(game.ToJson());
            Console.ReadLine();
        }
    }
}
