using System.Net;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = System.Drawing.Point;

namespace WinFormsApp_OOP_2.Drawers
{
    internal interface IFactory
    {
         IFigure Create(Point startPoint, Point endPoint);
    }
}
