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
        private string snakeChar = "█";
        private int snakeX, snakeY;
        private int dX, dY;

        private string apple = "o";

        string[,] map;// = new string[10,20]; //row, col

        public Game(int l, int w)
        {
            //Set length and width size
            Length = l;
            Width = w;

            //Snake starting position
            snakeX = w / 2;//width is the # of cols
            snakeY = l / 2;//length is the # of rows
            //Switch between 1 and 0 and -1
            dX = 0;//x velocity
            dY = 0;//y velocity

            map = new string[Length,Width];

            snake = ["█"];

            //Setting up the map
            for(int row = 0; row < map.GetLength(0); row++)
            {
                for(int col = 0; col < map.GetLength(1); col++)
                {
                    if ((col > 0 && col < map.GetLength(1) - 1) && 
                        (row > 0 && row < map.GetLength(0) - 1)) map[row, col] = " ";
                    else map[row, col] = "#";
                }
            }

        }

        public void PrintMap()
        {
            map[snakeY, snakeX] = snake[0]; //y, x = l, w
            for (int col = 0; col < map.GetLength(0); col++)
            {
                for (int row = 0; row < map.GetLength(1); row++) Write(map[col, row]);
                WriteLine();
            }
        }
        
        public void ReadInput()
        {
            switch (Console.ReadKey())
            {

            }
        }

        public int Length { get; set; }
        public int Width {  get; set; }
    }
}
