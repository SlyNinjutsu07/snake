using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace snake
{
    internal class Game
    {
        public List<string> snake;
        string[,] map;// = new string[10,20]; //row, col

        public Game(int l, int w)
        {
            Length = l;
            Width = w;

            map = new string[Length,Width];

            snake = ["█"];

            for(int row = 0; row < map.GetLength(0); row++)
            {
                for(int col = 0; col < map.GetLength(1); col++)
                {
                    if ((col > 0 && col < map.GetLength(1) - 1) && 
                        (row > 0 && row < map.GetLength(0) - 1)) map[row, col] = " ";
                    else map[row, col] = "#";
                }
            }

            
            PrintMap();
        }

        void PrintMap()
        {
            for(int col = 0; col < map.GetLength(0); col++)
            {
                for(int row = 0; row < map.GetLength(1); row++) Write(map[col, row]);
                WriteLine();
            }
        }

        void Grow()
        {
            snake.Add("█");
        }

        int Length { get; set; }
        int Width {  get; set; }
    }
}
