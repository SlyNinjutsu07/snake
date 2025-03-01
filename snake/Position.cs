using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Position
    {
        public Position(int cols, int rows)
        {
            X = cols;
            Y = rows;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
