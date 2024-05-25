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

namespace WinFormsApp_OOP_2
{
    public partial class Form1 : Form
    {
        private Circle prCircleProp;
        private Ellipse prEllipseProp;
        private Line prLineProp;
        private Quadrilateral prQuadrilateralProp;
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
            using (FileStream fs = new FileStream("SerializeBIN.bin", FileMode.OpenOrCreate))
            {
                foreach (IFigure figure in figuresList)
                {
                    formatter.Serialize(fs, figure);
                }
            }
        }

        public void DeSerializeBIN()
        {
            IFigure figure;
            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("SerializeBIN.bin", FileMode.OpenOrCreate))
            {
                for (int i = 0; i < 3; i++)
                {
                    figure = (IFigure)formatter.Deserialize(fs);
                    figuresList.Add(figure);
                }

                //Console.WriteLine("Объект десериализован");
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
            File.WriteAllText("SerializeJSON.json", json);
        }

        public void DeSerializeJSON()
        {
            string json = File.ReadAllText("SerializeJSON.json");

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Newtonsoft.Json.Formatting.Indented

            };

            figuresList = JsonConvert.DeserializeObject<List<IFigure>>(json, settings);

            //вот эта хрень добавляет WinFormApp в listBox

            foreach (IFigure figure in figuresList)
            {
                //listBox.Items.Add(figure);
                //listBox1.Items.Add(figuresList.Count + "." + figure.ToString);
            }
            for(int i = 0;i < figuresList.Count; i++)
            {
                listBox1.Items.Add(i + 1 + "." + figuresList[i].ToString());
            }

            pictureBox1.Invalidate();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //cbKindOfProps.SelectedGridItem = null;

            listBox.Items.Add(new ComboboxItem() { Text = "Circle", Value = new CircleFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Ellipse", Value = new EllipseFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Line", Value = new LineFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Point", Value = new PointFactory() });
            //listBox.Items.Add(new ComboboxItem() { Text = "Quadrilateral", Value = new QuadrilateralFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Rectangle", Value = new RectangleFactory() });
            listBox.Items.Add(new ComboboxItem() { Text = "Square", Value = new SquareFactory() });

            //переделать на считывание с потока
            IFactory? facroty = new RectangleFactory();
            IFigure figure;

            //заполняем пару обьектов, чтобы их потом сериализовать
            /*
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
            */

            //сериализация

            // создаем объект BinaryFormatter
#pragma warning disable SYSLIB0011
            //BinaryFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011
            //DeSerializeBIN();
            SerializeBIN();
            //SerializeJSON();
            //DeSerializeJSON();
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

                IFactory facroty = (listBox.SelectedItem as ComboboxItem)?.Value as IFactory; //создаю фабрику для конкретной фигуры
                IFigure figure = facroty.Create(startPoint, endPoint); //создаю конкретную фигуру абстрактоного типа
                figuresList.Add(figure);

                string FigureName = listBox.SelectedItem.ToString();
                //string[] words = text.Split(".", System.StringSplitOptions.RemoveEmptyEntries);

                //listBox1.Items.Add(figuresList.Count + "." + FigureName);
                listBox1.Items.Add(figuresList.Count + "." + figuresList[figuresList.Count - 1].ToString());

                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            IVisitor visitor = new GraphicsVisitor(e.Graphics);
            foreach (IFigure figure in figuresList)
            {
                //figure.Change(visitor);
                figure.Accept(visitor);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            /*
                        IVisitor visitor = new GraphicsVisitor();
                        foreach (IFigure figure in figuresList)
                        {
                            //if(e.Location.X < figure.)
                            //e.Location.X
                            figure.Change(visitor);
                            figure.Accept(visitor);
                        }
            */
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

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

        private void cbKindOfProps_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox a = sender as ListBox;
            int SelectedIndex = a.SelectedIndex;
            if (SelectedIndex >= 0)
            {
                cbKindOfProps.SelectedObject = figuresList.ElementAt(SelectedIndex);
            }


            /*
            switch (figura)
            {
                cbKindOfProps.SelectedObject = prTextProp;
                            case "ellipse"
                            case Point
                                add property PointX
                                    set property.Name=PointX
                                    set property.Value=x;
                                    add property PointY
                                case ...
            */

            int i = 0;
            //prgProperty.SelectedObject = prTextProp;
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
    }
}
