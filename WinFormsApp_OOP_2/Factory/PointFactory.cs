using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;
//using Point = System.Drawing.Point;


namespace WinFormsApp_OOP_2.Drawers
{
    internal class PointFactory : IFactory
    {
        public IFigure Create(System.Drawing.Point startPoint, System.Drawing.Point endPoint)
        {            
            return new Point(startPoint, endPoint);
        }
    }
}
