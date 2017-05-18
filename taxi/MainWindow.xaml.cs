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
using System.Windows.Media;
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
        Controller controller = new Controller();

        Random rndm;

        public MainWindow()
        {
            InitializeComponent();

            rndm = new Random();
            generateStands.IsEnabled = false;
        }

        private void click_close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void click_new(object sender, RoutedEventArgs e)
        {
            controller.createNewSimulation();
        }

        private void generateStands_Click(object sender, RoutedEventArgs e)
        {
            mapCanvas.Children.Clear();

            int taxiStandInt;
            taxiStandInt = Convert.ToInt32(TaxiStandInput.Text);
            taxiStandInt = int.Parse(TaxiStandInput.Text);

            for (int i = 0; i < taxiStandInt; i++)
            {
                var rectangle = new Rectangle() {
                    Width = 15,
                    Height = 20,
                    Stroke = Brushes.Black,
                    Fill = Brushes.DeepSkyBlue
                };
                Canvas.SetLeft(rectangle, rndm.Next(0, 5) * 100 + 20);
                Canvas.SetTop(rectangle, rndm.Next(0, 5) * 100 - 10);
                mapCanvas.Children.Add(rectangle);

                Thread.Sleep(100);
            }

            int partyInt;
            partyInt = Convert.ToInt32(conurbationCountInput.Text);
            partyInt = int.Parse(conurbationCountInput.Text);

            for (int i = 0; i < partyInt; i++)
            {
                var ellipse = new Ellipse() {
                    Width = 20,
                    Height = 20,
                    Stroke = Brushes.Black,
                    Fill = Brushes.OrangeRed
                };
                Canvas.SetLeft(ellipse, rndm.Next(0, 5) * 100 - 10);
                Canvas.SetTop(ellipse, rndm.Next(0, 5) * 100 - 10);
                mapCanvas.Children.Add(ellipse);

                Thread.Sleep(100);
            }

            for (int i = 0; i < 20; i++)
            {
                var ellipse = new Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.White,
                    Fill = Brushes.LawnGreen
                };
                Task.Delay(rndm.Next(0, 5) * 1000);
                Canvas.SetLeft(ellipse, rndm.Next(1, 4) * 100 - 2.5);
                Canvas.SetTop(ellipse, rndm.Next(1, 4) * 100 - 2.5);
                mapCanvas.Children.Add(ellipse);

                Thread.Sleep(100);

            }

            MessageBox.Show("Punkte erfolgreich eingezeichnet!");
        }

        private void TaxiStandInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TaxiStandInput.Text.Length > 0 && conurbationCountInput.Text.Length > 0)
            {
                generateStands.IsEnabled = true;
            } else
            {
                generateStands.IsEnabled = false;
            }
        }

        private void conurbationCountInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TaxiStandInput.Text.Length > 0 && conurbationCountInput.Text.Length > 0)
            {
                generateStands.IsEnabled = true;
            } else
            {
                generateStands.IsEnabled = false;
            }
        }
    }
}
