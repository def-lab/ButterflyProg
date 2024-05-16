using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(9000, 1100);
            this.MinimumSize = new Size(800, 900);
           //this.BackgroundImage = Image.FromFile("C:\\Users\\Mirage\\Desktop\\p.jpg");// Тут твое расположение на фон
            this.DoubleBuffered = true;
            
            Bab.Image = Image.FromFile(@"C:\Users\Aogiri\source\repos\WindowsFormsApp2\WindowsFormsApp2\butterfly\butterfly.png"); // Тут ты свое расположение изображения
            Bab.SizeMode = PictureBoxSizeMode.StretchImage;
            Bab.BorderStyle = BorderStyle.None;
            Bab.BackColor = Color.Transparent;
            Bab.MouseEnter += new EventHandler(this.Bab_MouseEnter);
            Bab.MouseMove += new MouseEventHandler(Bab_MouseMove);
            //this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            Bab.MouseLeave += new EventHandler(Bab_MouseLeave);
            Bab.MouseDown += new MouseEventHandler(Bab_MouseDown);
            Bab.MouseUp += new MouseEventHandler(Bab_MouseUp);
        }

        private void Bab_MouseUp(object sender, MouseEventArgs e)
        {
            ispressed = false;
        }

        private bool ispressed = false;
        private void Bab_MouseDown(object sender, EventArgs e)
        {
            ispressed = true;
        }

        private bool isMove = false;


        private void Bab_MouseEnter(object sender, EventArgs e)
        {
            isMove = true;
            Control control = (Control)sender;
            Point mousePos = control.PointToClient(MousePosition);


        }
        private const double SlowDownFactor = 0.1; // Коэффициент замедления

        private void Bab_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && ispressed)
            {
                Control control = (Control)sender;


                int dx = MousePosition.X - control.Left;
                int dy = MousePosition.Y - control.Top;


                double slowDownFactor = 0.05;


                int newX = control.Left + (int)(dx * slowDownFactor);
                int newY = control.Top + (int)(dy * slowDownFactor);


                control.Left = newX;
                control.Top = newY;
            }
        }



        private void Bab_MouseLeave(object sender, EventArgs e)
        {
            isMove = false;
        }
    }
}
