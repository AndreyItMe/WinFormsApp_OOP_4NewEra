using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIPWinFormsLibrary1
{
    public class ZiptoolStripTextBox1
    {
        public static void OperationZipBin()
        {
            Console.WriteLine("ZipBintoolStripTextBox1.OperationZipBin");
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN"; // исходная папка
            //File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN\\ZipBin.zip");
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBin.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        public static void OperationExtractZipBin()
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN\\ZipBin.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN"; // папка, куда распаковывается файл
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }

        public static void OperationZipJSON()
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON"; // исходная папка
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        public static void OperationExtractZipJSON(object sender, EventArgs e)
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipJSON"; // папка, куда распаковывается файл
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }
    }
}
