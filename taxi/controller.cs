using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    /// <summary>  
    /// <para>manages IO actions</para>
    /// <para>every Input action must be performed via this controller</para>
    /// </summary>
    class Controller
    {

        public Controller(){
            
        }
        /// <summary>
        ///     creates a new simulation and asks if the current one should be discarded
        /// </summary>
        public void createNewSimulation()
        {
            
        }
        public void startSimulation()
        {
            System.Timers.Timer ticker = new System.Timers.Timer();
            ticker.Elapsed += new System.Timers.ElapsedEventHandler(tickEvent);
            ticker.Interval = 100;
            ticker.Enabled = true;
        }
        private void tickEvent(object source, System.Timers.ElapsedEventArgs e) {
            
        }
    }
}
