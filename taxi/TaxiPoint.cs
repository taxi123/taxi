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

        public TaxiPoint(Point point, int capacity)
        {
            this.point = point;
            this.capacity = capacity;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public List<Taxi> getTaxis()
        {
            return taxis;
        }

        public void addTaxi(Taxi taxi)
        {
            if (hasCapacity()) {
                this.taxis.Add(taxi);
           }
        }

        public Point getPosition()
        {
            return this.point;
        }
        public void dropTaxis(Taxi taxi)
        {
            this.taxis.Remove(taxi);
        }

        public Boolean hasCapacity()
        {
            return taxis.Count < capacity;
        }
    }
}
