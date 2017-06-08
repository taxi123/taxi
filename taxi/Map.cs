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
        private double xachsis = 500;
        private double yachsis = 500;

        Random rndm;

        private System.Windows.Controls.Canvas map;
        private MainWindow window;
        private Central central;

        public Map(MainWindow win,Central central)
        {
            rndm = new Random();
            this.window = win;
            this.central = central;
            this.map = window.mapCanvas;
            
            clear();
            createValidPoints();

            int taxiStandInt;
            taxiStandInt = Convert.ToInt32(window.TaxiStandInput.Text);
            taxiStandInt = int.Parse(window.TaxiStandInput.Text);

            List<Point> usedPoints = new List<Point>();

            for (int i = 0; i < taxiStandInt; i++)
            {
                var rectangle = new System.Windows.Shapes.Rectangle()
                {
                    Width = 10,
                    Height = 15,
                    Stroke = Brushes.Black,
                    Fill = Brushes.Aqua
                };

                Point tmp = null;
                while (tmp == null || usedPoints.Contains(tmp))
                {
                    tmp = points.ElementAt(rndm.Next(0, points.Count));
                    if (usedPoints.Count == points.Count)
                    {
                        break;
                    }
                }
                if (tmp != null)
                {
                    //TODO: statische Kapazität erweitern auf Input-Feld
                    TaxiPoint tp = new TaxiPoint(tmp,3);
                    central.addTaxiPoint(tp);
                    System.Windows.Controls.Canvas.SetLeft(rectangle, (tmp.getX() - rectangle.Width/2));
                    System.Windows.Controls.Canvas.SetTop(rectangle, (tmp.getY() - rectangle.Height/2));
                    map.Children.Add(rectangle);
                }
            }
            usedPoints = new List<Point>();

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
                Point tmp = null;
                while (tmp == null || usedPoints.Contains(tmp))
                {
                    tmp = points.ElementAt(rndm.Next(0, points.Count));
                    if (usedPoints.Count == points.Count)
                    {
                        break;
                    }
                }
                if (tmp != null)
                {
                    central.addConnurbationPoint(tmp);
                    System.Windows.Controls.Canvas.SetLeft(ellipse, (tmp.getX() - ellipse.Width/2));
                    System.Windows.Controls.Canvas.SetTop(ellipse, (tmp.getY() - ellipse.Height/2));
                    map.Children.Add(ellipse);
                }
                
            }
            foreach(TaxiPoint tp in central.getTaxiPoints())
            {
                for (int i = 0; i < tp.getCapacity(); i++)
                {
                    var rectangle = new System.Windows.Shapes.Rectangle()
                    {
                        Width = 10,
                        Height = 10,
                        Fill = Brushes.Yellow
                    };
                    Taxi taxi = new Taxi(new State(10, "Frei"), tp.getPosition());
                    central.addTaxi(taxi);
                    System.Windows.Controls.Canvas.SetLeft(rectangle, (tp.getPosition().getX()) - rectangle.Width/2);
                    System.Windows.Controls.Canvas.SetTop(rectangle, (tp.getPosition().getY()) - rectangle.Height/2);
                    map.Children.Add(rectangle);
                }
            }
        }

        public void createValidPoints()
        {
            this.points = new List<Point>();
            int intervall = 100;

            for (int i = 0; i <= this.xachsis; i = i + intervall)
            {
                for (int j = 0; j <= this.yachsis; j++)
                {
                    this.points.Add(new Point(i, j));
            }
            }

            for (int i = 0; i <= this.yachsis; i = i + intervall)
            {
                for (int j = 0; j <= this.xachsis; j++)
                {
                    Point check = this.points.Find(x => x.getX() == j && x.getY() == i);
                    if (check == null)
                    {
                        this.points.Add(new Point(j, i));
                    }
                    
                }
            }
        }

        public List<Point> getValidPoints()
        {
            return this.points;
        }

        public void clear()
        {
            map.Children.Clear();
        }
        public void redraw()
        {
            clear();

            List<TaxiPoint> taxiPoints = central.getTaxiPoints();
            foreach (TaxiPoint tp in taxiPoints)
            {
                var rectangle = new System.Windows.Shapes.Rectangle()
                {
                    Width = 10,
                    Height = 15,
                    Stroke = Brushes.Black,
                    Fill = Brushes.Aqua
                };
                System.Windows.Controls.Canvas.SetLeft(rectangle, (tp.getPosition().getX() - rectangle.Width/2));
                System.Windows.Controls.Canvas.SetTop(rectangle, (tp.getPosition().getY() - rectangle.Height/2));
                map.Children.Add(rectangle);
            }

            List<Point> conurbationPoints = central.getConurbationPoints();
            foreach (Point p in conurbationPoints)
            {
                var ellipse = new System.Windows.Shapes.Ellipse()
                {
                    Width = 20,
                    Height = 20,
                    Stroke = Brushes.Black,
                    Fill = Brushes.OrangeRed
                };
                System.Windows.Controls.Canvas.SetLeft(ellipse, (p.getX() - ellipse.Width/2));
                System.Windows.Controls.Canvas.SetTop(ellipse, (p.getY() - ellipse.Height/2));
                map.Children.Add(ellipse);
            }

            List<Client> clients = central.getClients();
            foreach (Client c in clients)
            {
                var ellipse = new System.Windows.Shapes.Ellipse()
                {
                    Width = 5,
                    Height = 5,
                    Stroke = Brushes.White,
                    Fill = Brushes.LawnGreen
                };
                System.Windows.Controls.Canvas.SetLeft(ellipse, (c.getPosition().getX() - ellipse.Width/2));
                System.Windows.Controls.Canvas.SetTop(ellipse, (c.getPosition().getY() - ellipse.Height/2));
                map.Children.Add(ellipse);
            }

            List<Taxi> taxis = central.getTaxis();
            foreach (Taxi t in taxis)
            {
                var ellipse = new System.Windows.Shapes.Rectangle()
                {
                    Width = 7,
                    Height = 7,
                    Stroke = Brushes.Gray,
                    Fill = Brushes.Beige
                };
                System.Windows.Controls.Canvas.SetLeft(ellipse, (t.getPosition().getX() - ellipse.Width/2));
                System.Windows.Controls.Canvas.SetTop(ellipse, (t.getPosition().getY() - ellipse.Height/2));
                map.Children.Add(ellipse);
            }
        }
    }
}

