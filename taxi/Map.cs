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
        private List<Point> points;
        private double xachsis = 495;
        private double yachsis = 495;

        Random rndm;

        private System.Windows.Controls.Canvas canvas;

        public Map(MainWindow window, System.Windows.Controls.Canvas mapCanvas)
        {
            rndm = new Random();
            this.canvas = mapCanvas;
            canvas.Children.Clear();

            int taxiStandInt;
            taxiStandInt = Convert.ToInt32(window.TaxiStandInput.Text);
            taxiStandInt = int.Parse(window.TaxiStandInput.Text);

            for (int i = 0; i < taxiStandInt; i++)
            {
                var rectangle = new System.Windows.Shapes.Rectangle()
                {
                    Width = 15,
                    Height = 20,
                    Stroke = Brushes.Black,
                    Fill = Brushes.DeepSkyBlue
                };
                System.Windows.Controls.Canvas.SetLeft(rectangle, rndm.Next(0, 5) * 100 + 20);
                System.Windows.Controls.Canvas.SetTop(rectangle, rndm.Next(0, 5) * 100 - 10);
                canvas.Children.Add(rectangle);
            }

            int partyInt;
            partyInt = Convert.ToInt32(window.conurbationCountInput.Text);
            partyInt = int.Parse(window.conurbationCountInput.Text);

            for (int i = 0; i < partyInt; i++)
            {
                var ellipse = new System.Windows.Shapes.Ellipse()
                {
                    Width = 20,
                    Height = 20,
                    Stroke = Brushes.Black,
                    Fill = Brushes.OrangeRed
                };
                System.Windows.Controls.Canvas.SetLeft(ellipse, rndm.Next(0, 5) * 100 - 10);
                System.Windows.Controls.Canvas.SetTop(ellipse, rndm.Next(0, 5) * 100 - 10);
                canvas.Children.Add(ellipse);
            }

            for (int i = 0; i < 20; i++)
            {
                var ellipse = new System.Windows.Shapes.Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.White,
                    Fill = Brushes.LawnGreen
                };
                Task.Delay(rndm.Next(0, 5) * 1000);
                System.Windows.Controls.Canvas.SetLeft(ellipse, rndm.Next(1, 4) * 100 - 2.5);
                System.Windows.Controls.Canvas.SetTop(ellipse, rndm.Next(1, 4) * 100 - 2.5);
                canvas.Children.Add(ellipse);

            }
        }

        public void createValidPoints()
        {
            this.points = new List<Point>();
            int intervall = 100;

            for (int i = 0; i <= this.xachsis; i = i + intervall)
            {
                if (i == 100) i = 95;
                for (int j = 0; j <= this.yachsis; j++)
                {
                    this.points.Add(new taxi.Point(i, j));
                }
            }

            for (int i = 0; i <= this.yachsis; i = i + intervall)
            {
                if (i == 100) i = 95;
                for (int j = 0; j <= this.xachsis; j++)
                {
                    this.points.Add(new taxi.Point(j, i));
                }
            }
        }

        public List<Point> getValidPoints()
        {
            return this.points;
        }

        public void clear()
        {
            canvas.Children.Clear();

        }

    }
}

