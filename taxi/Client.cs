using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class Client : IMoveable
    {
        private Point start;
        private Point currentPosition;
        private Point destination;

        public Client(Point start)
        {
            this.start = start;
            currentPosition = start;
        }
        
        public void setDestination(Point destination)
        {
            this.destination = destination;
        }

        public Point getStart()
        {
            return this.start;
        }
        
        public Point getDestination()
        {
            return this.destination;
        }
        public Point getPosition()
        {
            return this.currentPosition;
        }
        public void move(Point p1, Point p2)
        {
          
        }
    }
}
