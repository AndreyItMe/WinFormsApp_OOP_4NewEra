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
            color = Color.Black;
        }
        public new void Draw(Graphics graphics)
        {
            //visitor.VisitCircle(this);
            int centerX = (this.StartPoint.X + this.EndPoint.X) / 2;
            int centerY = (this.StartPoint.Y + this.EndPoint.Y) / 2;

            int radius = Math.Abs(this.StartPoint.X - this.EndPoint.X) / 2;

            int x = centerX - radius;
            int y = centerY - radius;
            int diameter = radius * 2;


            //при создании Pen можно еще добавить толщину пера
            graphics.DrawEllipse(new Pen(this.color), x, y, diameter, diameter);
            //graphics.DrawEllipse(new Pen(Color.Black), x, y, diameter, diameter);
        }
        public override string ToString()
        {
            return $"Circle ({StartPoint}, {EndPoint})";
        }
    }
}
