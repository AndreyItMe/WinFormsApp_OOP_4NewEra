using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIPWinFormsLibrary1
{
    public class ZipBintoolStripTextBox1
    {
        public void Operation()
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN"; // исходная папка
            //File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN\\ZipBin.zip");
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBin.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }
    }
}
