using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Bullet : Weapon, IMovable, IDrawable
    {
        public int Speed { get; set; }
        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX { get; set; }
        public int BottomRightY { get; set; }
        public List<Point> Contour { get; set; }

        public Bullet()
        {
            Contour = new List<Point>();
        }

        public Bullet(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Width = 5;
            this.Height = 5;
            this.Speed = 5;
            Contour = new List<Point>();
        }



        public void Move(int x, int y)
        {
            this.X += 0;
            this.Y += y * Speed;
            SetGraph();
        }

        public void SetGraph()
        {
            TopLeftX = this.X;
            TopLeftY = this.Y;
            BottomRightX = this.X + this.Width;
            BottomRightY = this.Y + this.Height;
            Contour.Add(new Point(this.X, this.Y));
            Contour.Add(new Point(this.X, this.Y + this.Height));
            Contour.Add(new Point(this.X + this.Width, this.Y));
            Contour.Add(new Point(this.X + this.Width, this.Y + this.Height));
        }

        public override void DoSomething()
        {
            //base.DoSomething();
            this.Move(0, -1);
        }

        public List<GameObject> IsHit()
        {
            throw new NotImplementedException();
        }
    }
}
