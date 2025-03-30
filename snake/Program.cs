using snake;
using System;
using static System.Console;

namespace snake
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Game g = new Game(20, 20);

            Console.CursorVisible = false;

        repeat:
            g.Input();
            g.DrawMap();
            Thread.Sleep(g.updateSpeed);
            goto repeat;

        }
    }
}