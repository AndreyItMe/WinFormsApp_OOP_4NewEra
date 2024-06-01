using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;

namespace ZIPWinFormsLibrary1
{
    public class ZiptoolStripTextBox1
    {
        public static void OperationZipBin()
        {
            Console.WriteLine("ZipBintoolStripTextBox1.OperationZipBin");
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN"; // исходная папка
            //File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN\\ZipBin.zip");
            string zipFile =      "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBin.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        public static void OperationExtractZipBin()
        {
            string zipFile =      "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN\\ZipBin.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN"; // папка, куда распаковывается файл
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }

        public static void OperationZipJSON(string json)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            //string json = JsonConvert.SerializeObject(figuresList, settings);

            Directory.CreateDirectory("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON");
            FileStream fs = new FileStream("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON\\SerializeJSON.json", FileMode.Create);
            /*
                        if (!File.Exists("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON\\SerializeJSON.json"))
                        {
                            Directory.CreateDirectory("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON");
                            File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON\\SerializeJSON.json");
                        }
            */
            byte[] info = new UTF8Encoding(true).GetBytes(json);
            fs.Write(info, 0, info.Length);
            fs.Close();
            //File.WriteAllText("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON\\SerializeJSON.json", json);
            //это явно лишнее тк
            if (true)
            {
                string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON"; // исходная папка
                string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON.zip"; // сжатый файл
                File.Delete(zipFile);
                ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                Directory.Delete(sourceFolder, true);
            }
        }

        public static object OperationExtractZipJSON()
        {
            string zipFile =      "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON.zip"; // сжатый файл
            string targetDirectory = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON"; // папка, куда распаковывается файл
            File.Delete(targetDirectory+ "\\SerializeJSON.json");
            ZipFile.ExtractToDirectory(zipFile, targetDirectory);

            string json = File.ReadAllText(targetDirectory + "\\SerializeJSON.json");
            //string json = "qwerty";
            object[] arguments = new object[] { json };
            return arguments;

            Directory.Delete(targetDirectory);
        }
    }
}
