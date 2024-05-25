using System;
using System.Collections.Generic;
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

        public Line(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
/*
        public new void Change(IVisitor visitor)
        {
            System.Drawing.Point point1 = this.StartPoint;
            point1.X -= 10;
            point1.Y -= 10;
            this.StartPoint = point1;

            System.Drawing.Point point2 = this.EndPoint;
            point2.X -= 10;
            point2.Y -= 10;
            this.EndPoint = point2;
        }
*/
        public void Accept(IVisitor visitor)
        {
            visitor.VisitLine(this);
        }
        public override string ToString()
        {
            return $"Line ({StartPoint}, {EndPoint})";
        }
    }
}
