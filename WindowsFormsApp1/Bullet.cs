using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Bullet : Weapon, IMovable, IDrawable
    {
        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX { get; set; }
        public int BottomRightY { get; set; }
        public List<Point> Contour { get; set; }

        public int Ax{ get; set; }
        public int Ay { get; set; }

        public Bullet(int x, int y, int ax, int ay) : base(x, y, 5, 5, 4, 1)
        {
            Ax = ax;
            Ay = ay;

            Contour = new List<Point>();
            Contour.Add(new Point(this.X, this.Y));
            Contour.Add(new Point(this.X, this.Y + this.Height));
            Contour.Add(new Point(this.X + this.Width, this.Y));
            Contour.Add(new Point(this.X + this.Width, this.Y + this.Height));
            foreach (var p in this.Contour)
            {
                GameMgr.GameObjectDictionary.Add(p, this);
            }
        }



        public void Move(int x, int y)
        {
            this.X += x * Speed;
            this.Y += y * Speed;
            SetGraph();
        }

        public void SetGraph()
        {
            TopLeftX = this.X;
            TopLeftY = this.Y;
            BottomRightX = this.X + this.Width;
            BottomRightY = this.Y + this.Height;
            
            //////////////
            Contour[0].X = this.X;
            Contour[0].Y = this.Y;
            Contour[1].X = this.X;
            Contour[1].Y = this.Y + this.Height;
            Contour[2].X = this.X + this.Width;
            Contour[2].Y = this.Y;
            Contour[3].X = this.X + this.Width;
            Contour[3].Y = this.Y + this.Height;
            ///////////////

        }

        public override void DoSomething()
        {
            base.DoSomething();
            this.Move(Ax, Ay);
            IsHit();
        }

        public List<GameObject> IsHit()
        {


            return null;
        }
    }
}
