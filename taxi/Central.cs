using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class Central
    {
        private List<Taxi> taxis;
        private List<TaxiPoint> taxiPoints;
        private int deniedRequests;
        private Map map;

        public Boolean checkTaxiAvailable()
        {
            /// blablablalbbal
            return false;
        }

        public TaxiPoint nextTaxiPoint(Client client)
        {
            Point point = client.getStart();
            int shortestDistance = 0;
            TaxiPoint taxiPoint = null;
            foreach(TaxiPoint taxiPoint in taxiPoints)
            {
                Point tpPoint = taxiPoint.getPosition();
                int distance = 0;
                taxiPoint.hasCapacity();
            }

            return new TaxiPoint(point, 1);
        }

        public void addTaxi(Taxi taxi)
        {
            this.taxis.Add(taxi);
        }

        public void addTaxiPoint(TaxiPoint taxiPoint)
        {
            this.taxiPoints.Add(taxiPoint);
        }
    }
}
