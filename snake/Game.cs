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
        private readonly Position snakeMain;
        private int dX = 0, dY = 0;
        private bool canChangeX = true, canChangeY = true;

        private string berry = "+";
        private int berryColX, berryRowY;
        private bool berryExists = false;

        private string[,] map;
        private int mapCols, mapRows;

        public Game(int cols, int rows)
        {
            mapCols = cols;
            mapRows = rows;
            map = new string[rows, cols];
            
            snake.Add(new Position(cols / 2, rows / 2));//Trying to set the snake's starting position to the middle
            snakeMain = snake[0];

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
            Clear();

            if (snakeMain.X == berryColX && snakeMain.Y == berryRowY)
            {
                AddBody();
                berryExists = false;
            }

            SpawnBerry();

            MoveSnake();
            
            for (int i = 0; i < map.GetLength(0); i++)//cycle through rows
            {
                for (int j = 0; j < map.GetLength(1); j++)//cycle through cols
                {
                    Position initialSnake = snake[snake.Count - 1];
                    if (SnakeExists(j, i))
                    {
                        map[i, j] = snakeChar;
                    }
                    else if (initialSnake.getPastX() == j && initialSnake.getPastY() == i) map[i, j] = " ";
                    Write(map[i, j]);

                }
                Console.WriteLine();
            }
            
        }

        public void Input()
        {
            if (KeyAvailable)
            {
                ConsoleKeyInfo key = ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (canChangeY)
                        {
                            dY = -1;
                            dX = 0;
                            canChangeX = true;
                            canChangeY = false;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (canChangeY)
                        {
                            dY = 1;
                            dX = 0;
                            canChangeX = true;
                            canChangeY = false;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (canChangeX)
                        {
                            dY = 0;
                            dX = -1;
                            canChangeX = false;
                            canChangeY = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (canChangeX)
                        {
                            dY = 0;
                            dX = 1;
                            canChangeX = false;
                            canChangeY = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        void MoveSnake()
        {
            snakeMain.X += dX;
            snakeMain.Y += dY;
            for (int i = 1; i < snake.Count; i++)
            {
                snake[i].X = snake[i - 1].getPastX();
                snake[i].Y = snake[i - 1].getPastY();
            }
        }

        void AddBody()
        {
            int lastSnakePart = snake.Count - 1;
            snake.Add(new Position(snake[lastSnakePart].X, snake[lastSnakePart].Y));
        }

        bool SnakeExists(int cols, int rows) //cols rows
        {
            for(int i = 0; i < snake.Count; i++)
            {
                if (snake[i].X == cols && snake[i].Y == rows) return true;
            }
            return false;
        }

        void RandomizeBerryPos()
        {
            Random randCol = new Random();
            Random randRow = new Random();

            berryColX = randCol.Next(1, mapCols - 1);
            berryRowY = randRow.Next(1, mapRows - 1);
        }

        void SpawnBerry()
        {
            if (berryExists == false) 
            {
                do
                {
                    RandomizeBerryPos();
                    map[berryRowY, berryColX] = berry;
                } while (SnakeExists(berryColX, berryRowY));
                berryExists = true;
            }
            
        }
        
    }
}
