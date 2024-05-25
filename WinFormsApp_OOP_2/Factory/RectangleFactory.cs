using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Rectangle = WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle;
using Point = System.Drawing.Point;


namespace WinFormsApp_OOP_2.Drawers
{
    internal class RectangleFactory : IFactory
    {
        public IFigure Create(Point startPoint, Point endPoint)
        {
            return new Rectangle(startPoint, endPoint);
        }
    }
}
