using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taxi
{
    /// <summary>  
    /// <para>manages the moveable objects, clients and client-requests</para>
    /// </summary>
    class Central
    {
        private List<Taxi> taxis;
        private List<TaxiPoint> taxiPoints;
        private int deniedRequests;
        private Map map;
        private MainWindow window;

        System.Timers.Timer ticker;
        public bool running = false;

        public Central(MainWindow window)
        {
            this.window = window;
            this.map = map = new Map(window); ;
        }
        public bool isRunning()
        {
            return running;
        }
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

            return new TaxiPoint(point, 1);
        }

        public void createClient()
        {

        }

        public void addTaxi(Taxi taxi)
        {
            this.taxis.Add(taxi);
        }

        public void addTaxiPoint(TaxiPoint taxiPoint)
        {
            this.taxiPoints.Add(taxiPoint);
        }
        public void clearMap(bool complete)
        {
            map.clear(complete);
        }
        public void startSimulation()
        {
            ticker = new System.Timers.Timer();
            ticker.Elapsed += new System.Timers.ElapsedEventHandler(tickEvent);
            ticker.Interval = 1000;
            ticker.Start();
        }
        private void tickEvent(object source, System.Timers.ElapsedEventArgs e)
        {

            map.redraw();
        }

        public void clearSimulation()
        {
            string messageBoxText = "Wollen Sie die Simulation abbrechen?";
            string caption = "SupaDoopaTaxiPoopa";
            System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNoCancel;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;

            if (!central.isRunning() || central.isRunning() && (System.Windows.MessageBox.Show(messageBoxText, caption, button, icon) == System.Windows.MessageBoxResult.Yes))
            {
                central.clearMap(true);
                ticker.Stop();
                running = false;
                if (window.TaxiStandInput.Text.Length > 0 && window.conurbationCountInput.Text.Length > 0)
                {
                    window.generateStands.IsEnabled = false;
                }
            }
        }
    }
}
