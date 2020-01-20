using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC19
{
    class Day3
    {
        public static Fils[] CreaFils(string addr)
        {
            string[] raw = { };
            if (System.IO.File.Exists(addr)) raw = System.IO.File.ReadAllLines(addr);
            Fils[] r = new Fils[raw.Length];
            for (int i = 0; i < raw.Length; i++)
            {
                r[i] = new Fils(raw[i]);
            }
            return r;
        }
        public static List<Point> Croisement(Fils f1, Fils f2)
        {
            List<Point> r = new List<Point>();
            for (int i = 0; i < f1.Segments.Count; i++)
            {
                for (int j = 0; j < f2.Segments.Count; j++)
                {
                    Point p = f1.Segments[i].Croisement(f2.Segments[j]);
                    if (p != null) r.Add(p);
                }
            }
            Point p1 = new Point(0, 0);
            while(p1!=null)
            {
                r.Remove(p1);
                p1 = r.Find(x => (x.X == 0 && x.Y == 0));
            }
            return r;
        }

        public static int Challenge(string addr)
        {
            int r = Int32.MaxValue;
            Fils[] fils = CreaFils(addr);
            if (fils.Length == 0) return r;
            List<Point> points = Croisement(fils[0], fils[1]);
            foreach(Point p in points)
            {
                r = Math.Min(r, p.Distance);
            }
            return r;
        }





    }
    class Point
    {
        int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int X { get => x; set => x = value; }
        internal int Y { get => y; set => y = value; }

        public override string ToString()
        {
            return "X:" + x + ", Y:" + y;
        }

        public bool Appartient(Segment s)
        {
            if (s.A.X == this.x && s.B.X == this.x) return (this.y <= Math.Max(s.A.Y, s.B.Y) && this.y >= Math.Min(s.A.Y, s.B.Y));
            if (s.A.Y == this.y && s.B.Y == this.y) return (this.x <= Math.Max(s.A.X, s.B.X) && this.x >= Math.Min(s.A.X, s.B.X));
            return false;
        }

        public int Distance => Math.Abs(x) + Math.Abs(y);

    }
    class Segment
    {
        Point a, b;

        public Segment(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        internal Point A { get => a; set => a = value; }
        internal Point B { get => b; set => b = value; }

        public override string ToString()
        {
            return a.ToString() + "|" + b.ToString(); ;
        }

        public Point Croisement(Segment s)
        {
            for (int i = Math.Min(this.a.X, this.b.X); i <= Math.Max(this.a.X, this.b.X); i++)
            {
                for (int j = Math.Min(this.a.Y, this.b.Y); j <= Math.Max(this.a.Y, this.b.Y); j++)
                {
                    Point p = new Point(i, j);
                    if (p.Appartient(s)) return p;
                }
            }
            return null;
        }
    }
    class Fils
    {
        List<Point> points = new List<Point>();
        List<Segment> segments = new List<Segment>();

        public Fils() { }
        public Fils(List<Point> points)
        {
            this.points = points;
        }
        public Fils(string brut)
        {
            string[] coord = brut.Split(',');
            points.Add(new Point(0, 0));
            foreach (string s in coord)
            {
                Point p = points.Last();
                int n = Int32.Parse(s.Remove(0, 1));
                switch (s[0])
                {
                    case 'U':
                        points.Add(new Point(p.X, p.Y + n));
                        break;
                    case 'D':
                        points.Add(new Point(p.X, p.Y - n));
                        break;
                    case 'L':
                        points.Add(new Point(p.X - n, p.Y));
                        break;
                    case 'R':
                        points.Add(new Point(p.X + n, p.Y));
                        break;
                }
            }
            for (int i = 0; i < points.Count - 1; i++) segments.Add(new Segment(points[i], points[i + 1]));
        }

        internal List<Point> Points { get => points; set => points = value; }
        internal List<Segment> Segments { get => segments; set => segments = value; }
    }
}
