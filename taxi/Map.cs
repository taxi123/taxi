using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace taxi
{
    /// <summary>
    /// <para>generates points,taxipoints and draws them on the map</para>
    /// <para>also draws moveable objects like taxis and clients</para>
    /// </summary>
    class Map
    {
        private List<Point> crossings;
        private List<Point> points;
        private double xachsis = 495;
        private double yachsis = 495;

        Random rndm;

        private System.Windows.Controls.Canvas map;
        private System.Windows.Controls.Canvas move;
        private MainWindow window;

        public Map(MainWindow win)
        {
            rndm = new Random();
            this.window = win;
            this.map = window.mapCanvas;
            this.move = window.moveableCanvas;
            
            clear(true);
            createValidPoints();

            int taxiStandInt;
            taxiStandInt = Convert.ToInt32(window.TaxiStandInput.Text);
            taxiStandInt = int.Parse(window.TaxiStandInput.Text);

            List<Point> usedPoints = new List<Point>();

            for (int i = 0; i < taxiStandInt; i++)
            {
                var rectangle = new System.Windows.Shapes.Rectangle()
                {
                    Width = 15,
                    Height = 20,
                    Stroke = Brushes.Black,
                    Fill = Brushes.DeepSkyBlue
                };

                Point tmp = null;
                while (tmp == null || usedPoints.Contains(tmp))
                {
                    tmp = points.ElementAt(rndm.Next(0, points.Count));
                }
                System.Windows.Controls.Canvas.SetLeft(rectangle, rndm.Next(0, 5) * 100 + 20);
                System.Windows.Controls.Canvas.SetTop(rectangle, rndm.Next(0, 5) * 100 - 10);
                map.Children.Add(rectangle);
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
                    Point check = this.points.Find(x => x.getX() == j && x.getY() == i);
                    if (check == null)
                    {
                        this.points.Add(new taxi.Point(j, i));
                    }
                    
                }
            }
        }

        public List<Point> getValidPoints()
        {
            return this.points;
        }

        public void clear(bool complete)
        {
            move.Children.Clear();
            if (complete) map.Children.Clear();

        }
        public void redraw()
        {
            clear(false);
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
                map.Children.Add(ellipse);
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
                map.Children.Add(ellipse);

            }

        }
    }
}

