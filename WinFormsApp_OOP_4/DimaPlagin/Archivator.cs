using System.IO.Compression;
//using Figures4.Bootloader;
using WinFormsApp_OOP_2.Visitors;

namespace UserArchievePlugin
{
    public class Archivator : IArchivator
    {
        public void ArchiveXmlFile(string filePath, string zipFilePath)
        {
            ZipFile.CreateFromDirectory(Path.GetDirectoryName(filePath), zipFilePath, CompressionLevel.Optimal, false);
        }

        public void UnzipArchive(string archivePath, string extractPath)
        {
            ZipFile.ExtractToDirectory(archivePath, extractPath);
        }
    }
}
