using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    //internal class Point : IFigure
    [Serializable]
    public class Point : IFigure
    {
        public Point() { }

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }
        public Color color { get; set; }
        public Point(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            color = Color.Black;
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(this.color), this.StartPoint.X, this.StartPoint.Y, 1, 1);
            //visitor.VisitPoint(this);
        }
        public override string ToString()
        {
            return $"Point ({StartPoint}, {EndPoint})";
        }

    }
}
