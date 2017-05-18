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
        Map map;
        bool changed = false;
        public Controller(){}
        /// <summary>
        ///     creates a new simulation and asks if the current one should be discarded
        /// </summary>
        public void createNewSimulation(System.Windows.Controls.Canvas mapCanvas)
        {
            string messageBoxText = "Sie haben ungespeicherte Änderungen. Wollen Sie wirklich eine neue Simulation starten?";
            string caption = "SupaDoopaTaxiPoopa";
            System.Windows.MessageBoxButton button = System.Windows.MessageBoxButton.YesNoCancel;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;

            if (!changed || changed && (System.Windows.MessageBox.Show(messageBoxText, caption, button, icon) == System.Windows.MessageBoxResult.Yes))
            {
                map = new Map(this, mapCanvas);
            }
            
        }
        public getTextField(string identifier)
        {
            System.Windows.Controls.TextBlock;
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
