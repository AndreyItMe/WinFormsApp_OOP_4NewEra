using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_OOP_2.Visitors
{
    public interface IArchivator
    {
        void ArchiveXmlFile(string filePath, string zipFilePath);
        void UnzipArchive(string archivePath, string extractPath);
    }

}
