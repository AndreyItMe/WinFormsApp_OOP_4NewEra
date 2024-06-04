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
using BaseShapesClasses;
using AdapterWinFormsLibrary1;
using System.Text;

namespace WinFormsApp_OOP_2
{
    public partial class Form1 : Form
    {
        private Circle prCircleProp;
        private Ellipse prEllipseProp;
        private Line prLineProp;
        public string xml = "";

        Graphics graphics;

        Adapter archivator;

        private WinFormsApp_OOP_1.GraphicsFigures.Figures.Rectangle prRectangleProp;
        private Square prSquareProp;
        public Form1()
        {
            InitializeComponent();
        }

        public List<IFigure> figuresList = new List<IFigure>();
        public List<IFigure> functionList = new List<IFigure>();

        private List<IShapePlugin> _plugins = new List<IShapePlugin>();
        private ShapeProcessor _shapeProcessor = new ShapeProcessor(new List<IShapePlugin>());
        private Pen pen;
/*
        private Brush penColor;
        private Brush shapeColor;
*/
        private System.Drawing.Point startPoint;
        private System.Drawing.Point endPoint;

#pragma warning disable SYSLIB0011
        BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011

        public void SerializeBIN()
        {
            //� ������ �������� ����� ����, �� ������ ������ � ����� ��� �������� � Invoke � ��� ��� ������� ��� �� �������:)

            string bin = "";
            MemoryStream stream = new MemoryStream();
            Stream stream1 = new MemoryStream();
            using (FileStream fs = new FileStream("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN\\SerializeBIN.bin", FileMode.Truncate))
            {
                foreach (IFigure figure in figuresList)
                {
                    //formatter.Serialize(fs, figure);
                    formatter.Serialize(stream1, figure);
                }
                fs.Close();
                Encoding encoding = Encoding.UTF8;
                StreamReader reader = new StreamReader(stream1, encoding);
                string text2 = reader.ReadLine();
                string text = reader.ReadToEnd();
                bin = stream.ToString();
            }
            //��� ���� ������ ��
            if (AsmIsExist) // ���� ���� ����������, �� ���� ��������� � ��� ����
            {
                string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN"; // �������� �����
                string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBin.zip"; // ������ ����
                ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                Directory.Delete(sourceFolder, true);
            }
        }

        public void DeSerializeBIN()
        {
            //�������������� �� ����� people.dat
            //��� ���� ������ ��
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN"; // �����, ���� ��������������� ����
            if (AsmIsExist)
            {
                string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBin.zip"; // ������ ����
                ZipFile.ExtractToDirectory(zipFile, targetFolder, true); //true ��� ���������� �����
            }
            
            using (FileStream fs = new FileStream("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN\\SerializeBIN.bin", FileMode.OpenOrCreate))
            {
                while (fs.Position < fs.Length)
                {
                    IFigure figure = (IFigure)formatter.Deserialize(fs);
                    figuresList.Add(figure);
                }
            }
            if (AsmIsExist)
            {
                Directory.Delete(targetFolder, true);
            }

            for (int i = 0; i < figuresList.Count; i++)
            {
                listBox1.Items.Add(i + 1 + "." + figuresList[i].ToString());
            }

            pictureBox1.Invalidate();
        }

        public void SerializeJSON()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(figuresList, settings);


            string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\NewEra\\WinFormsApp_OOP_2-master (1)\\WinFormsApp_OOP_2-master\\ZIPWinFormsLibrary1\\bin\\Debug\\net8.0-windows\\ZIPWinFormsLibrary1.dll";
            Assembly asm = Assembly.LoadFile(AssemblyFileName);
            Type? zipType = asm.GetType("ZIPWinFormsLibrary1.ZiptoolStripTextBox1");
            MethodInfo? square = zipType.GetMethod("OperationZipJSON", BindingFlags.Public | BindingFlags.Static);

            object[] arguments = new object[] { json };

            square?.Invoke(null, arguments);
            //square?.Invoke(null, null);
            /*
                        Directory.CreateDirectory("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON");
                        FileStream fs = new FileStream("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON\\SerializeJSON.json", FileMode.Create);

                                    if (!File.Exists("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON\\SerializeJSON.json"))
                                    {
                                        Directory.CreateDirectory("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON");
                                        File.Create("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON\\SerializeJSON.json");
                                    }

                        byte[] info = new UTF8Encoding(true).GetBytes(json);
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                        //File.WriteAllText("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON\\SerializeJSON.json", json);
                        //��� ���� ������ ��

                        if (AsmIsExist)
                        {
                            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON"; // �������� �����
                            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON.zip"; // ������ ����
                            File.Delete(zipFile);
                            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                            Directory.Delete(sourceFolder, true);
                        }
            */
        }

