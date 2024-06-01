using System.Xml.Serialization;
using static WinFormsApp_OOP_2.Form1;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2;
using System.Windows.Forms;
using Newtonsoft.Json;

public class ShapeProcessor
{
    private readonly List<IShapePlugin> _plugins;

    public ShapeProcessor(List<IShapePlugin> plugins)
    {
        _plugins = plugins;
    }

    // Класс, представляющий контейнер для сериализации
    [XmlRoot("Figures")]
    public class FigureContainer
    {
        [XmlElement("Figure")]
        public List<IFigure>? FiguresList { get; set; }
    }

    public void SaveShapes(List<IFigure> shapes, string filePath)
    {
        if (_plugins.Any())
        {
            //записывает xmlData в файл
            FigureContainer container = new FigureContainer { FiguresList = shapes };
            var knownTypes = FigureTypeLoader.LoadFigureTypes("C:\\Users\\Dimaland\\source\\repos\\Dimaland16\\WinFormsApp_OOP_2\\WinFormsLibrary1\\bin\\Debug\\net8.0-windows");
            XmlSerializer serializer = new XmlSerializer(typeof(FigureContainer), knownTypes.ToArray());

            string xmlData;
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, container);
                xmlData = stringWriter.ToString();
            }

            // Обрабатываем данные с помощью плагинов перед сохранением
            foreach (var plugin in _plugins)
            {
                plugin.ProcessBeforeSave(ref xmlData, typeof(FigureContainer));
            }

            File.WriteAllText(filePath, xmlData);
        }
        else
        {
            //сериализует фигуры в JSON и записывает в файл
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(shapes, settings);
            File.WriteAllText(filePath, json);
        }
    }

    public List<IFigure> LoadShapes(string filePath)
    {
        if (_plugins.Any())
        {
            //десириализует файл в XML и возращает фигуры
            string data = File.ReadAllText(filePath);
            foreach (var plugin in _plugins)
            {
                plugin.ProcessAfterLoad(ref data, typeof(FigureContainer));
            }
            var knownTypes = FigureTypeLoader.LoadFigureTypes("C:\\Users\\Dimaland\\source\\repos\\Dimaland16\\WinFormsApp_OOP_2\\WinFormsLibrary1\\bin\\Debug\\net8.0-windows");
            XmlSerializer serializer = new XmlSerializer(typeof(FigureContainer), knownTypes.ToArray());

            using (var stringReader = new StringReader(data))
            {
                FigureContainer container = (FigureContainer)serializer.Deserialize(stringReader);
                return container.FiguresList;
            }
        }
        else
        {
            //считывает файл и десериализует его в JSON
            string json = File.ReadAllText(filePath);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented

            };

            return JsonConvert.DeserializeObject<List<IFigure>>(json, settings);
        }



    }
}
