using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class MyShip : Ship
    {

        public MyShip(int x, int y) : base(x,y,10,10,3,3,100, "Laser")
        {
            


        }

        public Queue<Keys> Instructions;

        public override void DoSomething()
        {
            
            base.DoSomething();
            this.IsHit();
            Debug.Print(this.HP.ToString());
        }

        public void SetXY(int x, int y)
        {
            this.X = x;
            this.Y = y;
            SetGraph();
        }
        public override void Shoot()
        {

            if (CheckCoolDown())
            {
                switch (ShipWeapon)
                {
                    case "Bullet":
                        new Bullet(this.X, this.Y - 10,0,-1);
                        break;
                    case "Laser":
                        new Laser(this.X, this.Y - 10, 0, -1);
                        break;
                }
            }
        }

        public override void Move(int x, int y)
        {
            this.X += x * Speed;
            this.Y += y * Speed;
            SetGraph();
        }
    }
}