        public void DeSerializeJSON()
        //public List<IFigure> DeSerializeJSON()
        {
            string json = "";
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented

            };

            if (AsmIsExist)
            {
                string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\NewEra\\WinFormsApp_OOP_2-master (1)\\WinFormsApp_OOP_2-master\\ZIPWinFormsLibrary1\\bin\\Debug\\net8.0-windows\\ZIPWinFormsLibrary1.dll";
                Assembly asm = Assembly.LoadFile(AssemblyFileName);
                Type? zipType = asm.GetType("ZIPWinFormsLibrary1.ZiptoolStripTextBox1");
                MethodInfo? square = zipType.GetMethod("OperationExtractZipJSON", BindingFlags.Public | BindingFlags.Static);
                
                object[] arguments = new object[] { json };

                object result = square?.Invoke(null, null);
                var list = (object[])result;
                string resultString = list[0].ToString();
                
                figuresList = JsonConvert.DeserializeObject<List<IFigure>>(resultString, settings);
            }

            //figuresList = JsonConvert.DeserializeObject<List<IFigure>>(json, settings);

            //��� ���  ��������� WinFormApp � listBox

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
             *          ��������� ���� ��������, ����� �� ����� �������������
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

                        ������������

                    ������� ������ BinaryFormatter
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
                //IFactory facroty = listBoxChoice as IFactory; //������ ������� ��� ���������� ������

                Type myType = listBoxChoice.GetType();
                MethodInfo methodInfo = myType.GetMethod("Create");
                object? figure = methodInfo.Invoke(listBoxChoice, new object[] { startPoint, endPoint });
                myType.GetMethod("Create");
                Type myType_f = figure.GetType();// .GetMethod("Create");
                Type type = figure.GetType();

                //IFigure figure = facroty.Create(startPoint, endPoint); //������ ���������� ������ ������������� ����
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

            //Assembly asm = Assembly.LoadFile("C:\\Users\\andrey\\Desktop\\4sem\\�������\\WinFormsApp_OOP_2\\WinFormsApp1\\bin\\Debug\\net8.0-windows\\AssemblySandClock.dll");
            Assembly asm = Assembly.LoadFile(AssemblyFileName); //������

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

