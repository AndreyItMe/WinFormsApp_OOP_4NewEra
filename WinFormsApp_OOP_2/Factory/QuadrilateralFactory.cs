using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = System.Drawing.Point;


namespace WinFormsApp_OOP_2.Drawers
{
    internal class QuadrilateralFactory : IFactory
    {
        public IFigure Create(Point startPoint, Point endPoint)
        {
            return new Quadrilateral(startPoint, endPoint);
        }
    }
}
