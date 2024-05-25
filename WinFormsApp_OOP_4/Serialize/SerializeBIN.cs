using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Visitors;
using WinFormsApp_OOP_2;

namespace WinFormsApp_OOP_2.Serialize
{
    internal class SerializeBIN
    {
#pragma warning disable SYSLIB0011
        BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011

        public void Serialize()
        {
            IFigure figure;
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
/*                foreach (IFigure figure in figuresList)
                {
                    formatter.Serialize(fs, figure);
                }*/

                

                Console.WriteLine("Объект сериализован");
            }
        }

    }
}
