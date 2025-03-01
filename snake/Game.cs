using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace snake
{
    internal class Game
    {
        public List<Position> snake = new List<Position>();
        private string snakeChar = "0";

        private string berry = "+";

        private string[,] map;

        public Game(int cols, int rows)
        {
            map = new string[rows, cols];
            snake.Add(new Position(cols / 2, rows / 2));//Trying to set the snake's starting position to the middle

            //Setting up the map
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if ((col > 0 && col < map.GetLength(1) - 1) &&
                        (row > 0 && row < map.GetLength(0) - 1)) map[row, col] = " ";
                    else map[row, col] = "#";
                }
            }
        }

        public void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    //Add an if statement checking if the position currently holds a position from the snake
                }
                Console.WriteLine();
            }
        }

        void AddBody()
        {
            
        }

        
    }
}
