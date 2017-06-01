using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class TaxiPoint
    {
        private List<Taxi> taxis;
        private Point point;
        private int capacity;
        private int currentCapacity;

        public TaxiPoint(Point point, int capacity)
        {
            this.point = point;
            this.capacity = capacity;
        }

        public void addTaxi(Taxi taxi)
        {
            if (hasCapacity()) {
                this.taxis.Add(taxi);
                this.currentCapacity++;
           }
        }

        public Point getPosition()
        {
            return this.point;
        }
        public void dropTaxis(Taxi taxi)
        {
            this.taxis.Remove(taxi);
            this.currentCapacity--;
        }

        public Boolean hasCapacity()
        {
            return currentCapacity < capacity;
        }
    }
}
