using System.Reflection;

namespace AdapterWinFormsLibrary1
{
    public class AdapterDima
    {
        private readonly object _archivator;
        public readonly MethodInfo _archiveXmlFileMethod;
        public readonly MethodInfo _unzipArchiveMethod;
        public readonly MethodInfo _processBeforeSave; //XML2JSON
        public readonly MethodInfo _processAfterLoad;    //JSON2XML
        string dataType;

        public AdapterDima(string assemblyPath)
        {
            //JSON2XML; XML2JSON
            //констркутор знать настройки json, xml
            //знать что он редактирует(абстрактные класс и тд)

            Assembly pluginAssembly = Assembly.LoadFrom(assemblyPath);
            //Type archivatorType = pluginAssembly.GetType("AdapterWinFormsLibrary1.Archivator");
            Type archivatorType = pluginAssembly.GetType("XmlToJsonPlugin");
            
            if (archivatorType == null)
            {
                throw new Exception("Archivator type not found in the selected assembly.");
            }

            _archivator = Activator.CreateInstance(archivatorType);

            _archiveXmlFileMethod = archivatorType.GetMethod("ArchiveXmlFile");
            _unzipArchiveMethod = archivatorType.GetMethod("UnzipArchive");
            _processBeforeSave = archivatorType.GetMethod("ProcessBeforeSave");
            _processAfterLoad = archivatorType.GetMethod("ProcessAfterLoad");

            if (_archiveXmlFileMethod == null || _unzipArchiveMethod == null || 
                _processBeforeSave == null || _processAfterLoad == null)
            {
                throw new Exception("Methods not found in the selected Archivator type.");
            }
            
        }

        public void ProcessBeforeSave(ref string json)
        {
            _processBeforeSave.Invoke(_archivator, new object[] { json, dataType });
        }
        public void ProcessAfterLoad(ref string json) //тут отказался от "string dataType"
        {
            _processAfterLoad.Invoke(_archivator, new object[] { json });
        }

        public void ArchiveXmlFile(string filePath, string zipFilePath)
        {
            _archiveXmlFileMethod.Invoke(_archivator, new object[] { filePath, zipFilePath });
        }

        public void UnzipArchive(string archivePath, string extractPath)
        {
            _unzipArchiveMethod.Invoke(_archivator, new object[] { archivePath, extractPath });
        }
    }
}
