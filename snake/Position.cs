using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Position
    {
        private int currX;
        private int currY;

        private int pastX;
        private int pastY;

        public Position(int cols, int rows)
        {
            currX = cols;
            currY = rows;
        }

        public int X {
            get { return currX; }
            set
            {
                pastX = currX;
                currX = value;
            }
        }

        public int Y
        {
            get { return currY; }
            set
            {
                pastY = currY;
                currY = value;
            }
        }

        public int getPastX() { return pastX; }
        public int getPastY() { return pastY; }
    }
}
