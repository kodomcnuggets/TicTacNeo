using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleInterface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new TicTacToe.GameBoard();
            Console.WriteLine(game.PrintBoard());

            game.MarkLocation(0, 0, TicTacToe.LocationMarker.O);
            Console.WriteLine(game.PrintBoard());

            game.MarkLocation(0, 1, TicTacToe.LocationMarker.X);
            Console.WriteLine(game.PrintBoard());

            Console.ReadLine();
        }
    }
}
