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
        MainWindow window;
        Map map;
        System.Timers.Timer ticker;
        public bool running = false;
        public Controller(MainWindow window)
        {
            this.window = window;
        }
        /// <summary>
        ///     creates a new simulation and asks if the current one should be discarded
        /// </summary>
        public void createNewSimulation(System.Windows.Controls.Canvas mapCanvas)
        {
            string messageBoxText = "Es läuft derzeit eine Simulation. Wollen Sie wirklich eine neue Simulation starten?";
            string caption = "SupaDoopaTaxiPoopa";
            System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNoCancel;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;

            if (!running || running && (System.Windows.MessageBox.Show(messageBoxText, caption, button, icon) == System.Windows.MessageBoxResult.Yes))
            {
                map = new Map(window, mapCanvas);
                startSimulation();
                running = true;
                window.generateStands.IsEnabled = false;
            }

        }
        public void clearSimulation()
        {
            string messageBoxText = "Es läuft derzeit eine Simulation. Wollen Sie wirklich eine neue Simulation starten?";
            string caption = "SupaDoopaTaxiPoopa";
            System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNoCancel;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;

            if (!running || running && (System.Windows.MessageBox.Show(messageBoxText, caption, button, icon) == System.Windows.MessageBoxResult.Yes))
            {
                map.clear();
                ticker.Stop();
                running = false;
                if (window.TaxiStandInput.Text.Length > 0 && window.conurbationCountInput.Text.Length > 0)
                {
                    window.generateStands.IsEnabled = false;
                }
            }
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

        }
    }
}
