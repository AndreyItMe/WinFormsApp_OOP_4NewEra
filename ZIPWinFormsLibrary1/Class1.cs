using System.IO.Compression;

namespace ZIPWinFormsLibrary1
{
    public class ZipBin
    {
        public void ZipBintoolStripTextBox1_Click(object sender, EventArgs e)
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN"; // исходная папка
            //File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBIN\\ZipBin.zip");
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ООТПиСП\\ZipBin.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }
    }
}
