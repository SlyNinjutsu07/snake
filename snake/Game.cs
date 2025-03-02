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
            snake.Add(new Position((cols / 2)-1, rows / 2));

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
            for (int i = 0; i < map.GetLength(0); i++)//cycle through rows
            {
                for (int j = 0; j < map.GetLength(1); j++)//cycle through cols
                {
                    if(SnakeExists(j, i))
                    {
                        map[i, j] = snakeChar;
                    }
                    Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        void AddBody()
        {
            
        }

        bool SnakeExists(int cols, int rows) //cols rows
        {
            for(int i = 0; i < snake.Count; i++)
            {
                if (snake[i].X == cols && snake[i].Y == rows) return true;
            }
            return false;
        }
        
    }
}
