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
            bool winner = false;
            while (!winner)
            {

                //TODO get userinput for x,y coords and which user's turn it is
                //bool value for user turn swapping?
                //do{game} while !IsWinner

                game.MarkLocation(0, 0, TicTacToe.LocationMarker.O);
                Console.WriteLine(game.PrintBoard());
                //change this to check for winner true after we get a full game implemented
                if (!game.IsWinner(TicTacToe.LocationMarker.O))
                {
                    Console.WriteLine("Player O did not win");
                    winner = true;
                }


                game.MarkLocation(0, 1, TicTacToe.LocationMarker.X);
                Console.WriteLine(game.PrintBoard());
            } 

            Console.ReadLine();
        }
    }
}
