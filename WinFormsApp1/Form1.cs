using System.Net;
using System.Windows.Forms;
using WinFormsApp_OOP_2.Drawers;
using WinFormsApp_OOP_1.GraphicsFigures.Figures;
using WinFormsApp_OOP_2.Visitors;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
/*
        IFactory facroty;
        IFigure figure;
        public Form1()
        {
            //������ ������� ��� ���������� ������
            IFactory facroty = new QuadrilateralFactory(); //������ ������� ��� ���������� ������
            IFigure figure = facroty.Create(new Point(20, 20), new Point(120, 120)); //������ ���������� ������ ������������� ����


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //������ ������� ��� ���������� ������
            facroty = new QuadrilateralFactory(); //������ ������� ��� ���������� ������
            figure = facroty.Create(new Point(20, 20), new Point(120, 120)); //������ ���������� ������ ������������� ����

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            IVisitor visitor = new GraphicsVisitor(e.Graphics);

            //figure.Change(visitor);
            figure.Draw(visitor);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
*/
    }
}