        private void ZipBintoolStripTextBox1_Click(object sender, EventArgs e)
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN"; // �������� �����
            //File.Create("C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN\\ZipBin.zip");
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBin.zip"; // ������ ����
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN\\ZipBin.zip"; // ������ ����
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipBIN"; // �����, ���� ��������������� ����
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }

        private void ZipJSONtoolStripTextBox3_Click(object sender, EventArgs e)
        {
            string sourceFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON"; // �������� �����
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON.zip"; // ������ ����
            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            string zipFile = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON.zip"; // ������ ����
            string targetFolder = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\ZipJSON"; // �����, ���� ��������������� ����
            ZipFile.ExtractToDirectory(zipFile, targetFolder);
        }

        bool AsmIsExist = false;

        private void ZIPtoolStripLabel2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.dll)|*.dll|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string AssemblyFileName = openFileDialog1.FileName;

            //string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\NewEra\\WinFormsApp_OOP_2-master (1)\\WinFormsApp_OOP_2-master\\ZIPWinFormsLibrary1\\bin\\Debug\\net8.0-windows\\ZIPWinFormsLibrary1.dll";
            //string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\a.dll";
            Assembly asm = Assembly.LoadFile(AssemblyFileName);
            AsmIsExist = true;

            Type? zipType = asm.GetType("ZIPWinFormsLibrary1.ZiptoolStripTextBox1");
            MethodInfo? square = zipType.GetMethod("OperationZipBin", BindingFlags.Public | BindingFlags.Static);
            //square?.Invoke(null, null);
            ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "OperationZipBin", Value = square });

            square = zipType.GetMethod("OperationExtractZipBin", BindingFlags.Public | BindingFlags.Static);
            //square?.Invoke(null, null);
            ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "OperationExtractZipBin", Value = square });

            square = zipType.GetMethod("OperationZipJSON", BindingFlags.Public | BindingFlags.Static);
            //square?.Invoke(null, null);
            ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "OperationZipJSON", Value = square });

            square = zipType.GetMethod("OperationExtractZipJSON", BindingFlags.Public | BindingFlags.Static);
            //square?.Invoke(null, null);
            ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "OperationExtractZipJSON", Value = square });
        }

        private void ZIPlistBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string operationName = ZIPlistBox2.Text;
            /*
                        OpenFileDialog openFileDialog1 = new OpenFileDialog();
                        openFileDialog1.Filter = "Text files(*.dll)|*.dll|All files(*.*)|*.*";
                        if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                            return;
                        string AssemblyFileName = openFileDialog1.FileName;
            */
            //���� AssemblyFileName ���� ������� ���������

            string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\WinFormsApp_OOP_2-master (2)\\WinFormsApp_OOP_2-master\\WinFormsLibrary2\\bin\\Debug\\net8.0-windows\\WinFormsLibrary2.dll";
            //string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\a.dll";
            Assembly asm = Assembly.LoadFile(AssemblyFileName);
            Type? type = asm.GetType("XmlToJsonPlugin");
            AdapterDima adapter = new AdapterDima(AssemblyFileName);


            XmlDocument doc = new XmlDocument(); //������������ � ���� case ������� ���� ��� ������� ������

            
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                //Formatting = Newtonsoft.Json.Formatting.Indented
            };
            switch (operationName)
            {
                case "ProcessBeforeSave":
                    //XML2JSON

                    adapter.ProcessBeforeSave(ref xml);
                     
/*
                    //XmlDocument doc = new XmlDocument();
                    doc.LoadXml(data);
                    data = JsonConvert.SerializeXmlNode(doc);
*/
                    break;
                case "ProcessAfterLoad":
                    //JSON2XML
                    string json = JsonConvert.SerializeObject(figuresList, settings);
                    string dataType = "WinFormsApp_OOP_1.GraphicsFigures.Figures.IFigure";
                    adapter.ProcessAfterLoad(ref json, dataType);
                    xml = json;
                    json = JsonConvert.SerializeObject(figuresList, settings);

                    /*
                    //string json = JsonConvert.SerializeObject(figuresList);
                    object[] arguments = new object[] { json };
                    object[] arguments2 = arguments;

                    string data2 = "";
                    string data = json;
                    doc = JsonConvert.DeserializeXmlNode(data, "WinFormsApp_OOP_1.GraphicsFigures.Figures.IFigure");
                    using (var stringWriter = new StringWriter())
                    using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                    {
                        doc.WriteTo(xmlTextWriter);
                        xmlTextWriter.Flush();
                        data2 = stringWriter.GetStringBuilder().ToString();
                    }

                    //�������� ��� �� �������� � ��������� ���������
                    doc.LoadXml(data2);
                    data = JsonConvert.SerializeXmlNode(doc);
                    *//*
                                        ������� ���� ��� � ����, ����� ��������� ������ ������������ ���, ����� ���� 
                                        ����� ���� ����� ������� ��� �������
                                        MethodInfo? square = type.GetMethod("ProcessAfterLoad"); //XML2JSON
                                        square?.Invoke(null, arguments); 
                                        //� ProcessBeforeSave ���������� string 

                                        var list = (object[])arguments;
                                        string resultString = list[0].ToString();

                                        if(arguments == arguments2)
                                        {
                                            int i = 0;
                                        }
                    */

                    break;
                case "ArchiveXmlFile":  //��� �� � �� ����������� ���
                    break;
                case "UnzipArchive":    //��� �� � �� ����������� ���
                    break;
            }
        }
        /*
                class IFigureToAbstractShapeAdapter : AbstractShape
                {
                    IFigure Figure;
                    // = new Brush();
                    public IFigureToAbstractShapeAdapter(IFigure figure)
                    {
                        Figure = figure;
                        public Brush color = new Brush();
                    }
                }
        */
