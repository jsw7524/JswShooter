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
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new System.Drawing.Point(500, 500);
                

        }

        private void Form1_Click(object sender, EventArgs e)
        {

            int i = 1;

        }
        Pen penAqua = new Pen(Color.Aqua, 5);
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 6);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyShip myShip =GameMgr.GameObjects.FirstOrDefault() as MyShip;
            //label1.Hide();
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
                        if (gobj is EnemyShipAce)
                        {
                            var ace = gobj as EnemyShipAce;
                            
                            e.Graphics.DrawString("ACE", drawFont, brush, g.X-5, g.BottomRightY);
                            //e.Graphics.DrawString("Left:   "+ ace.distanceLeft, drawFont, brush, g.X - 5, g.BottomRightY+20);
                            //e.Graphics.DrawString("Right: " + ace.distanceRight, drawFont, brush, g.X - 5, g.BottomRightY + 50);
                            //e.Graphics.DrawString("Up:   " + ace.distanceUp, drawFont, brush, g.X - 5, g.BottomRightY + 80);
                            //e.Graphics.DrawString("Down: " + ace.distanceDown, drawFont, brush, g.X - 5, g.BottomRightY + 110);
                            //e.Graphics.DrawString("Rad: " + ace.rad, drawFont, brush, g.X - 5, g.BottomRightY + 140);
                            //e.Graphics.DrawString("Dis: " + ace.measureDistance, drawFont, brush, g.X - 5, g.BottomRightY + 170);
                        }
                    }
                    else if (gobj is MyShip)
                    {
                        brush = Brushes.Blue;            
                    }
                    else if (gobj is EnemyBullet)
                    {
                        brush = Brushes.Gold;
                    }
                    else if (gobj is Brick)
                    {
                        brush = Brushes.Black;
                    }
                    else if (gobj is FirstAidKit)
                    {
                        brush = Brushes.LimeGreen;
                    }
                    else if (gobj is PowerUpBullet)
                    {
                        brush = Brushes.Goldenrod;
                    }
                    else if (gobj is SheildShip)
                    {
                        brush = Brushes.DeepSkyBlue;
                    }
                    else if (gobj is FriendShip)
                    {
                        brush = Brushes.CornflowerBlue;
                    }
                    else if (gobj is FriendBullet)
                    {
                        brush = Brushes.CornflowerBlue;
                    }
                    else if (gobj is Laser)
                    {
                        //brush = Brushes.Aqua;
                        
                        e.Graphics.DrawLine(penAqua, g.X, g.Y, g.X, g.BottomRightY);
                        continue;
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
