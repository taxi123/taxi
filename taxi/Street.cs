using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class Street
    {
        private Point start;
        private Point end;
        private List<Point> listPoints;
        
        public Street(List<Point> listPoints)
        {
            this.listPoints = listPoints;
            foreach(Point p in this.listPoints)
            {
                 //
            }
        }
    }
}