/*
        public AbstractShape IFigureToAbstractShapeAdapter(IFigure figure)
        {

            AbstractShape abstractShape = new AbstractShape();
            System.Drawing.Brush brush = new System.Windows.Media.Brush();
            abstractShape.Color = figure.color;
            abstractShape.Color = ;
            //abstractShape.List<Point> listOfPoints

            return abstractShape;

        }*/

        private void AdaptPaterntoolStripTextBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files(*.dll)|*.dll|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string AssemblyFileName = openFileDialog1.FileName;

            AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\WinFormsApp_OOP_2-master (2)\\WinFormsApp_OOP_2-master\\WinFormsLibrary2\\bin\\Debug\\net8.0-windows\\WinFormsLibrary2.dll";
            //string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\a.dll";
            Assembly asm = Assembly.LoadFile(AssemblyFileName);
            Type? zipType = asm.GetType("XmlToJsonPlugin"); //WinFormsLibrary2

            MethodInfo? square = zipType.GetMethod("ProcessBeforeSave", BindingFlags.Public); //XML2JSON
            //square?.Invoke(null, null);
            ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "ProcessBeforeSave", Value = square });

            square = zipType.GetMethod("ProcessAfterLoad", BindingFlags.Public | BindingFlags.Static); //JSON2XML
            //square?.Invoke(null, null);
            ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "ProcessAfterLoad", Value = square });

            /*
                        string AssemblyFileName = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\OOP_4-detached\\TypesConverting (3)\\TypesConverting\\bin\\Debug\\net8.0-windows\\TypesConverting.dll";
                        Assembly asm = Assembly.LoadFile(AssemblyFileName);

                        Type? zipType = asm.GetType("ZIPWinFormsLibrary1.ZiptoolStripTextBox1");
                        MethodInfo? method = zipType.GetMethod("OperationZipBin", BindingFlags.Public | BindingFlags.Static);
                        //square?.Invoke(null, null);
                        ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "OperationZipBin", Value = method });

                        method = zipType.GetMethod("OperationExtractZipBin", BindingFlags.Public | BindingFlags.Static);
                        //square?.Invoke(null, null);
                        ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "OperationExtractZipBin", Value = method });
            */
            /*
                        //C:\Users\andrey\Desktop\4sem\�������\WinFormsApp_OOP_2-master (2)\WinFormsApp_OOP_2-master\WinFormsApp_OOP_2\WinFormsApp_OOP_2.csproj
                        OpenFileDialog openFileDialog = new OpenFileDialog
                        {
                            Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*",
                            InitialDirectory = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\WinFormsApp_OOP_2-master (2)\\WinFormsApp_OOP_2-master\\WinFormsLibrary2\\bin\\Debug\\net8.0-windows"
                        };
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string assemblyPath = openFileDialog.FileName;
                            try
                            {
                                archivator = new Adapter(assemblyPath);
                                MessageBox.Show("Plugin loaded successfully!");

                                ToolStripMenuItem functionsToolMenuItem = new ToolStripMenuItem(archivator.ToString());
            *//*
                                ToolStripMenuItem saveToZipMenuItem = new ToolStripMenuItem("Save to ZIP");
                                saveToZipMenuItem.Click += SaveToZipMenuItem_Click;

                                ToolStripMenuItem openZipMenuItem = new ToolStripMenuItem("Open ZIP");
                                openZipMenuItem.Click += OpenZipMenuItem_Click;

                                functionsToolMenuItem.DropDownItems.Add(saveToZipMenuItem);
                                functionsToolMenuItem.DropDownItems.Add(openZipMenuItem);

            *//*                    
                                //pluginsToolStripMenuItem.DropDownItems.Add(functionsToolMenuItem);
                                //ZIPlistBox2.Items.Add(functionsToolMenuItem);
                                ZIPlistBox2.Items.Add(new ComboboxItem() { Text = "AdapterPlugin", Value = functionsToolMenuItem });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Failed to load plugin: {ex.Message}");
                            }
                        }

                        string operationName = "LoadShapes";
                        string pluginPath = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\WinFormsApp_OOP_2-master (2)\\WinFormsApp_OOP_2-master\\WinFormsApp_OOP_2\\bin\\Debug\\net8.0-windows\\WinFormsApp_OOP_2.dll";
                        Assembly asm = Assembly.LoadFrom(pluginPath);
                        Type xmlToJson = asm.GetType("LoadShapes");
                        MethodInfo? square = xmlToJson.GetMethod(operationName, BindingFlags.Public);
                        square?.Invoke(null, null);



                        OpenFileDialog openFileDialog2 = new OpenFileDialog
                        {
                            Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*",
                            InitialDirectory = "C:\\Users\\andrey\\Desktop\\4sem\\�������\\WinFormsApp_OOP_2-master (2)\\WinFormsApp_OOP_2-master\\WinFormsLibrary2\\bin\\Debug\\net8.0-windows"
                        };
                        //string pluginPath = "";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            pluginPath = openFileDialog2.FileName;
                        }
                        var loadedPlugins = PluginLoader.LoadPlugins(Path.GetDirectoryName(pluginPath));

                        _plugins.AddRange(loadedPlugins);
                        _shapeProcessor = new ShapeProcessor(_plugins);

                        foreach (var plugin in _plugins)
                        {
                            var menuItem = new ToolStripMenuItem(plugin.Name);
                            ZIPlistBox2.Items.Add(menuItem);
                        }
            */
        }
    }
}
