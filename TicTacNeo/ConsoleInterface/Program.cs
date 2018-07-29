using System;
using TicTacToe;

namespace ConsoleInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var playerOne = Player.NewPlayer("1");
            var game = TicTacToeGame.NewTicTacToeGame("1", playerOne);

            var playerTwo = Player.NewPlayer("2");
            game.JoinGame(playerTwo);

            var gamePrinter = new TicTacToePrinter(game);
            Console.WriteLine(gamePrinter.PrintBoard());
            Console.ReadLine();

            game.MarkLocation(0, 0);
            Console.WriteLine(gamePrinter.PrintBoard());
            Console.ReadLine();

            game.MarkLocation(0, 1);
            Console.WriteLine(gamePrinter.PrintBoard());
            Console.ReadLine();

            game.MarkLocation(1, 0);
            Console.WriteLine(gamePrinter.PrintBoard());
            Console.ReadLine();

            game.MarkLocation(2, 1);
            Console.WriteLine(gamePrinter.PrintBoard());
            Console.ReadLine();

            game.MarkLocation(2, 0);
            Console.WriteLine(gamePrinter.PrintBoard());
            Console.ReadLine();

            Console.WriteLine("Is game over?: " + game.IsGameOver);
            Console.WriteLine("Winner: " + gamePrinter.PrintWinner());
            Console.ReadLine();
        }
    }
}
