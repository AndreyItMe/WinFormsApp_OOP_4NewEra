using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Drawers;
using WinFormsApp_OOP_2.Visitors;
using Point = WinFormsApp_OOP_1.GraphicsFigures.Figures.Point;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml;
using WinFormsApp_OOP_2.Serialize;
using System.Text.Json;
using static System.Windows.Forms.Design.AxImporter;
using System.Net.Http.Json;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
//using Point = System.Drawing.Point;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.IO.Compression;

namespace WinFormsApp_OOP_2
{
    public partial class Form1 : Form
    {
        private Circle prCircleProp;
        private Ellipse prEllipseProp;
        private Line prLineProp;

        Graphics graphics;

        private WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle prRectangleProp;
        private Square prSquareProp;
        public Form1()
        {
            InitializeComponent();
        }

        public List<IFigure> figuresList = new List<IFigure>();
        private Pen pen;
        private Brush penColor;
        private Brush shapeColor;

        private System.Drawing.Point startPoint;
        private System.Drawing.Point endPoint;

#pragma warning disable SYSLIB0011
        BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011

        public void SerializeBIN()
        {
            using (FileStream fs = new FileStream("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN\\SerializeBIN.bin", FileMode.Truncate))
            {
                foreach (IFigure figure in figuresList)
                {
                    formatter.Serialize(fs, figure);
                }
                fs.Close();
            }
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN"; // исходна€ папка
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBin.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        public void DeSerializeBIN()
        {
            // десериализаци€ из файла people.dat

            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBin.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN"; // папка, куда распаковываетс€ файл

            if (!File.Exists(targetFolder))
            {
                //File.Create(targetFolder);
            }

            ZipFile.ExtractToDirectory(zipFile, targetFolder, true); //true дл€ перезаписи файла

            using (FileStream fs = new FileStream("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN\\SerializeBIN.bin", FileMode.OpenOrCreate))
            {
                while (fs.Position < fs.Length)
                {
                    IFigure figure = (IFigure)formatter.Deserialize(fs);
                    figuresList.Add(figure);
                }
            }

            for (int i = 0; i < figuresList.Count; i++)
            {
                listBox1.Items.Add(i + 1 + "." + figuresList[i].ToString());
            }

            pictureBox1.Invalidate();
        }

        public void SerializeJSON()
        {
            /*            using (FileStream fs = new FileStream("SerializeJSON.bin", FileMode.OpenOrCreate))
                        {
                            foreach (IFigure figure in figuresList)
                            {
                                System.Drawing.Point point = new System.Drawing.Point(0, 0);
                                Circle figure2 = new Circle(point, point); 
                                string json = JsonSerializer.Serialize(figure);
                                //formatter.Serialize(fs, figure);
                            }
                        }*/

            //selectedShape.IsSelected = false;
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(figuresList, settings);
            if (!File.Exists("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON\\SerializeJSON.json"))
            {
                File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON\\SerializeJSON.json");
            }
            File.WriteAllText("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON\\SerializeJSON.json", json);

            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON"; // исходна€ папка
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);

        }

        public void DeSerializeJSON()
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON"; // папка, куда распаковываетс€ файл
            ZipFile.ExtractToDirectory(zipFile, targetFolder);

            string json = File.ReadAllText("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON\\SerializeJSON.json");

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented

            };

            figuresList = JsonConvert.DeserializeObject<List<IFigure>>(json, settings);

            //вот эта хрень добавл€ет WinFormApp в listBox

