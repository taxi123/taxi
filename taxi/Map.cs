using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace taxi
{
    class Map
    {
        private List<Point> crossings;
        private List<Point> streets;
        private double xachsis;
        private double yachsis;

        private System.Windows.Controls.Canvas canvas;

        public Map(Controller controller, System.Windows.Controls.Canvas mapCanvas)
        {
            this.canvas = mapCanvas;
            canvas.Children.Clear();

            int taxiStandInt;
            taxiStandInt = Convert.ToInt32(TaxiStandInput.Text);
            taxiStandInt = int.Parse(TaxiStandInput.Text);

            for (int i = 0; i < taxiStandInt; i++)
            {
                var rectangle = new Rectangle()
                {
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
                var ellipse = new Ellipse()
                {
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
    }
}
