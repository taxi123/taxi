using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private List<Point> conurbationPoints;
        private List<Client> clients;
        private int deniedRequests;
        private Map map;
        private MainWindow window;
        private int tick = 0;
        private int maxTicks = 200;
        CancellationTokenSource token;
        public bool running = false;

        public Central(MainWindow window)
        {
            this.window = window;
            this.taxis = new List<Taxi>();
            this.taxiPoints = new List<TaxiPoint>();
            this.conurbationPoints = new List<Point>();
            this.clients = new List<Client>();
            deniedRequests = 0;
            this.map = map = new Map(window,this); ;
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

        public void createClients()
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
        public void addConnurbationPoint(Point p)
        {
            conurbationPoints.Add(p);
        }
        public List<Point> getConurbationPoints()
        {
            return conurbationPoints;
        }
        public List<Client> getClients()
        {
            return clients;
        }
        public List<Taxi> getTaxis()
        {
            return taxis;
        }
        public void clearMap(bool complete)
        {
            map.clear(complete);
        }
        public void startSimulation()
        {
            running = true;
            token = new CancellationTokenSource();
            CancellationToken tok = token.Token;
            Task.Run(() =>
            {
                while (!tok.IsCancellationRequested || tick < maxTicks)
                {
                    window.Dispatcher.Invoke((Action)(() => {
                        map.redraw();
                    }));
                    System.Threading.Thread.Sleep(200);
                    tick++;
                }
            },tok);
        }

        public void clearSimulation()
        {
            string messageBoxText = "Wollen Sie die Simulation abbrechen?";
            string caption = "SupaDoopaTaxiPoopa";
            System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNoCancel;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;

            if (!isRunning() || isRunning() && (System.Windows.MessageBox.Show(messageBoxText, caption, button, icon) == System.Windows.MessageBoxResult.Yes))
            {
                map.clear(true);
                token.Cancel();
                running = false;
                if (window.TaxiStandInput.Text.Length > 0 && window.conurbationCountInput.Text.Length > 0)
                {
                    window.generateStands.IsEnabled = false;
                }
            }
        }
    }
}
