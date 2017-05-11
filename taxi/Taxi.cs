using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    class Taxi
    {
        private Client client;
        private State state;
        private Point currentPosition;

        /// <summary>
        /// Client(s) enter(s) the taxi. Client(s) will give information about his(their) destination
        /// </summary>
        /// <param name="clients"></param>
        public void enterTaxi(Client client)
        {
            this.client = client;
        }
    }
}
