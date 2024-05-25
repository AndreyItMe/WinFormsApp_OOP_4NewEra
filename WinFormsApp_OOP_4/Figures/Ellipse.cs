using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    //internal class Ellipse : Point, IFigure
    [Serializable]
    public class Ellipse : Point, IFigure
    {
        public new System.Drawing.Point StartPoint { get; set; }
        public new System.Drawing.Point EndPoint { get; set; }

        public Ellipse() { }

        public Ellipse(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            color = Color.Black;
        }

        public new void Draw(Graphics graphics)
        {
            //visitor.VisitEllipse(this);
            int radiusX = Math.Abs(this.StartPoint.X - this.EndPoint.X) / 2;
            int radiusY = Math.Abs(this.StartPoint.Y - this.EndPoint.Y) / 2;

            int centerX = (this.StartPoint.X + this.EndPoint.X) / 2;
            int centerY = (this.StartPoint.Y + this.EndPoint.Y) / 2;

            int x = centerX - radiusX;
            int y = centerY - radiusY;

            int width = radiusX * 2;
            int height = radiusY * 2;

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(x, y, width, height);

            graphics.DrawEllipse(new Pen(this.color), rectangle);
        }
        public override string ToString()
        {
            return $"Ellipse ({StartPoint}, {EndPoint})";
        }
    }
}
