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
        //GameMgr gameMgr;
        Timer FormTimer;
        SolidBrush blueBrush;
        private MyShip myShip;
        public Form1(Timer t)
        {
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

        }

        private void Form1_Click(object sender, EventArgs e)
        {

            int i = 1;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            foreach (var gobj in GameMgr.GameObjects)
            {
                if (gobj is IDrawable)
                {

                    if (gobj is EnemyShip)
                    {
                        var g = gobj as EnemyShip;
                        e.Graphics.FillRectangle(Brushes.Red, g.TopLeftX, g.TopLeftY, g.BottomRightX - g.TopLeftX, g.BottomRightY - g.TopLeftY);
                    }
                    else if (gobj is Bullet)
                    {
                        var g = gobj as Bullet;
                        e.Graphics.FillRectangle(Brushes.Gold, g.TopLeftX, g.TopLeftY, g.BottomRightX - g.TopLeftX, g.BottomRightY - g.TopLeftY);
                    }
                    else if (gobj is MyShip)
                    {
                        var g = gobj as MyShip;
                        e.Graphics.FillRectangle(Brushes.Blue, g.TopLeftX, g.TopLeftY, g.BottomRightX - g.TopLeftX, g.BottomRightY - g.TopLeftY);
                    }
                    else if (gobj is Brick)
                    {
                        var g = gobj as Brick;
                        e.Graphics.FillRectangle(Brushes.Black, g.TopLeftX, g.TopLeftY, g.BottomRightX - g.TopLeftX, g.BottomRightY - g.TopLeftY);
                    }
                }
                //e.Graphics.FillRectangle(blueBrush, 10, 10, 10, 10);
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
