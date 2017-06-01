using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace taxi
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller;

        public MainWindow()
        {
            controller = new Controller(this);

        }
        public System.Windows.Media.ImageSource CanvasBG { get; set; }
        private void click_close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void click_new(object sender, RoutedEventArgs e)
        {
            controller.clearSimulation();
        }

        private void generateStands_Click(object sender, RoutedEventArgs e)
        {
            controller.createNewSimulation(mapCanvas,moveableCanvas);
        }

        private void TaxiStandInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TaxiStandInput.Text.Length > 0 && conurbationCountInput.Text.Length > 0)
            {
                generateStands.IsEnabled = true;
            }
            else
            {
                generateStands.IsEnabled = false;
            }

        }

        private void conurbationCountInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TaxiStandInput.Text.Length > 0 && conurbationCountInput.Text.Length > 0)
            {
                generateStands.IsEnabled = true;
            }
            else
            {
                generateStands.IsEnabled = false;
            }
        }
    }
}
