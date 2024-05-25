using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Drawers;
using Point = System.Drawing.Point;



namespace WinFormsApp_OOP_2Dima.Drawers
{
    internal class Square2Factory : IFactory
    {
        public Square2Factory() { }

        public IFigure Create(Point startPoint, Point endPoint)
        {
            return new Square2(startPoint, endPoint);
        }
    }
}