            foreach (IFigure figure in figuresList)
            {
                //listBox.Items.Add(figure);
                //listBox1.Items.Add(figuresList.Count + "." + figure.ToString);
            }
            for (int i = 0; i < figuresList.Count; i++)
            {
                listBox1.Items.Add(i + 1 + "." + figuresList[i].ToString());
            }

            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e) //async
        {
            listBox.Items.Add(new ComboboxItem() { Text = "Circle", Value = new CircleFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Ellipse", Value = new EllipseFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Line", Value = new LineFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Point", Value = new PointFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Rectangle", Value = new RectangleFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Square", Value = new SquareFactory() });

            /*
             *          заполн€ем пару обьектов, чтобы их потом сериализовать
                        figure = facroty.Create(new System.Drawing.Point(300, 10), new System.Drawing.Point(540, 320));
                        //IFigure figure = facroty.Create(startPoint, endPoint);
                        figuresList.Add(figure);
                        pictureBox1.Invalidate();

                        figure = facroty.Create(new System.Drawing.Point(30, 10), new System.Drawing.Point(270, 320));
                        //IFigure figure = facroty.Create(startPoint, endPoint);
                        figuresList.Add(figure);
                        pictureBox1.Invalidate();

                        facroty = new CircleFactory();
                        figure = facroty.Create(new System.Drawing.Point(100, 50), new System.Drawing.Point(180, 160));
                        //IFigure figure = facroty.Create(startPoint, endPoint);
                        figuresList.Add(figure);
                        pictureBox1.Invalidate();

                        сериализаци€

                    создаем объект BinaryFormatter
        #pragma warning disable SYSLIB0011
                    BinaryFormatter formatter = new BinaryFormatter();
        #pragma warning restore SYSLIB0011
                    DeSerializeBIN();
                    SerializeBIN();
                    SerializeJSON();
                    DeSerializeJSON();
            */
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                endPoint = e.Location;
                object listBoxChoice = (listBox.SelectedItem as ComboboxItem)?.Value;
                //IFactory facroty = listBoxChoice as IFactory; //создаю фабрику дл€ конкретной фигуры

                Type myType = listBoxChoice.GetType();
                MethodInfo methodInfo = myType.GetMethod("Create");
                object? figure = methodInfo.Invoke(listBoxChoice, new object[] { startPoint, endPoint });
                myType.GetMethod("Create");
                Type myType_f = figure.GetType();// .GetMethod("Create");
                Type type = figure.GetType();

                //IFigure figure = facroty.Create(startPoint, endPoint); //создаю конкретную фигуру абстрактоного типа
                IFigure figure1 = (IFigure)figure;// as WinFormsApp_OOP_1.GraphicsFigures.Figures.IFigure;
                figuresList.Add(figure1);

                string FigureName = listBox.SelectedItem.ToString();
                //string[] words = text.Split(".", System.StringSplitOptions.RemoveEmptyEntries);

                //listBox1.Items.Add(figuresList.Count + "." + FigureName);
                listBox1.Items.Add(figuresList.Count + "." + figuresList[figuresList.Count - 1].ToString());

                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (IFigure figure in figuresList)
            {
                //figure.Change(visitor);
                graphics = e.Graphics;
                figure.Draw(graphics);
            }
        }

        private void toolStripLabelSerBIN_Click(object sender, EventArgs e)
        {
            SerializeBIN();
        }
        private void toolStripLabelDeSerBIN_Click(object sender, EventArgs e)
        {
            DeSerializeBIN();
            pictureBox1.Invalidate();
        }

        private void toolStripLabelSerJSON_Click(object sender, EventArgs e)
        {
            SerializeJSON();
        }

        private void toolStripLabelDeSerJSON_Click(object sender, EventArgs e)
        {
            DeSerializeJSON();
            //pictureBox1.Invalidate();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox a = sender as ListBox;
            int SelectedIndex = a.SelectedIndex;
            if (SelectedIndex >= 0)
            {
                cbKindOfProps.SelectedObject = figuresList.ElementAt(SelectedIndex);
            }
            int i = 0;
        }

        private void bReCreate_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            /*
                        IFigure figure = figuresList[listBox1.SelectedIndex];

                        figuresList[listBox1.SelectedIndex] = figure;
            */
            /*
            IFactory facroty = (listBox.SelectedItem as ComboboxItem)?.Value as IFactory;
            IFigure figure = facroty.Create(startPoint, endPoint);
            if (figure != null)
            {
                
            }
*/
        }

        private void bDeleteFigure_Click(object sender, EventArgs e)
        {
            figuresList.RemoveAt(listBox1.SelectedIndex);
            pictureBox1.Invalidate();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            //string AssemblyFileWay = FileDialog.;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.dll)|*.dll|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string AssemblyFileName = openFileDialog1.FileName;

            //Assembly asm = Assembly.LoadFile("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\WinFormsApp_OOP_2\\WinFormsApp1\\bin\\Debug\\net8.0-windows\\AssemblySandClock.dll");
            Assembly asm = Assembly.LoadFile(AssemblyFileName);

            Type? factoryType = asm.GetType("WinFormsApp_OOP_2.Drawers.SandClockFactory");
            Type? figureType = asm.GetType("WinFormsApp_OOP_1.GraphicsFigures.Figures.SandClock");
            object itemFactory = Activator.CreateInstance(factoryType);
            string itemName = figureType.Name;
            listBox.Items.Add(new ComboboxItem() { Text = itemName, Value = itemFactory });


            Type? factoryType2 = asm.GetType("WinFormsApp_OOP_2Dima.Drawers.Square2Factory");
            Type? figureType2 = asm.GetType("WinFormsApp_OOP_1.GraphicsFigures.Figures.Square2");
            object itemFactory2 = Activator.CreateInstance(factoryType2);
            string itemName2 = figureType2.Name;
            listBox.Items.Add(new ComboboxItem() { Text = itemName2, Value = itemFactory2 });
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN"; // исходна€ папка
            //File.Create("C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN\\ZipBin.zip");
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBin.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN\\ZipBin.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipBIN"; // папка, куда распаковываетс€ файл
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON"; // исходна€ папка
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON.zip"; // сжатый файл
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON.zip"; // сжатый файл
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\ќќ“ѕи—ѕ\\ZipJSON"; // папка, куда распаковываетс€ файл
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }
    }
}
