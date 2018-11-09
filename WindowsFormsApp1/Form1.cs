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
        GameMgr gameMgr;
        Timer FormTimer;
        public Form1(GameMgr g, Timer t)
        {
            gameMgr = g;
            FormTimer = t;
            FormTimer.Tick+= new EventHandler(UpdateScreen);
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
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            foreach (var p in gameMgr.GameDataStructure.Points)
            {
                e.Graphics.FillRectangle(blueBrush, p.X, p.Y, 10, 10);
            }

            

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            gameMgr.GameDataStructure.Points.Add(new Point(e.X, e.Y));
        }
    }
}
