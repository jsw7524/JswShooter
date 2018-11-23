using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private StringBuilder sb;
        //GameMgr gameMgr;
        Timer FormTimer;
        SolidBrush blueBrush;
        private MyShip myShip;
        public Form1(Timer t)
        {
            sb = new StringBuilder();
            
            blueBrush = new SolidBrush(Color.Blue);
            //gameMgr = g;
            FormTimer = t;
            FormTimer.Tick += new EventHandler(UpdateScreen);
            myShip = GameMgr.GameObjects.Where(a => a.ID == 0).FirstOrDefault() as MyShip;
            this.DoubleBuffered = true;
            InitializeComponent();
        }
        public void UpdateScreen(Object myObject, EventArgs myEventArgs)
        {
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            

        }

        private void Form1_Click(object sender, EventArgs e)
        {

            int i = 1;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyShip myShip =GameMgr.GameObjects.FirstOrDefault() as MyShip;
            this.label1.Text = "HP:" + myShip.HP + " Frame:" + GameMgr.OffSetY;
            foreach (var gobj in GameMgr.GameObjects)
            {
                if (gobj is VisibleGameObject)
                {
                    Brush brush = Brushes.White;
                    var g = gobj as VisibleGameObject;

                    if (gobj is EnemyShip)
                    {
                        brush = Brushes.Red;
                    }
                    else if (gobj is MyShip)
                    {
                        brush = Brushes.Blue;            
                    }
                    else if (gobj is Bullet)
                    {
                        brush = Brushes.Gold;
                    }
                    else if (gobj is Brick)
                    {
                        brush = Brushes.Black;
                    }
                    else if (gobj is Laser)
                    {
                        brush = Brushes.Aqua;
                    }
                    e.Graphics.FillRectangle(brush, g.TopLeftX, g.TopLeftY, g.BottomRightX - g.TopLeftX,g.BottomRightY - g.TopLeftY);
                }

            }



        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            myShip.Shoot();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //myShip.Instructions.Enqueue(e.KeyData);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            myShip.SetXY(e.X, e.Y);
        }
    }
}
