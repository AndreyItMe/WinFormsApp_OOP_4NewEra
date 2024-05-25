using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    //internal class Quadrilateral : Line, IFigure
    [Serializable]
    public class SandClock : IFigure
    {
        //private Graphics graphics;

        public SandClock() { }

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }

        public Color color { get; set; }

        public SandClock(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            color = Color.Black;
        }

        public void Draw(Graphics graphics)
        {
            int x1 = this.StartPoint.X;
            int y1 = this.StartPoint.Y;
            int x2 = this.EndPoint.X;
            int y2 = this.EndPoint.Y;

            System.Drawing.Point[] vertices = new System.Drawing.Point[]
            {
                new System.Drawing.Point(x1, y1),
                new System.Drawing.Point(x2, y1),
                new System.Drawing.Point(x1, y2),
                new System.Drawing.Point(x2, y2)
            };
            graphics.DrawPolygon(new Pen(this.color), vertices);
        }
        public override string ToString()
        {
            return $"Quadrilateral ({StartPoint}, {EndPoint})";
        }
    }
}
