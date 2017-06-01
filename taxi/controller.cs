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
        Central central;

        public Controller(MainWindow window)
        {
            this.window = window;
        }
        /// <summary>
        ///     creates a new simulation and asks if the current one should be discarded
        /// </summary>
        public void createNewSimulation()
        {
            string messageBoxText = "Es läuft derzeit eine Simulation. Wollen Sie wirklich eine neue Simulation starten?";
            string caption = "SupaDoopaTaxiPoopa";
            System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNoCancel;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;

            if (central == null || !central.isRunning() || central.isRunning() && (System.Windows.MessageBox.Show(messageBoxText, caption, button, icon) == System.Windows.MessageBoxResult.Yes))
            {
                central = new Central(window);
                central.startSimulation();
                window.generateStands.IsEnabled = false;
                window.Pause.IsEnabled = true;
                window.Stop.IsEnabled = true;
            }

        }
        public void clearSimulation()
        {
            window.Start.IsEnabled = true;
            window.Pause.IsEnabled = false;
            window.Stop.IsEnabled = false;
            central.clearSimulation();
        }
        public void pauseSimulation()
        {
            window.Start.IsEnabled = true;
            window.Pause.IsEnabled = false;
            window.Stop.IsEnabled = true;
        }
        public void continueSimulation()
        {
            window.Start.IsEnabled = false;
            window.Pause.IsEnabled = true;
            window.Stop.IsEnabled = true;
        }
    }
}
