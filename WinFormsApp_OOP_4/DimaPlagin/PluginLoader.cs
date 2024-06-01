using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_OOP_2
{

    public class PluginLoader
    {
        public static List<IShapePlugin> LoadPlugins(string path)
        {
            var plugins = new List<IShapePlugin>();

            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                var assembly = Assembly.LoadFrom(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IShapePlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IShapePlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }
            }

            return plugins;
        }
    }

}
