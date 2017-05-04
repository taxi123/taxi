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
            if (hasCapacity()) this.taxis.Add(taxi);
        }

        public void dropTaxis(Taxi taxi)
        {
            this.taxis.Remove(taxi);
        }

        public Boolean hasCapacity()
        {
            return currentCapacity < capacity;
        }
    }
}
