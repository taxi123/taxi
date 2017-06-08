using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }
        
        public int getY()
        {
            return this.y;
        }

        public double getDistance(Point a)
        {
            return Math.Sqrt(Math.Pow((x - a.x), 2) + Math.Pow((y - a.y), 2));
        }

        static void drawPoints()
        {

        }
    }
}
