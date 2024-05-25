using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp_OOP_1.GraphicsFigures.Figures
{
    //internal interface IFigure
    public interface IFigure
    {
        /*void Change(IVisitor visitor);*/
        public void Draw(Graphics graphics);
        public System.Drawing.Point StartPoint { get; set; }
        public System.Drawing.Point EndPoint { get; set; }
        public Color color { get; set; }
    }
} 
