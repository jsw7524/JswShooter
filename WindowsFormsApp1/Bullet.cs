using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Bullet : Weapon, IMovable
    {

        public int Ax{ get; set; }
        public int Ay { get; set; }
        static public int CoolDownTime { get; set; } = 5;
        public Bullet(int x, int y, int ax, int ay) : base(x, y, 5, 5, 4, 1, 3)
        {
            Ax = ax;
            Ay = ay;
        }

        public void Move(int x, int y)
        {
            this.X += x * Speed;
            this.Y += y * Speed;
            SetGraph();
        }


        public override void DoSomething()
        {
            base.DoSomething();
            this.Move(Ax, Ay);
            IsHit();
        }

    }
}
