using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_OOP_2
{
    public interface IShapePlugin
    {
        string Name { get; }
        void ProcessBeforeSave(ref string data, Type dataType);
        void ProcessAfterLoad(ref string data, Type dataType);
    }

}
