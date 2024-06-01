using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;

namespace WinFormsApp_OOP_2
{
    public static class FigureTypeLoader
    {
        public static List<Type> LoadFigureTypes(string path)
        {
            var types = new List<Type>();

            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(file);
                var figureTypes = assembly.GetTypes().Where(t => typeof(IFigure).IsAssignableFrom(t) && !t.IsInterface);

                types.AddRange(figureTypes);
            }

            return types;
        }
    }
}
