using snake;
using System;
using static System.Console;

public class Program
{
    public static void Main(string[] args)
    {
        Game g = new Game(10,20);

        g.PrintMap();

        ReadKey();
    }
}