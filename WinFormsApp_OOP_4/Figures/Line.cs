using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    //internal class Line : IFigure
    public class Line : IFigure
    {
        public Line() { }

        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }
        public Color color { get; set; }

        public Line(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            color = Color.Black;
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(this.color), this.StartPoint, this.EndPoint);
        }
        public override string ToString()
        {
            return $"Line ({StartPoint}, {EndPoint})";
        }
    }
}
