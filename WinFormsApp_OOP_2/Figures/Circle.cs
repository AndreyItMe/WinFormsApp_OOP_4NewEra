using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinFormsApp_OOP_2.Visitors;


namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    [Serializable]
    //internal class Circle : Ellipse, IFigure
    public class Circle : Ellipse, IFigure
    {
        public new System.Drawing.Point StartPoint { get; set; }
        public new System.Drawing.Point EndPoint { get; set; }

        public Circle(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public new void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this);
        }
        public override string ToString()
        {
            return $"Circle ({StartPoint}, {EndPoint})";
        }
    }
}
