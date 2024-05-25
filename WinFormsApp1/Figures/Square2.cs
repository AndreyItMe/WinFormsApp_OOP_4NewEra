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
    public class Square2 : IFigure
    {
        //public Graphics graphics;

        public Square2() { }

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }

        public Color color { get; set; }

        public Square2(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            //находим минимальное ребро
            int width = 0;
            if (endPoint.X - startPoint.X < endPoint.Y - startPoint.Y)
            {
                width = endPoint.X - startPoint.X;
            }
            else
            {
                width = endPoint.Y - startPoint.Y;
            }

            StartPoint = startPoint;
            //EndPoint = endPoint;
            EndPoint = new System.Drawing.Point(StartPoint.X + width, StartPoint.Y + width);
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
                new System.Drawing.Point(x1, y2),

                new System.Drawing.Point(x2, y2),
                new System.Drawing.Point(x2, y1)
            };
            graphics.DrawPolygon(new Pen(this.color), vertices);
        }

        public override string ToString()
        {
            return $"Square ({StartPoint}, {EndPoint})";
        }
    }
}
