using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;

namespace WinFormsApp_OOP_2.Visitors
{
    internal class GraphicsVisitor : IVisitor
    {
        Random rand = new Random();
        private Graphics graphics;

        //Pen pen = new Pen(Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(rand.Next(0x1000000)))));
        //Pen pen = new Pen(Color.Blue);

        public GraphicsVisitor(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void VisitCircle(Circle circle)
        {
            int centerX = (circle.StartPoint.X + circle.EndPoint.X) / 2;
            int centerY = (circle.StartPoint.Y + circle.EndPoint.Y) / 2;

            int radius = Math.Abs(circle.StartPoint.X - circle.EndPoint.X) / 2;

            int x = centerX - radius;
            int y = centerY - radius;
            int diameter = radius * 2;


            graphics.DrawEllipse(new Pen(Color.Black), x, y, diameter, diameter);
        }
/*
        public void VisitQuadrilateral(Quadrilateral quadrilateral)
        {
            int x1 = quadrilateral.StartPoint.X;
            int y1 = quadrilateral.StartPoint.Y;
            int x2 = quadrilateral.EndPoint.X;
            int y2 = quadrilateral.EndPoint.Y;

            System.Drawing.Point[] vertices = new System.Drawing.Point[]
            {
                new System.Drawing.Point(x1, y1),
                new System.Drawing.Point(x2, y1),
                new System.Drawing.Point(x1, y2),
                new System.Drawing.Point(x2, y2)
            };
            graphics.DrawPolygon(new Pen(Color.Black), vertices);
        }
*/
        public void VisitRectangle(WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle rectangle)
        {
            //pen = new Pen(Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(rand.Next(0x1000000)))));
            int width = Math.Abs(rectangle.EndPoint.X - rectangle.StartPoint.X);
            int height = Math.Abs(rectangle.EndPoint.Y - rectangle.StartPoint.Y);
            System.Drawing.Rectangle _rectangle = new System.Drawing.Rectangle(rectangle.StartPoint.X, rectangle.StartPoint.Y, width, height);
            graphics.DrawRectangle(new Pen(Color.Black), _rectangle); //поменял цвет
        }

        public void VisitSquare(Square square)
        {
            int size = Math.Abs(square.EndPoint.X - square.StartPoint.X);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(square.StartPoint.X, square.StartPoint.Y, size, size);
            graphics.DrawRectangle(new Pen(Color.Black), rectangle);
        }

        public void VisitEllipse(Ellipse ellipse)
        {

            int radiusX = Math.Abs(ellipse.StartPoint.X - ellipse.EndPoint.X) / 2;
            int radiusY = Math.Abs(ellipse.StartPoint.Y - ellipse.EndPoint.Y) / 2;

            int centerX = (ellipse.StartPoint.X + ellipse.EndPoint.X) / 2;
            int centerY = (ellipse.StartPoint.Y + ellipse.EndPoint.Y) / 2;

            int x = centerX - radiusX;
            int y = centerY - radiusY;

            int width = radiusX * 2;
            int height = radiusY * 2;

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(x, y, width, height);

            graphics.DrawEllipse(new Pen(Color.Black), rectangle);
        }

        public void VisitLine(Line line)
        {
            graphics.DrawLine(new Pen(Color.Black), line.StartPoint, line.EndPoint);
        }

        public void VisitPoint(Point point)
        {
            graphics.DrawRectangle(new Pen(Color.Black), point.StartPoint.X, point.StartPoint.Y, 1, 1);

        }
    }
}
