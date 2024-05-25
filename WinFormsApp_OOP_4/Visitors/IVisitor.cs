using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;
using Rectangle = WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle;



namespace WinFormsApp_OOP_2.Visitors
{
    //internal interface IVisitor
    public interface IVisitor
    {
        void VisitEllipse(Ellipse ellipse);
        void VisitLine(Line line);
        void VisitRectangle(Rectangle rectangle);
        //void VisitQuadrilateral(Quadrilateral quadrilateral);
        void VisitSquare(Square square);
        void VisitPoint(Point point);
        void VisitCircle(Circle circle);
    }
}
