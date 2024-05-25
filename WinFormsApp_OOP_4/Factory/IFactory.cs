using System.Net;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = System.Drawing.Point;

namespace WinFormsApp_OOP_2.Drawers
{
    public interface IFactory
    {
         IFigure Create(Point startPoint, Point endPoint);
    }
}
